using System.Collections.Generic;
using TT.Abp.Mall.Application.Addresses.Dtos;
using TT.Abp.Mall.Application.Products.Dtos;

namespace TT.Abp.Mall.Application.Clients.Dtos
{
    public class ProductOrderRequestDto
    {
        public AddressDto Address { get; set; }
        public List<ProductSkuDto> Skus { get; set; }

        public string Comment { get; set; }
    }
}