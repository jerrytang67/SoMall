using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TT.Abp.Mall.Application.Pays;
using TT.Abp.Mall.Events.Pays;
using TT.RabbitMQ;

namespace TT.Abp.Mall.Liseners
{
    public class PayOrderLisener : DeadLetterListener
    {
        private readonly IMediator _mediator;

        public PayOrderLisener(
            IOptions<RabbitMqOptions> optionsAccessor,
            ILogger<DeadLetterListener> logger,
            IMediator mediator
        ) : base(optionsAccessor, logger)
        {
            _mediator = mediator;
        }

        protected override async Task<bool> ProcessAsync(string message)
        {
            try
            {
                var item = JsonConvert.DeserializeObject<dynamic>(message);
                if (item.Type == "PayOrder")
                {
                    var str = item.Data.ToString();
                    var data = JsonConvert.DeserializeObject<PayOrderDto>(item.Data.ToString());

                    if (data != null)
                    {
                        await _mediator.Publish(new PayOrderTimeoutEvent(data.Id));
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return false;
            }
        }
    }
}