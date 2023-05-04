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

    /**
     * @OA\Info(
     *   title="API Laravel Swagger Documentation",
     *   version="1.5.0",
     *   contact={
     *     "email": "dev.tbarbosa.bento@gmail.com"
     *   }
     * )
    //  * @OA\SecurityScheme(
    //  *  type="http",
    //  *  description="Acess token obtido na autenticação",
    //  *  name="Authorization",
    //  *  in="header",
    //  *  scheme="bearer",
    //  *  bearerFormat="JWT",
    //  *  securityScheme="bearerToken"
    //  * )
     */
    public function listarPedidos()
    {
        return $this->pedidoService->listarPedidos();
    }

    public function cadastrarPedido(Request $request)
    {
        return $this->pedidoService->cadastrarPedido($request->all());
    }

    public function atualizarPedido($id, Request $request)
    {
        return $this->pedidoService->atualizarPedido($id, $request->all());
    }
}
