using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dandara.Models
{
    public class VendedorProduto
    {
        [Key]
        public int id { get; set; }
        public int VendedorId { get; set; }
        public CadastroVendedor CadastroVendedor { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
