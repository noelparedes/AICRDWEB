using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AICRDWEB.Models
{
    [Table("ImagenesMiembro")]
    public class ImagenesMiembro
    {
        [Display(Name = "Imagen")]
        [Key]
        public int IdImagen { get; set; }


        //el nombre de la imagen sera el nombre del archivo
        [Display(Name = "Nombre de la Imagen")]
        [StringLength(255, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string NombreImagen { get; set; }


        public int Size { get; set; }

        public byte[] ImageData { get; set; }



    }
}
