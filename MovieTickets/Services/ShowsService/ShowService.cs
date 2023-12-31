using AutoMapper;
using MovieTickets.Models.Movie;
using MovieTickets.Models.Show;
using MovieTickets.ModelsDto.ShowDto;
using MovieTickets.Repository.CinemaRepo;
using MovieTickets.Repository.ShowRepo;
using MovieTickets.Services.MovieService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services.ShowsService
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository showRepo;
        private IMapper mapper;

        public ShowService(IShowRepository _showRepo, IMapper _mapper)
        {
            showRepo = _showRepo;
            mapper = _mapper;
        }

        public async Task<Show> CreateShow(ShowDetailsDto CreateShow) => await showRepo.CreateShow(CreateShow);

        public async Task<Show> UpdateShow(ShowDetailsDto UpdateShow, int ShowID) => await showRepo.UpdateShow(UpdateShow,ShowID);

        public async Task<IEnumerable<Show>> GetShows() => await showRepo.GetShows();

        public async Task<Show> GetShowByID(int CinemaID) => await showRepo.GetShowByID(CinemaID);
    

        public async Task<Show> DeleteShow(int ShowID) => await showRepo.DeleteShow(ShowID);

        public async Task<IEnumerable<Show>> GetShowByMovieID(int MovieID) => await showRepo.GetShowByMovieID(MovieID);
    }
}
