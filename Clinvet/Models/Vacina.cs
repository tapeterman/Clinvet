namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vacina
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Lote")]
        public string Lote { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Fornecedor")]
        public string Fornecedor { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Validade")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Validade { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Custo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###,##0.00}")]
        public decimal Custo { get; set; }

        [Display(Name = "Ficha Animal")]
        public long IdFichaAnimal { get; set; }

        [Display(Name = "Tipo de Vacina")]
        public long IdTiposDeVacina { get; set; }

        public virtual FichaAnimal FichaAnimal { get; set; }

        public virtual TiposDeVacina TiposDeVacina { get; set; }
    }
}
