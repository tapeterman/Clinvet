namespace Clinvet.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Funcionarios = new HashSet<Funcionario>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
