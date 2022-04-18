using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AnimePlace.Models.InputModels;
using AnimePlace.Models;

namespace AnimePlace.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Anime> Animes { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Studio> Studios { get; set; }


    }
}