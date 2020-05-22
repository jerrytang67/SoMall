using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TT.RabbitMQ
{
    public class RabbitMqListener : IHostedService
    {
        private readonly RabbitMqOptions _options;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly ILogger<RabbitMqListener> _logger;
        protected string RouteKey { get; set; }

        public RabbitMqListener(IOptions<RabbitMqOptions> optionsAccessor, ILogger<RabbitMqListener> logger)
        {
            _logger = logger;
            _options = optionsAccessor.Value;
            try
            {
                var factory = new ConnectionFactory()
                {
                    UserName = _options.UserName,
                    Password = _options.Password,
                    HostName = _options.HostName,
                    Port = _options.Port
                };
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _logger.LogInformation($"RabbitMqListener 连接成功");
            }
            catch (Exception ex)
            {
                _logger.LogError(($"RabbitListener init error,ex:{ex.Message}"));
            }
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Register();
            await Task.CompletedTask;
        }


        // 处理消息的方法
        protected virtual async Task Register()
        {
            _channel.ExchangeDeclare("message", ExchangeType.Topic, true, false, null);
            _channel.QueueDeclare(_options.QueryName, true, false, false, null);

            _channel.QueueBind(queue: _options.QueryName, exchange: "message", routingKey: RouteKey);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var result = await ProcessAsync(message);
                _logger.LogInformation($"收到消息： {message} routerKey: {ea.RoutingKey}");
                if (result)
                {
                    _channel.BasicAck(ea.DeliveryTag, false);
                }

                await Task.Yield();
            };
            _channel.BasicConsume(queue: _options.QueryName, consumer: consumer);

            await Task.CompletedTask;
        }

        protected virtual Task<bool> ProcessAsync(string message)
        {
            // 在继承类中去实现具体操作
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _channel?.Dispose();
            _connection?.Dispose();
            return Task.CompletedTask;
        }
    }
}