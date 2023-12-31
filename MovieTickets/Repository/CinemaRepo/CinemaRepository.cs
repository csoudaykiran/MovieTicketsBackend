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

namespace MovieTickets.Repository.CinemaRepo
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly MovieTicketsDbContext context;
        private IMapper mapper;
        public CinemaRepository(MovieTicketsDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public async Task<Cinema> CreateCinema(CinemaModelDto CreateCinema)
        {
            var createModel = mapper.Map<Cinema>(CreateCinema);
            createModel.City = CreateCinema.City;
            await context.Cinemas.AddAsync(createModel);
            await context.SaveChangesAsync();
            return createModel;
        }

        public async Task<Cinema> DeleteCinema(int CinemaID)
        {
            var deleteCinema = await context.Cinemas.Where(c => c.CinemaID == CinemaID).SingleOrDefaultAsync();
            if (deleteCinema != null)
            {
                context.Cinemas.Remove(deleteCinema);

                await context.SaveChangesAsync();
            }
            return deleteCinema;
        }

        public async Task<Cinema> GetCinemaByID(int CinemaID)
        {
            return await context.Cinemas.Include(ch => ch.CinemaHalls).Where(c => c.CinemaID == CinemaID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cinema>> GetCinemas()
        {
            return await context.Cinemas.Include(ch => ch.CinemaHalls).ToListAsync();
        }

        public async Task<Cinema> UpdateCinema(CinemaModelDto UpdateCinema, int CinemaID)
        {
            var updatedCinema = mapper.Map<Cinema>(UpdateCinema);
            var Cinema = await context.Cinemas.FindAsync(CinemaID);
            if (Cinema == null)
            {
                throw new AppException("Genre not found");

            }
            if (!string.IsNullOrWhiteSpace(updatedCinema.Name))
            {
                Cinema.Name = updatedCinema.Name;
            }
            if (!string.IsNullOrWhiteSpace(updatedCinema.City))
            {
                Cinema.City = updatedCinema.City;
            }
            if (!string.IsNullOrWhiteSpace(updatedCinema.TotalCinemaHalls.ToString()))
            {
                Cinema.TotalCinemaHalls = context.CinemaHalls.Where(ch => ch.CinemaID == CinemaID).ToList().Count();
            }

            context.Cinemas.Update(Cinema);
            await context.SaveChangesAsync();

            return Cinema;

        }
    }
}

