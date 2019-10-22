using System.Threading.Tasks;

namespace TT.SoMall.Data
{
    public interface ISoMallDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
