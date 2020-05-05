using JetBrains.Annotations;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Products;

namespace TT.Abp.Mall.Application.Addresses.Dtos
{
    public class AddressCreateOrUpdateDto
    {
        [NotNull] public string RealName { get; set; }
        [NotNull] public string Phone { get; set; }
        [NotNull] public string LocationLabel { get; set; }
        [NotNull] public string LocationAddress { get; set; }
        public string NickName { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public MallEnums.LocationType LocationType { get; set; }
    }
}