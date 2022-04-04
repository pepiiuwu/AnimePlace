namespace AnimePlace.Models.ViewModels
{
    public class AnimesListViewModel
    {
        public IEnumerable<AnimeListViewModel> Animes { get; set; }

        public int PageNumber { get; set; }
    }
}
