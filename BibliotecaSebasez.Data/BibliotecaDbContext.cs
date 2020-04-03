using BibliotecaSebasez.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BibliotecaSebasez.Data
{
    public class BibliotecaDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public BibliotecaDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Autor> Autor { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Libro> Libro { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Autor>().ToTable("Autor");
            builder.Entity<Categoria>().ToTable("Categoria");
            builder.Entity<Libro>().ToTable("Libro");
        }
    }
}
