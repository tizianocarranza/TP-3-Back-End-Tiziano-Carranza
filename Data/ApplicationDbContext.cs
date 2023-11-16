using ArticulosAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ArticulosAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base( options  )
        {

        }

        public DbSet<Articulos> Articulos { get; set; }
    }
}
