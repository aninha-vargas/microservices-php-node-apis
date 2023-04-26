<?php

namespace App\Http\Controllers;
use App\Services\PedidoService;
use Illuminate\Http\Request;

class PedidoController extends Controller
{
    private $pedidoService;

    public function __construct(PedidoService $pedidoService)
    {
        $this->pedidoService = $pedidoService;
    }

    public function listarPedidos()
    {
        return $this->pedidoService->listarPedidos();
    }

    public function cadastrarPedidos(Request $request)
    {
        return $this->pedidoService->cadastrarPedidos($request->all());
    }
}
