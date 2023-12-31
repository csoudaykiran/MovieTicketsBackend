using MovieTickets.Models.Show;
using MovieTickets.ModelsDto.ShowDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Repository.ShowRepo
{
    public interface IShowRepository
    {
        public Task<IEnumerable<Show>> GetShows();
        public Task<Show> GetShowByID(int CinemaID);
        public Task<IEnumerable<Show>> GetShowByMovieID(int MovieID);

        public Task<Show> CreateShow(ShowDetailsDto CreateShow);
        public Task<Show> UpdateShow(ShowDetailsDto UpdateShow, int ShowID);
        public Task<Show> DeleteShow(int ShowID);
    }
}
