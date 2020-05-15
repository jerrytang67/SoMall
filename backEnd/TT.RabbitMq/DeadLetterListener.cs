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
    public class DeadLetterListener : IHostedService
    {
        public readonly RabbitMqOptions Options;
        private readonly IConnection _connection;
        private readonly IModel _channel;


        public readonly ILogger<DeadLetterListener> Logger;

        public DeadLetterListener(
            IOptions<RabbitMqOptions> optionsAccessor,
            ILogger<DeadLetterListener> logger
        )
        {
            Logger = logger;
            Options = optionsAccessor.Value;
            try
            {
                var factory = new ConnectionFactory()
                {
                    UserName = Options.UserName,
                    Password = Options.Password,
                    HostName = Options.HostName,
                    Port = Options.Port
                };
                this._connection = factory.CreateConnection();
                this._channel = _connection.CreateModel();
                Logger.LogWarning($"RabbitMQ 连接成功");
            }
            catch (Exception ex)
            {
                Logger.LogError(($"RabbitListener init error,ex:{ex.Message}"));
            }
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Register();
            await Task.CompletedTask;
        }

        // 处理死信队列
        protected virtual async Task Register()
        {
            var WORK_QUEUE = Options.DelayWorkQueryName;
            var WORK_EXCHANGE = Options.DelayWorkExchangeName; // dead letter exchange

            _channel.ExchangeDeclare(WORK_EXCHANGE, "direct");
            _channel.QueueDeclare(WORK_QUEUE, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: WORK_QUEUE, exchange: WORK_EXCHANGE, routingKey: string.Empty, arguments: null);

            //回调，当consumer收到消息后会执行该函数
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Logger.LogWarning($"收到死信消息： {message}");
                var result = await ProcessAsync(message);
                if (result)
                {
                    _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                // else
                // {
                // requeue：重新入队列，false：直接丢弃，相当于告诉队列可以直接删除掉
                //     _channel.BasicReject(ea.DeliveryTag, requeue: true);
                // }

                await Task.Yield();
            };
            _channel.BasicConsume(queue: WORK_QUEUE, autoAck: false, consumer: consumer);

            await Task.CompletedTask;
        }

        protected virtual Task<bool> ProcessAsync(string message)
        {
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