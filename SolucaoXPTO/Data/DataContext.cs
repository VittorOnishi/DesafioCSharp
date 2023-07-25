using Microsoft.EntityFrameworkCore;
using SolucaoXPTO.Models;

namespace SolucaoXPTO.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<PedidoDeCompra> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<SolucaoXPTO.Models.Cargo>? Cargo { get; set; }
 
    }
}
