namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProdutoServicoAgendamentoConsultas
    {
        [Key]
        public long IdProdutoServicoAgendamentoConsulta { get; set; }

        public long IdProdutoServico { get; set; }

        public long IdAgendamentoConsulta { get; set; }

        public virtual AgendamentoConsulta Agendamentoconsulta { get; set; }

        public virtual ProdutoServico ProdutoServico { get; set; }
    }
}
