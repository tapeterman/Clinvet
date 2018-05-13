namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FichaAnimal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FichaAnimal()
        {
            Anamnese = new HashSet<Anamnese>();
            Vacina = new HashSet<Vacina>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Peso ou Porte Antes do Procedimento")]
        public string PesoPorteAntesDosProcedimentos { get; set; }

        [Display(Name = "Animal")]
        public long IdAnimal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anamnese> Anamnese { get; set; }

        public virtual Animal Animal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacina> Vacina { get; set; }
    }
}
