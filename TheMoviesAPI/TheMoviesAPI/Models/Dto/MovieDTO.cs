using MongoDB.Bson;

namespace TheMoviesAPI.Models.Dto
{
    public class MovieDTO
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ReleaseDate { get; set; }
        public string UrlImg { get; set; }


    }
}
