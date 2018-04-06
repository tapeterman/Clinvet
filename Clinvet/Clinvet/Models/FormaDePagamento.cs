using System;
using System.Collections.Generic;

namespace Clinvet.Models
{
    public partial class FormaDePagamento
    {
        public FormaDePagamento()
        {
            VendaServicoFormaDePagamento = new HashSet<VendaServicoFormaDePagamento>();
        }

        public long Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<VendaServicoFormaDePagamento> VendaServicoFormaDePagamento { get; set; }
    }
}
