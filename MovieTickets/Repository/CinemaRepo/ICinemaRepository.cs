using MovieTickets.Models.Cinema;
using MovieTickets.ModelsDto.CinemaDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Repository.CinemaRepo
{
    public interface ICinemaRepository
    {
        public Task<IEnumerable<Cinema>> GetCinemas();
        public Task<Cinema> GetCinemaByID(int CinemaID);
        public Task<Cinema> CreateCinema(CinemaModelDto CreateCinema);
        public Task<Cinema> UpdateCinema(CinemaModelDto UpdateCinema, int CinemaID);
        public Task<Cinema> DeleteCinema(int CinemaID);
    }
}
