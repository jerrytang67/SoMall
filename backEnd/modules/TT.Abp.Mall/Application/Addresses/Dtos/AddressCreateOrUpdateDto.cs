using JetBrains.Annotations;
using TT.Abp.Mall.Domain.Products;

namespace TT.Abp.Mall.Application.Addresses
{
    public class AddressCreateOrUpdateDto
    {
        [NotNull] public string RealName { get; set; }
        [NotNull] public string Phone { get; set; }
        [NotNull] public string LocationLable { get; set; }
        [NotNull] public string LocationAddress { get; set; }
        public string NickName { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public LocationType LocationType { get; set; }
    }
}