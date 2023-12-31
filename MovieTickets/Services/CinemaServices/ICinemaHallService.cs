using MovieTickets.Models.Cinema;
using MovieTickets.ModelsDto.CinemaDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services.CinemaServices
{
    public interface ICinemaHallService
    {
        public Task<IEnumerable<CinemaHall>> GetCinemaHalls();
        public Task<CinemaHall> GetCinemaHallByID(int CinemaHallID);
        public Task<CinemaHall> CreateCinemaHall(CinemaHallDto CreateCinemaHall);
        public Task<CinemaHall> UpdateCinemaHall(CinemaHallDto UpdateCinemaHall, int CinemaHallID);
        public Task<CinemaHall> DeleteCinemaHall(int CinemaHallID);
    }
}
