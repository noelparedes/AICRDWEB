using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICRDWEB.Models
{
    [Table("Asociaciones")]
    public class Asociacion
    {
        [Display(Name = "Asociacion")]
        [Key]
        public int IdAsociacion { get; set; }


        [Display(Name = "Nombre de la Asociacion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(120, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string LogoAsociacion { get; set; }

        [Display(Name = "Nombre de la Asociacion")]
        //[Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string AlternateText { get; set; }



        [Display(Name = "Nombre de la Asociacion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(30, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string NombreAsociacion { get; set; }

        [Display(Name = "Lema Asociasion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(25, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string LemaAsociacion { get; set; }


    }
}
