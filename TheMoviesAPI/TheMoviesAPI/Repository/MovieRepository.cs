using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TheMoviesAPI.Models;
using TheMoviesAPI.Repository.IRepository;

namespace TheMoviesAPI.Repository
{
    public class MovieRepository : IMoviesRepository
    {
        private readonly IMongoCollection<Movie> _moviesCollection;
        public MovieRepository(IOptions<MongoDBSettings> options)
        {
            MongoClient client = new MongoClient(options.Value.ConnectionUri);
            IMongoDatabase db = client.GetDatabase(options.Value.DatabaseName);
            _moviesCollection = db.GetCollection<Movie>(options.Value.CollectionName);
        }

        public async Task CreateMovie(Movie movie)
        {
            await _moviesCollection.InsertOneAsync(movie);
        }

        public async Task DeleteMovie(string id)
        {
            ObjectId objId = new(id);
            await _moviesCollection.FindOneAndDeleteAsync(m => m.Id == objId);
        }

        public async Task DeleteMovieByName(string name)
        {
           
            await _moviesCollection.FindOneAndDeleteAsync(m => m.Title == name);
        }

        public async Task<Movie> GetMovie(string id)
        {
            ObjectId objId = new(id);
            return await _moviesCollection.Find<Movie>(m => m.Id == objId).FirstOrDefaultAsync();
        }

        public async Task<Movie> GetMovieByName(string name)
        {
            return await _moviesCollection.Find<Movie>(m => m.Title == name).FirstOrDefaultAsync();
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _moviesCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateMovie(Movie movie)
        {
            await _moviesCollection.ReplaceOneAsync<Movie>(doc => doc.Title == movie.Title, movie) ;
        }

        
    }
}
