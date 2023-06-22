<?php

namespace App\Http\Controllers;
// use App\Consumers\RabbitConsumer;
use Illuminate\Http\Request;

class ConsumeController extends Controller
{

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
    // public function listarPedidos()
    // {
    //     return $this->pedidoService->listarPedidos();
    // }

    // public function cadastrarPedido(Request $request)
    // {
    //     return $this->pedidoService->cadastrarPedido($request->all());
    // }

    // public function atualizarPedido($id, Request $request)
    // {
    //     return $this->pedidoService->atualizarPedido($id, $request->all());
    // }
    public function consumer(){
        dd('teste');
    }
    // Route::get('/consume', function () {
    //     $consumer = new RabbitConsumer();
    //     $consumer->consume();
    //     return 'Consumidor iniciado.';
    // });
}
