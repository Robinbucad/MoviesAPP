using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TheMoviesAPI.Models
{
    public class Movie
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ReleaseDate { get; set; }
        public string UrlImg { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
