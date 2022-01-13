using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dandara.Models;

namespace Dandara.Data
{
    public class DandaraContext : DbContext
    {
        public DandaraContext (DbContextOptions<DandaraContext> options)
            : base(options)
        {
        }

        public DbSet<Dandara.Models.CadastroVendedor> CadastroVendedor { get; set; }

        public DbSet<Dandara.Models.ClienteCadastro> ClienteCadastro { get; set; }

        public DbSet<Dandara.Models.LoginCliente> LoginCliente { get; set; }

        public DbSet<Dandara.Models.LoginVendedor> LoginVendedor { get; set; }

        public DbSet<Dandara.Models.Produto> Produto { get; set; }

        public DbSet<Dandara.Models.VendedorProduto> VendedorProduto { get; set; }
    }
}
