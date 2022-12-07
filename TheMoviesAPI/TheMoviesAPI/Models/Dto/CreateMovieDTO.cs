namespace TheMoviesAPI.Models.Dto
{
    public class CreateMovieDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ReleaseDate { get; set; }
        public string UrlImg { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
