namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Fornecedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fornecedor()
        {
            ContasAPagar = new HashSet<ContasAPagar>();
            FornecedorProdutoServico = new HashSet<FornecedorProdutoServico>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required]
        [StringLength(14)]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContasAPagar> ContasAPagar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FornecedorProdutoServico> FornecedorProdutoServico { get; set; }
    }
}
