namespace Clinvet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Animal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animal()
        {
            FichaAnimal = new HashSet<FichaAnimal>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Raça")]
        public string Raca { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Peso ou Porte")]
        public string PesoOuPorte { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Espécie")]
        public string Especie { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Display(Name = "Cliente")]
        public long IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FichaAnimal> FichaAnimal { get; set; }
    }
}
