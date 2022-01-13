using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dandara.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<CadastroVendedor> CadastroVendedor { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<VendedorProduto> vendedorProduto { get; set; }
        public DbSet<LoginVendedor> LoginVendedor { get; set; }

        public DbSet<LoginCliente> LoginCliente { get; set; }
        public DbSet<ClienteCadastro> ClienteCadastro { get; set; }
    
    }
}
