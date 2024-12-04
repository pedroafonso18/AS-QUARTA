using CadastroPedidosFornecedores.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPedidosFornecedores.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
