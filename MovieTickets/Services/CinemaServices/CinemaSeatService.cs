using MovieTickets.Models.Cinema;
using MovieTickets.ModelsDto.CinemaDto;
using MovieTickets.Repository.CinemaSeatRepo;
using MovieTickets.Services.CinemaServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services.CinemaSeatServices
{
    public class CinemaSeatService: ICinemaSeatService
    {
        private readonly ICinemaSeatRepository CinemaSeatRepo;
        public CinemaSeatService(ICinemaSeatRepository _CinemaSeatRepo)
        {
            CinemaSeatRepo = _CinemaSeatRepo;
        }

        //public async Task<CinemaSeat> CreateCinemaSeat(CinemaSeatModelDto CreateCinemaSeat) => await CinemaSeatRepo.CreateCinemaSeat(CreateCinemaSeat);
        public async Task<IEnumerable<CinemaSeat>> CreateCinemaSeat(CinemaSeatModelDto createCinemaSeat) => await CinemaSeatRepo.CreateCinemaSeat(createCinemaSeat);

        public async Task<CinemaSeat> DeleteCinemaSeat(int CinemaSeatID) => await CinemaSeatRepo.DeleteCinemaSeat(CinemaSeatID);

        public async Task<CinemaSeat> GetCinemaSeatByID(int CinemaSeatID) => await CinemaSeatRepo.GetCinemaSeatByID(CinemaSeatID);

        public async Task<IEnumerable<CinemaSeat>> GetCinemaSeats() => await CinemaSeatRepo.GetCinemaSeats();

        public async Task<CinemaSeat> UpdateCinemaSeat(CinemaSeatModelDto UpdateCinemaSeat, int CinemaSeatID) => await CinemaSeatRepo.UpdateCinemaSeat(UpdateCinemaSeat, CinemaSeatID);
    }
}
