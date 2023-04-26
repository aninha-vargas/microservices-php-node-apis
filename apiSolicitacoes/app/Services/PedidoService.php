<?php

namespace App\Services;

use App\Repositories\PedidoRepository;

class PedidoService
{
    private $pedidoRepository;

    public function __construct(PedidoRepository $pedidoRepository)
    {
        $this->pedidoRepository = $pedidoRepository;
    }

    public function listarPedidos()
    {
        return $this->pedidoRepository->listar();
    }

    public function cadastrarPedidos($dados)
    {
        return $this->pedidoRepository->criar($dados);
    }

}
