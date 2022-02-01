using System;
using System.Text;
using System.Text.Json;
using API.Dtos;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace API.Services
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                UserName = _configuration["RabbitMQUserName"],
                Password = _configuration["RabbitMQPassword"],
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"])
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                
                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
                
                Console.WriteLine("--> Connection to Message Bus");
            }
            catch (Exception e)
            {
                Console.WriteLine($"--> Not connection: {e.Message}");
            }
        }

        public void PublishedNewGame(PublishedGameDto publishedGameDto)
        {
            var message = JsonSerializer.Serialize(publishedGameDto);

            if (_connection.IsOpen)
            {
                Console.WriteLine("--> Open connection, sending message...");
                SendMessage(message);
            }
            else
            {
                Console.WriteLine("--> Closed connection, not sending");
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            
            _channel.BasicPublish(exchange: "trigger", 
                        routingKey: "",
                        basicProperties: null,
                        body: body);
            Console.WriteLine($"--> We send message: {message}");
        }

        public void Dispose()
        {
            Console.WriteLine("--> Message Bus Disposed");
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("--> RabbitMQ connection Shutdown");
        }
    }
}