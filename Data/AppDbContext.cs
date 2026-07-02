using Microsoft.EntityFrameworkCore;
using UniGymFitness.Models;

namespace UniGymFitness.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Plano> Planos { get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}