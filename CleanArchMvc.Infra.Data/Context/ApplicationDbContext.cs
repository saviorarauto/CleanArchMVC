using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Lembrando que o applyconfiguration serve para que o sistema rastreie todas classes do meu sistema
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            // Se eu não utilizasse essa ferramenta, eu teria que fazer classe por classe:
            //builder.ApplyConfiguration<Category>;
            //builder.ApplyConfiguration<Product>; e assim sucessivamente...
        }
    }
}
