using MovieTickets.Models.Movie;
using MovieTickets.ModelsDto;
using MovieTickets.ModelsDto.MovieDto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Repository.MovieRepo
{
    public interface IMovieRepository
    {

        public Task<IEnumerable<MovieWithGenreName>> GetMovies();
        public Task<MovieWithGenreName> GetMoviesByID(int MovieID);

        public Task<Movie> CreateMovie(CreateMovieModel CreateMovie);
        public Task<Movie> UpdateMovie(UpdateMovieModel CreateMovie);

        
        public Task<Movie> DeleteMovie(int MovieID);
    }
}
