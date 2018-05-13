namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProdutoServico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProdutoServico()
        {
            FornecedorProdutoServico = new HashSet<FornecedorProdutoServico>();
            ProdutoServicoAgendamentoConsultas = new HashSet<ProdutoServicoAgendamentoConsultas>();
            ProdutoServicoVendaServico = new HashSet<ProdutoServicoVendaServico>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Preço de Venda")]
        [DataType(DataType.Currency)]
        public decimal PrecoDeVenda { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Custo")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###,##0.00}")]
        public decimal PrecoDeCompra { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Validade")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Validade { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Lote")]
        public string Lote { get; set; }

        [Display(Name = "Tipo")]
        public long IdTipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FornecedorProdutoServico> FornecedorProdutoServico { get; set; }

        public virtual Tipo Tipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdutoServicoAgendamentoConsultas> ProdutoServicoAgendamentoConsultas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdutoServicoVendaServico> ProdutoServicoVendaServico { get; set; }
    }
}
