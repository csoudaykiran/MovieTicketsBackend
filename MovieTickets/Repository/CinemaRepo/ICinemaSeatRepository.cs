using MovieTickets.Models.Cinema;
using MovieTickets.ModelsDto.CinemaDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Repository.CinemaSeatRepo
{
    public interface ICinemaSeatRepository
    {
        public Task<IEnumerable<CinemaSeat>> GetCinemaSeats();
        public Task<CinemaSeat> GetCinemaSeatByID(int CinemaSeatID);
        //public Task<CinemaSeat> CreateCinemaSeat(CinemaSeatModelDto CreateCinemaSeat);

        public Task<IEnumerable<CinemaSeat>> CreateCinemaSeat(CinemaSeatModelDto CreateCinemaSeat);

        public Task<CinemaSeat> UpdateCinemaSeat(CinemaSeatModelDto UpdateCinemaSeat, int CinemaSeatID);
        public Task<CinemaSeat> DeleteCinemaSeat(int CinemaSeatID);
    }
}
