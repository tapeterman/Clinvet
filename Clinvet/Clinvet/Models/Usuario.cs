using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinvet.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        [Key]
        public string Login { get; set; }
        public string Senha { get; set; }

        public ICollection<Funcionario> Funcionario { get; set; }
    }
}
