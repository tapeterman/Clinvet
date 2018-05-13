namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ContasAPagar
    {
        public long Id { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Data { get; set; }

        [Display(Name = "Valor")]
        //[DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Valor { get; set; }

        [Display(Name = "Fornecedor")]
        public long IdFornecedor { get; set; }

        [Display(Name = "Tipo de Conta")]
        public long IdTipoDeConta { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        public virtual TipoDeConta TipoDeConta { get; set; }
    }
}
