namespace TT.RabbitMQ
{
    public class RabbitMqOptions
    {
        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public string HostName { get; set; } = "127.0.0.1";
        public int Port { get; set; } = 5672;
        public string QueryName { get; set; } = "DefaultQuery";

        public string DelayExchangeName { get; set; }
        public string DelayWorkExchangeName { get; set; }

        public string DelayWorkQueryName { get; set; }
    }
}