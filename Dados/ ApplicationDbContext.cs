using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;

namespace Dados
{
    public class  ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias {get; set;}

        public DbSet<Produto> Produtos {get; set;}


    }
}