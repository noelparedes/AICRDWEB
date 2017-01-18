using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICRDWEB.Models
{
    [Table("Circuitos")]
    public class Circuitos
    {
        [Display(Name = "Circuito")]
        [Key]
        public int IdCircuito { get; set; }

        [Display(Name = "Region")]
        public int IdRegion { get; set; }


        [Display(Name = "Iglesia")]
        public int IdIglesia { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string NombreCircuito { get; set; }


        [StringLength(100, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string Descripcion { get; set; }

        [ForeignKey("IdRegion")]
        public virtual Region Region { get; set; }


        [ForeignKey("IdIglesia")]
        public virtual Iglesias Iglesia { get; set; }



    }
}
