namespace TT.Abp.WeixinManagement.Application.Dtos
{
    public class CreateShopDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string LogoImage { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }
    }
}