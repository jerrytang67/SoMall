using AutoMapper;
using TT.SoMall.Products;

namespace TT.SoMall
{
    public class SoMallApplicationAutoMapperProfile : Profile
    {
        public SoMallApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            #region Products

            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductSpu, ProductSpuDto>();
            CreateMap<ProductSku, ProductSkuDto>();


            CreateMap<CreateUpdateCategoryDto, ProductCategory>();
            CreateMap<CreateUpdateSpuDto, ProductSpu>();
            CreateMap<CreateUpdateSkuDto, ProductSku>();

            #endregion

        }
    }
}
