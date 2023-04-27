import { Pessoa } from './../models/Pessoa.model';
import PessoaModelTable from '../models/tables/Pessoa.models.tables';

let pessoas: Pessoa[] = [];

export class PessoaRepository {
    async listar(): Promise<Pessoa[]> {
        let result = await PessoaModelTable.findAll()
        pessoas = []
        for(let d in result) {
            pessoas.push(result[d].dataValues)
        }
        return pessoas
    }

    async incluir(pessoa: Pessoa): Promise<Pessoa> {
        const insert = await PessoaModelTable.create({
            nome: pessoa.nome,
            idade: pessoa.idade,
            cep: pessoa.endereco.cep,
            logradouro: pessoa.endereco.logradouro,
            complemento: pessoa.endereco.complemento,
            bairro: pessoa.endereco.bairro,
            localidade: pessoa.endereco.localidade,
            uf: pessoa.endereco.uf,
            ibge: pessoa.endereco.ibge,
            gia: pessoa.endereco.gia,
            ddd: pessoa.endereco.ddd,
            siafi: pessoa.endereco.siafi,
        })
        return pessoa
    }

    async buscarPorId(idPessoa: number): Promise<Pessoa[]> {
        let result = await PessoaModelTable.findOne({
            where: {
                idPessoa: idPessoa
            }
        });
        if(result) {
            return result.dataValues;
        }
    }

    async atualizar(pessoa: Pessoa, idPessoa: number): Promise<Pessoa> {
        
        await PessoaModelTable.update({
            nome: pessoa.nome,
            idade: pessoa.idade,
            cep: pessoa.endereco.cep,
            logradouro: pessoa.endereco.logradouro,
            complemento: pessoa.endereco.complemento,
            bairro: pessoa.endereco.bairro,
            localidade: pessoa.endereco.localidade,
            uf: pessoa.endereco.uf,
            ibge: pessoa.endereco.ibge,
            gia: pessoa.endereco.gia,
            ddd: pessoa.endereco.ddd,
            siafi: pessoa.endereco.siafi,
        }, {
            where: {
                idPessoa: idPessoa
            }
        })

        return pessoa
    }

    async deletar(idPessoa: string) {
        
        await PessoaModelTable.destroy({
            where: {
                idPessoa: idPessoa
            }
        });
    }

}