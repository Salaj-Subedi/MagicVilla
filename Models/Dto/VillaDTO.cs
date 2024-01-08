using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla.Models.Dto
{
    public class VillaDTO
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int Occupancy { get; set; }

        public int SqFt { get; set; }

        public string Details { get; set; }

        [Required]
        public int Rate { get; set; }

        public string ImageUrl { get; set; }

        public string Amenity { get; set; }

    }
}
