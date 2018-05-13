namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AgendamentoConsulta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AgendamentoConsulta()
        {
            ProdutoServicoAgendamentoConsultas = new HashSet<ProdutoServicoAgendamentoConsultas>();
        }

        public long Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [Display(Name = "Data do Agendamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataDeAgendamento { get; set; }

        [Required]
        [StringLength(255)]
        [Column(TypeName = "text")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public long IdCliente { get; set; }


        public virtual Cliente Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdutoServicoAgendamentoConsultas> ProdutoServicoAgendamentoConsultas { get; set; }
    }
}