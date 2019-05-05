using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TT.WeiXinMiddleware;

namespace TT.SoMall.WeiXinHandler
{
    public class SoMallWeiXinProvider : WeiXinProvide, IWeiXinProvider
    {
        public SoMallWeiXinProvider(IMediator mediator) : base(mediator)
        {
        }

        public override async Task OnSubscribe(WeiXinContext context)
        {
            context.HttpContext.Response.StatusCode = 200;
            context.HttpContext.Response.ContentType = "text/plain";


            var result = await _mediator.Send(new Ping(context));
            //await context.HttpContext.Response.WriteAsync(result);
            //await Task.CompletedTask;
        }

    }
}