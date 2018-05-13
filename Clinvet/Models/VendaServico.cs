namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VendaServico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VendaServico()
        {
            ProdutoServicoVendaServico = new HashSet<ProdutoServicoVendaServico>();
            VendaServicoFormaDePagamento = new HashSet<VendaServicoFormaDePagamento>();
        }

        public long Id { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Valor Total")]
        [DataType(DataType.Currency)]
        public decimal ValorTotal { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Funcionario")]
        public long IdFuncionario { get; set; }

        [Display(Name = "Cliente")]
        public long IdCliente { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data do Serviço")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataServico { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdutoServicoVendaServico> ProdutoServicoVendaServico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendaServicoFormaDePagamento> VendaServicoFormaDePagamento { get; set; }
    }
}
