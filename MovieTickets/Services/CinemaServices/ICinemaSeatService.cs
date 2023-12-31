using MovieTickets.Models.Cinema;
using MovieTickets.ModelsDto.CinemaDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services.CinemaServices
{
    public interface ICinemaSeatService
    {
        public Task<IEnumerable<CinemaSeat>> GetCinemaSeats();
        public Task<CinemaSeat> GetCinemaSeatByID(int CinemaSeatID);
        //public Task<CinemaSeat> CreateCinemaSeat(CinemaSeatModelDto CreateCinemaSeat);
        Task<IEnumerable<CinemaSeat>> CreateCinemaSeat(CinemaSeatModelDto createCinemaSeat);
        public Task<CinemaSeat> UpdateCinemaSeat(CinemaSeatModelDto UpdateCinemaSeat, int CinemaSeatID);
        public Task<CinemaSeat> DeleteCinemaSeat(int CinemaSeatID);
    }
}
