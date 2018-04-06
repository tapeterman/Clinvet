using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinvet.Models
{
    public partial class VendaServicoFormaDePagamento
    {
        [Key]
        public long IdVendaServicoFormaDePagamento { get; set; }
        public long IdVendaServico { get; set; }
        public long IdFormaDePagamento { get; set; }

        public FormaDePagamento IdFormaDePagamentoNavigation { get; set; }
        public VendaServico IdVendaServicoNavigation { get; set; }
    }
}
