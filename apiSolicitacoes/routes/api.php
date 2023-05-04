<?php
use App\Http\Controllers\PedidoController;
use App\Http\Controllers\PessoaController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});
Route::prefix('pedido')->group(function () {
    Route::get('/', [PedidoController::class, 'listarPedidos']);
    Route::post('/', [PedidoController::class, 'cadastrarPedido']);
    Route::put('/{id}', [PedidoController::class, 'atualizarPedido']);
});
Route::prefix('pessoa')->group(function () {
    Route::get('/{id}', [PessoaController::class, 'obterPessoa']);
});
