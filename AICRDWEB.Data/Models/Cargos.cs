using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICRDWEB.Models
{
    [Table("Cargos")]
    public class Cargos
    {
        [Display(Name = "Cargo")]
        [Key]
        public int IdCargo { get; set; }

        [Display(Name = "Nombre del Cargo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string Cargo { get; set; }
    }
}
