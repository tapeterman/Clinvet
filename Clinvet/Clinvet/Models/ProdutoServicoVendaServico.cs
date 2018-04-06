using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinvet.Models
{
    public partial class ProdutoServicoVendaServico
    {
        [Key]
        public long IdProdutoServicoVendaServico { get; set; }
        public long IdProdutoServico { get; set; }
        public long IdVendaServico { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal ValorProduto { get; set; }

        public ProdutoServico IdProdutoServicoNavigation { get; set; }
        public VendaServico IdVendaServicoNavigation { get; set; }
    }
}
