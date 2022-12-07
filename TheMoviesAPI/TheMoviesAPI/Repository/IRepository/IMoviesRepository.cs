using TheMoviesAPI.Models;

namespace TheMoviesAPI.Repository.IRepository
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> GetMovies();
        Task<Movie> GetMovie(string id);

        Task<Movie> GetMovieByName(string name);

        Task CreateMovie(Movie movie);

        Task UpdateMovie(Movie movie);
        Task DeleteMovie(string id);
        Task DeleteMovieByName(string name);

    }
}
