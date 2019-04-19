using Volo.Abp;

namespace TT.SoMall
{
    public abstract class SoMallApplicationTestBase : AbpIntegratedTest<SoMallApplicationTestModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
