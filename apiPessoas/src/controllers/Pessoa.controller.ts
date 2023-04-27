import { PessoaRepository } from "../data/Pessoa.repository";
import { Request, Response } from 'express';
import { Pessoa } from "../models/Pessoa.model";
import Axios from 'axios';
import { Endereco } from "../models/Endereco.models";

const repositoryPessoa = new PessoaRepository();

export class PessoaController {
    async listar(request: Request, response: Response) {
        const result = await repositoryPessoa.listar()
        console.log(result)

        return response.json({
            status: 'ok',
            content: result
        })
    }

    async Buscar(request: Request, response: Response) {
        const result = await repositoryPessoa.buscarPorId(request.params.idPessoa)
        console.log(result)

        return response.json({
            status: 'ok',
            content: result
        })
    }

    async cadastrar(request: Request, response: Response) {
        let { cep, nome, idade } = request.body;
        let endereco: Endereco = (await Axios.get(`http://localhost:3000/getApi/${cep}`)).data.content;
        let pessoa: Pessoa = { nome, idade, endereco }
        const pessoas = await repositoryPessoa.incluir(pessoa);

        if (pessoas) {
            return response.json({
                status: 'ok',
                content: 'Pessoa cadastrada com sucesso!'
            })
        } else {
            return response.json({
                status: 'error',
                content: 'Algo deu errado ao cadastrar pessoa!'
            })
        }

    }

    async atualizar(request: Request, response: Response) {
        let { cep, nome, idade, idPessoa } = request.body;
        let endereco: Endereco = (await Axios.get(`http://localhost:3000/getApi/${cep}`)).data.content;
        let pessoa: Pessoa = { nome, idade, endereco }
        const pessoas = await repositoryPessoa.atualizar(pessoa, idPessoa);

        if(pessoas) {
            return response.json({
                status: 'ok',
                content: 'Pessoa atualizada com sucesso!'
            })
        } else {
            return response.json({
                status: 'error',
                content: 'Algo deu errado ao atualizar pessoa!'
            })
        }
    }

    async deletar(request: Request, response: Response) {
        const pessoas = await repositoryPessoa.deletar(request.params.idPessoa);

        return response.json({
            status: 'ok',
            content: 'Pessoa deletada com sucesso!'
        })
    }
}
