namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Anamnese
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Diagnóstico")]
        public string Diagnostico { get; set; }

        [Required]
        [Display(Name = "Anamnese")]
        public string Anamnese1 { get; set; }

        [Required]
        [Display(Name = "Medicamentos")]
        public string Medicamentos { get; set; }

        [Required]
        [Display(Name = "Procedimentos Realizados")]
        public string ProcedimentosRealizados { get; set; }

        [Required]
        [Display(Name = "Ficha do Animal")]
        public long IdFichaAnimal { get; set; }

        public virtual FichaAnimal FichaAnimal { get; set; }
    }
}
