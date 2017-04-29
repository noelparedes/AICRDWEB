using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICRDWEB.Models
{
    [Table("Miembros")]
    public class Miembros : Personas
    {
        [Display(Name = "Miembro")]
        [Key]
        public int IdMiembro { get; set; }

        [Display(Name = "Cargo")]
        public int IdCargo { get; set; }

        [Display(Name = "Asociacion")]
        public int IdAsociacion { get; set; }

        //[Display(Name = "Imagen del Miembro")]
        //public int IdImagen { get; set; }

        [Display(Name = "Iglesia")]
        public int IdIglesia { get; set; }

        [Display(Name = "Circuito")]
        public int IdCircuito { get; set; }

        public EstadoMiembro Estado { get; set; }

        [ForeignKey("IdCargo")]
        public virtual Cargos Cargo { get; set; }

        [ForeignKey("IdAsociacion")]
        public virtual Asociacion Asociasion { get; set; }

        //[ForeignKey("IdImagen")]
        //public virtual ImagenesMiembro imagen { get; set; }

        [ForeignKey("IdIglesia")]
        public virtual Iglesias Iglesia { get; set; }

        [ForeignKey("IdCircuito")]
        public virtual Circuitos Circuito { get; set; }


        public Miembros()
        {
            Estado = EstadoMiembro.Activo;
        }



    }
}
