namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VendaServicoFormaDePagamento
    {
        [Key]
        public long IdVendaServicoFormaDePagamento { get; set; }

        public long IdVendaServico { get; set; }

        public long IdFormaDePagamento { get; set; }

        public virtual FormaDePagamento FormaDePagamento { get; set; }

        public virtual VendaServico VendaServico { get; set; }
    }
}
