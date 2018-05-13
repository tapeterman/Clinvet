namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Funcionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionario()
        {
            VendasServicos = new HashSet<VendaServico>();
        }

        public long Id { get; set; }

        [Display(Name = "Usuario")]
        public long IdUsuario { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Título de Eleitor")]
        public string TituloDeEleitor { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "RG")]
        public string Rg { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "PIS")]
        public string Pis { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Função")]
        public string Funcao { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Rua")]
        public string Rua { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual Usuario Usuarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendaServico> VendasServicos { get; set; }
    }
}
