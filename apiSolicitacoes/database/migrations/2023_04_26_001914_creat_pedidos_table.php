<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('pedidos', function (Blueprint $table) {
            $table->id();
            $table->string('solicitante')->nullable();
            $table->string('responsavel')->nullable();
            $table->longText('mensagem');
            $table->string('assunto');
            // $table->foreignId('status_id')->contrained('status');
            // $table->foreignId('prioridade_id')->contrained('prioridades');
            $table->string('justificativa_cancelar')->nullable();
            $table->timestamps();
        });

    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('pedidos');
    }
};
