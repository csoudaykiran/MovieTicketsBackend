using MovieTickets.Models.Cinema;
using MovieTickets.ModelsDto.CinemaDto;
using MovieTickets.Repository.CinemaRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services.CinemaServices
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository cinemaRepo;
        public CinemaService(ICinemaRepository _cinemaRepo)
        {
            cinemaRepo = _cinemaRepo;
        }

        public async Task<Cinema> CreateCinema(CinemaModelDto CreateCinema) => await cinemaRepo.CreateCinema(CreateCinema);

        public async Task<Cinema> DeleteCinema(int CinemaID) => await cinemaRepo.DeleteCinema(CinemaID);

        public async Task<Cinema> GetCinemaByID(int CinemaID) => await cinemaRepo.GetCinemaByID(CinemaID);

        public async Task<IEnumerable<Cinema>> GetCinemas() => await cinemaRepo.GetCinemas();

        public async Task<Cinema> UpdateCinema(CinemaModelDto UpdateCinema, int CinemaID) => await cinemaRepo.UpdateCinema(UpdateCinema, CinemaID);
    }
}
