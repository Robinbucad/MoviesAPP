namespace TheMoviesAPI.Models.Dto
{
    public class UpdateMovieDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ReleaseDate { get; set; }
        public string UrlImg { get; set; }

        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
