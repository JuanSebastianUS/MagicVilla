using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class VillaDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public String Nombre { get; set; }

        public string Detalle { get; set; }

        [Required]

        public int Tarifa { get; set; }


        public int Ocupantes {  get; set; }

        public int MetrosCuadrados { get; set; }

        public string ImagenUrl { get; set; }

        public string Amenidad { get; set; }


    }
}
