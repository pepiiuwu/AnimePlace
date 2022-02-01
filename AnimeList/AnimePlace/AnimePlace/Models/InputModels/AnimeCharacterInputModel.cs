using System.ComponentModel.DataAnnotations;

namespace AnimePlace.Models.InputModels
{
    public class AnimeCharacterInputModel
    {
        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MinLength(20)]
        [MaxLength(500)]
        [Required]
        public string Details { get; set; }
    }
}
