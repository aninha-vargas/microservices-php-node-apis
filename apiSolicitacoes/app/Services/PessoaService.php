<?php

namespace App\Services;

// use App\Repositories\PedidoRepository;
use Illuminate\Support\Facades\Http;


class PessoaService
{
    // private $pedidoRepository;

    // public function __construct(PedidoRepository $pedidoRepository)
    // {
    //     $this->pedidoRepository = $pedidoRepository;
    // }


    // public function listarPessoas()
    // {
    //     return $this->pedidoRepository->listar();
    // }

    public function obterPessoa($id)
    {
        $response = Http::get("http://localhost:3000/BuscarPorId/" . $id);
        $pessoa = json_decode($response);
        if(isset($pessoa->content->nome)) {
            return $pessoa->content->nome;
        } else {
            return $pessoa->content;
        }
    }
}
