using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinvet.Models
{
    [Table("funcionario")]
    public partial class Funcionario
    {
        
        public Funcionario()
        {
            VendaServico = new HashSet<VendaServico>();
        }

        [Key]
        public long Id { get; set; }

  
        public string Login { get; set; }
        public string Nome { get; set; }
        public string TituloDeEleitor { get; set; }
        public string Rg { get; set; }

        public string Cpf { get; set; }

        public string Pis { get; set; }

       
        public string Funcao { get; set; }

        public string Telefone { get; set; }

        public string Rua { get; set; }


        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Cep { get; set; }

        public string Email { get; set; }

        public Usuario login { get; set; }
        public ICollection<VendaServico> VendaServico { get; set; }
    }
}
