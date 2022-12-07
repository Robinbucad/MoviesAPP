using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TheMoviesAPI.Models;
using TheMoviesAPI.Models.Dto;
using TheMoviesAPI.Repository.IRepository;

namespace TheMoviesAPI.Controllers
{
    [ApiController]
    [Route("api/v1/movies")]
    public class MoviesController : ControllerBase
    {

        private readonly IMoviesRepository _movieRepository;
        protected APIResponse _response;
        private readonly IMapper _mapper;

        public MoviesController(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _movieRepository = moviesRepository;
            _response = new();
            _mapper = mapper;
        }

        [HttpGet(Name = "GetMovies")]
        public async Task<ActionResult<APIResponse>> GetMovies()
        {
            IEnumerable<Movie> movies = await _movieRepository.GetMovies();

            _response.Result = _mapper.Map<List<MovieDTO>>(movies);
            _response.StatusCode = HttpStatusCode.OK;

            return Ok(_response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetSingelMovie(string id)
        {
            try
            {
                if (id == "0")
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Id can not be 0");
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Movie movie = await _movieRepository.GetMovie(id);

                if (movie == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Movie doesn't exist");
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<MovieDTO>(movie);
                return Ok(_response);
                
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
            }

            return _response;
        }

        [HttpGet("name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetMovieByName(string name)
        {
            try
            {
                if (name.Length == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid name");
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Movie movie = await _movieRepository.GetMovieByName(name);

                if (movie == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Movie doesn't exist");
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<MovieDTO>(movie);
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
            }

            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateMovie([FromBody] CreateMovieDTO movieDto)
        {
            try
            {
                if (movieDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Error movie can not be null");
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Movie checkIfExist = await _movieRepository.GetMovieByName(movieDto.Title);

                if(checkIfExist != null)
                {
                    _response.StatusCode = HttpStatusCode.UnprocessableEntity;
                    _response.ErrorMessages.Add("Error movie already exists");
                    _response.IsSuccess = false;
                    return UnprocessableEntity(_response);
                }

                Movie model = _mapper.Map<Movie>(movieDto);
                await _movieRepository.CreateMovie(model);

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<MovieDTO>(model);

                return CreatedAtRoute("GetMovies",_response);   

            }catch(Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess=false;
                _response.ErrorMessages.Add(ex.Message);
            }

            return _response;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> UpdateMovie([FromBody] UpdateMovieDTO movieDto)
        {
            try
            {
                if (movieDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Error movie can not be null");
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                Movie model = _mapper.Map<Movie>(movieDto);

                Movie movie = await _movieRepository.GetMovieByName(movieDto.Title);
                if (movie == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Movie doesn't exist");
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                model.CreatedDate = movie.CreatedDate;
                model.Id= movie.Id;
                await _movieRepository.UpdateMovie(model);

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<MovieDTO>(model);

                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
            }

            return _response;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteMovie(string id)
        {
            try
            {
                if(id == "0")
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Id can not be 0");
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Movie movie = await _movieRepository.GetMovie(id);

                if(movie == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Movie doesn't exist");
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                await _movieRepository.DeleteMovie(id);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);

            }catch(Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
            }

            return _response;
        }

        [HttpDelete("name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteMovieByName(string name)
        {
            try
            {
                if (name.Length == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid name");
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Movie movie = await _movieRepository.GetMovieByName(name);

                if (movie == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Movie doesn't exist");
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                await _movieRepository.DeleteMovieByName(name);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
            }

            return _response;
        }
    }
}