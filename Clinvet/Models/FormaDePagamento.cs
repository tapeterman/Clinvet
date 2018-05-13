namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FormaDePagamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FormaDePagamento()
        {
            VendaServicoFormaDePagamento = new HashSet<VendaServicoFormaDePagamento>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendaServicoFormaDePagamento> VendaServicoFormaDePagamento { get; set; }
    }
}
