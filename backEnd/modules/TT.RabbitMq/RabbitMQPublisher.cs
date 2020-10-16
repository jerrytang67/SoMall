using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace TT.RabbitMQ
{
    public class RabbitMqPublisher : IDisposable
    {
        private readonly IModel _channel;
        private readonly IConnection _connection;
        private readonly ILogger<RabbitMqPublisher> _logger;
        private readonly RabbitMqOptions _options;

        public RabbitMqPublisher(IOptions<RabbitMqOptions> optionsAccessor,
            ILogger<RabbitMqPublisher> logger)
        {
            _logger = logger;
            _options = optionsAccessor.Value;
            try
            {
                var factory = new ConnectionFactory
                {
                    UserName = _options.UserName,
                    Password = _options.Password,
                    HostName = _options.HostName,
                    Port = _options.Port
                };
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _logger.LogWarning("RabbitMQ Publisher 连接成功");
            }
            catch (Exception ex)
            {
                _logger.LogError($"RabbitListener init error,ex:{ex.Message}");
            }
        }


        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
            _logger?.LogWarning("RabbitMQ Publisher Dispose");
        }

        public virtual void PushMessage(object message, string queryName = null, string routerKey = "Test.*")
        {
            queryName ??= _options.QueryName;

            var exchangeName = "message";

            _logger.LogDebug($"PushMessage queryName:{queryName} routingKey:{routerKey}");

            //定义一个Direct类型交换机
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, true, false, null);

            //定义一个队列
            _channel.QueueDeclare(queryName, true, false, false, null);

            //将队列绑定到交换机
            _channel.QueueBind(queryName, exchangeName, routerKey, null);

            var sendBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));

            _channel.BasicPublish(exchangeName, routerKey, null, sendBytes);
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ttl">过期时间(秒)</param>
        /// <param name="queryName"></param>
        /// <param name="routerKey"></param>
        public virtual void PushDelyMessage(object message, int ttl, string queryName)
        {
            queryName ??= _options.QueryName;
            var delayworkexchange = _options.DelayWorkExchangeName; // dead letter exchange
            var delayexchange = _options.DelayExchangeName;

            if (string.IsNullOrWhiteSpace(delayworkexchange) || string.IsNullOrWhiteSpace(delayexchange))
            {
                throw new Exception("没有设置死信队列交换机");
            }

            var queueArgs = new Dictionary<string, object>
            {
                {"x-dead-letter-exchange", delayworkexchange},
                {"x-message-ttl", 2 * 60 * 60 * 1000} // 默认设置2小时过期
            };

            // TODO: add router-key will throw err??why??
            // if (routerKey != null)
            //     queueArgs.Add("x-dead-letter-routing-key", routerKey);

            _channel.ExchangeDeclare(delayexchange, "direct");
            _channel.QueueDeclare(queryName, true, false, false, queueArgs);
            _channel.QueueBind(queryName, delayexchange, string.Empty, null);

            var sendBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            ));

            var properties = _channel.CreateBasicProperties();
            properties.Expiration = (ttl * 1000).ToString(); //设置TTL为20000毫秒
            properties.Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.UtcTicks);
            properties.MessageId = Guid.NewGuid().ToString("N");

            _channel.BasicPublish(delayexchange, string.Empty, properties, sendBytes);
        }
    }
}