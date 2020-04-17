using System;

namespace TT.Abp.Mall.Application.Orders.Dtos
{
    public class OrderPayRequestDto
    {
        public Guid OrderId { get; set; }
        
        public string Client { get; set; }
        public string openid { get; set; }
    }
}