using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dandara.Models
{
    public class LoginVendedor
    {
        [Key]
        public string Email { get; set; }
        public string Senha { get; set; }
        public virtual CadastroVendedor CadastroVendedor { get; set; }
    }
}
