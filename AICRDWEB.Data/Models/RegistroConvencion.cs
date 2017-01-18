using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICRDWEB.Models
{
    [Table("RegistroConvenciones")]
    public class RegistroConvencion : Personas
    {
        [Display(Name = "Registro")]
        [Key]
        public int IdRegistro { get; set; }

        [Display(Name = "Miembro")]
        public int? IdMiembro { get; set; }

        [Display(Name = "Circuitos")]
        public int? IdCircuitos { get; set; }

        [Display(Name = "Iglesia")]
        public int? IdIglesia { get; set; }

        [Display(Name = "Costo de Estadia")]
        public string Costo { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }

        public bool Exhonerado { get; set; }

        [StringLength(800, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string Observaciones { get; set; }


        [ForeignKey("IdMiembro")]
        public virtual Miembros Miembro { get; set; }

        [ForeignKey("IdCircuitos")]
        public virtual Circuitos Circuito { get; set; }

        [ForeignKey("IdIglesia")]
        public virtual Iglesias Iglesia { get; set; }







    }
}
