using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICRDWEB.Models
{

    [Table("Regiones")]
    public class Region
    {
        [Display(Name = "Region")]
        public int IdRegion { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(80, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string NombreRegion { get; set; }





    }
}
