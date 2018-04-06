using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinvet.Models
{
    public partial class ProdutoServicoAgendamentoConsultas
    {
        [Key]
        public long IdProdutoServicoAgendamentoConsulta { get; set; }
        public long IdProdutoServico { get; set; }
        public long IdAgendamentoConsulta { get; set; }

        public AgendamentoConsulta IdAgendamentoConsultaNavigation { get; set; }
        public ProdutoServico IdProdutoServicoNavigation { get; set; }
    }
}
