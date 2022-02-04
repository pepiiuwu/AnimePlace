using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimePlace.Models.InputModels
{

    [Keyless]
    public class CreateAnimeInputModel
    {

        [MinLength(5)]
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }
        [MinLength(5)]
        [MaxLength(500)]
        [Required]
        public string? Sypnosis { get; set; }
        [Range(1, 400)]
        [Required]
        public int? Episodes { get; set; }

        [Required]
        public string? Type { get; set; }

        //To make it so you can add the characters on anime creation and/or add them eventually
        //public ICollection<AnimeCharacterInputModel> Characters { get; set; }
    }
}
