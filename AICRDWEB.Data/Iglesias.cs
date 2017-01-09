using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICRDWEB.Models
{

    [Table("Iglesias")]
    public class Iglesias
    {
        [Display(Name = "Iglesia")]
        public int IdIglesia { get; set; }

        [Display(Name = "Circuito")]
        public int IdCircuito { get; set; }


        [Display(Name = "Iglesia")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(30, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string NombreIglesia { get; set; }

        [Display(Name = "Descripcion")]
        [StringLength(150, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string Descripcion { get; set; }

        [Display(Name = "Cantidad de Miembros")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CantidadMiembro { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Direccion { get; set; }


        //[Display(Name = "Direccion")]
        //[Required(ErrorMessage = "El campo {0} es requerido")]
        //public string Direccion { get; set; }

        [ForeignKey("IdCircuito")]
        public virtual Circuitos Circuito { get; set; }


    }
}
