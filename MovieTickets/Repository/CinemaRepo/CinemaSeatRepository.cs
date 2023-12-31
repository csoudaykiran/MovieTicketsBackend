using AutoMapper;
using MovieTickets.Models.Cinema;
using MovieTickets.ModelsDto.CinemaDto;
using MovieTickets.Environment;
using MovieTickets.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Repository.CinemaSeatRepo
{
    public class CinemaSeatRepository : ICinemaSeatRepository
    {
        private readonly MovieTicketsDbContext context;
        private IMapper mapper;
        public CinemaSeatRepository(MovieTicketsDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public async Task<IEnumerable<CinemaSeat>> CreateCinemaSeat(CinemaSeatModelDto createCinemaSeat)
        {
            List<CinemaSeat> createdSeats = new List<CinemaSeat>();

            for (int seatNumber = createCinemaSeat.StartSeatNumber; seatNumber <= createCinemaSeat.EndSeatNumber; seatNumber++)
            {
                var createModel = new CinemaSeat
                {
                    SeatNumber = seatNumber,
                    type = createCinemaSeat.type,
                    CinemaHallID = createCinemaSeat.CinemaHallID
                };

                await context.CinemaSeats.AddAsync(createModel);
                createdSeats.Add(createModel);
            }

            await context.SaveChangesAsync();
            return createdSeats;
        }


        public async Task<CinemaSeat> DeleteCinemaSeat(int CinemaSeatID)
        {
            var deleteCinemaSeat = await context.CinemaSeats.Where(c => c.CinemaSeatID == CinemaSeatID).SingleOrDefaultAsync();
            if (deleteCinemaSeat != null)
            {
                context.CinemaSeats.Remove(deleteCinemaSeat);

                await context.SaveChangesAsync();
            }
            return deleteCinemaSeat;
        }

        public async Task<CinemaSeat> GetCinemaSeatByID(int CinemaSeatID)
        {
            return await context.CinemaSeats.Where(c => c.CinemaSeatID == CinemaSeatID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CinemaSeat>> GetCinemaSeats()
        {
            return await context.CinemaSeats.ToListAsync();
        }

        public async Task<CinemaSeat> UpdateCinemaSeat(CinemaSeatModelDto UpdateCinemaSeat, int CinemaSeatID)
        {
            var updatedCinemaSeat = mapper.Map<CinemaSeat>(UpdateCinemaSeat);
            var CinemaSeat = await context.CinemaSeats.FindAsync(CinemaSeatID);
            if (CinemaSeat == null)
            {
                throw new AppException("Genre not found");

            }
            if (!string.IsNullOrWhiteSpace(updatedCinemaSeat.SeatNumber.ToString()))
            {
                CinemaSeat.SeatNumber = updatedCinemaSeat.SeatNumber;
            }
            if (!string.IsNullOrWhiteSpace(updatedCinemaSeat.type.ToString()))
            {
                CinemaSeat.type = updatedCinemaSeat.type;
            }
            if (!string.IsNullOrWhiteSpace(updatedCinemaSeat.CinemaHallID.ToString()))
            {
                CinemaSeat.CinemaHallID = updatedCinemaSeat.CinemaHallID;
            }


            context.CinemaSeats.Update(CinemaSeat);
            await context.SaveChangesAsync();

            return CinemaSeat;

        }
    }
}
