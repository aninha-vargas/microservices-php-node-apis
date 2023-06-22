<?php

namespace App\Consumers;

use PhpAmqpLib\Connection\AMQPStreamConnection;
use PhpAmqpLib\Message\AMQPMessage;

class RabbitConsumer
{
    protected $connection;
    protected $channel;
    protected $queue = 'FILA';

    public function __construct()
    {
        $this->connection = new AMQPStreamConnection(
            config('rabbitmq.host'),
            config('rabbitmq.port'),
            config('rabbitmq.username'),
            config('rabbitmq.password'),
            config('rabbitmq.vhost')
        );

        $this->channel = $this->connection->channel();
    }

    public function consume()
    {
        $this->channel->queue_declare(
            $this->queue, // Nome da fila
            false, // Passive
            true, // Durable
            false, // Exclusive
            false // Auto-delete
        );

        $this->channel->basic_consume(
            $this->queue, // Fila
            '', // Consumer tag
            false, // No local
            false, // No ack
            false, // Exclusive
            false, // No wait
            [$this, 'processMessage'] // Callback
        );

        while ($this->channel->is_consuming()) {
            $this->channel->wait();
        }
    }

    public function processMessage(AMQPMessage $message)
    {
        $body = $message->getBody();
        // Lógica de processamento da mensagem recebida
        echo "Mensagem recebida: $body" . PHP_EOL;
        $message->ack();
    }
}
