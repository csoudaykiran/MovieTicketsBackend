using MovieTickets.Models.Movie;
using MovieTickets.ModelsDto.MovieDto;
using MovieTickets.ModelsDto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MovieTickets.Services.MovieService
{
    public interface IMovieService
    {
        public Task<IEnumerable<MovieWithGenreName>> GetMovies();
        public Task<MovieWithGenreName> GetMoviesByID(int MovieID);
        public Task<Movie> CreateMovie(CreateMovieModel Movies);
        public Task<Movie> UpdateMovie(UpdateMovieModel updateMovie);

        public Task<Movie> DeleteMovie(int MovieID);

    }
}
