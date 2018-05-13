namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProdutoServicoVendaServico
    {
        [Key]
        public long IdProdutoServicoVendaServico { get; set; }

        public long IdProdutoServico { get; set; }

        public long IdVendaServico { get; set; }

        public int QuantidadeProduto { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Valor Unitário")]
        [DataType(DataType.Currency)]
        public decimal ValorProduto { get; set; }

        public virtual ProdutoServico ProdutoServico { get; set; }

        public virtual VendaServico VendaServico { get; set; }
    }
}
