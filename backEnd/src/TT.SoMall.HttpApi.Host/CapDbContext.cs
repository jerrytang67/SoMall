using Microsoft.EntityFrameworkCore;

namespace TT.SoMall
{
    public class CapDbContext : DbContext
    {
        public const string ConnectionString = "Server=.;Database=captest;User Id=sa;Password=hiue234Dfdf";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}