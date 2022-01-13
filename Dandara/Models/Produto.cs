using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dandara.Models
{
    public class Produto
    {
        public string Email { get; set; }
        public string CPF { get; set; }
        public int id { get; set; }
        public string Nome { get; set; }
        public Double Preco { get; set; }
        public Double moeda { get; set; }
        public string Condicoesdepagamento { get; set; }
        public string condicaoeentrega { get; set; }
        public string videodosprodutos { get; set; }
        public string tamanho { get; set; }
        public string cores { get; set; }
        public string Descricaoproduto { get; set; }
        public string categoriaa { get; set; }
        public string categoriab { get; set; }
        public string categoriac { get; set; }
        public string categoriad { get; set; }
        public string categoriae { get; set; }
        public string categoriag { get; set; }
        public DateTime datavalidade { get; set; }
        public string contatovendendor { get; set; }
        public ICollection<VendedorProduto> vendedorProduto { get; set; }
    }
}
