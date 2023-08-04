using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class NumeroVillaUpdateDto
    {
      
        public int VillaNumero { get; set; }

        [Required]
        public int VillaId { get; set; }

        public string DetalleEspecial { get; set; }

    }

}

