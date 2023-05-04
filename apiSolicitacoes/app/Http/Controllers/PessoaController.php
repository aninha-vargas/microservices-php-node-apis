<?php

namespace App\Http\Controllers;
use App\Services\PessoaService;
use Illuminate\Http\Request;

class PessoaController extends Controller
{
    private $pessoaService;

    public function __construct(PessoaService $pessoaService)
    {
        $this->pessoaService = $pessoaService;
    }

    public function obterPessoa($id)
    {
        return $this->pessoaService->obterPessoa($id);
    }
}
