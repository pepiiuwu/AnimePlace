using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimePlace.Models.InputModels
{
    public class CreateAnimeInputModel
    {
        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }
        [MinLength(15)]
        [MaxLength(500)]
        [Required]
        public string? Sypnosis { get; set; }
        [Range(1, 400)]
        [Required]
        public int? Episodes { get; set; }

        [Required]
        public string? Type { get; set; }

        public ICollection<AnimeCharacterInputModel> Characters { get; set; }

        [NotMapped]
        public IEnumerable<KeyValuePair<string, string>> TypeItems { get; set; }
    }
}
