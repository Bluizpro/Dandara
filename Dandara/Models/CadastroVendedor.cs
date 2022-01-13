using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dandara.Models
{
    public class CadastroVendedor
    {
        [Key]
        [ForeignKey("LoginVendedor")]
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string mei { get; set; }
        public string Cnpj { get; set; }
        public string RG { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public string Estado { get; set; }
        public string Foto { get; set; }
        public string CartaoCredito { get; set; }
        public string LinkVideo { get; set; }
        public string DescriçãoAtividade { get; set; }
        public virtual LoginVendedor LoginVendedor { get; set; }

        public ICollection<VendedorProduto> VendedorProduto { get; set; }
    }
}
