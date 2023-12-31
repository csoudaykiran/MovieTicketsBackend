using MovieTickets.Models.Show;
using MovieTickets.ModelsDto.ShowDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services.ShowsService
{
    public interface IShowSeatService
    {
        public Task<IEnumerable<ShowSeat>> getShowSeats();
        public Task<ShowSeat> GetShowSeatByID(int ShowSeatID);
        public Task<IEnumerable<ShowSeat>> getShowSeatsByShowID(int ShowID);

        public Task<ShowSeat> CreateShowSeat(ShowSeatDto createShowSeat);

        public Task<ShowSeat> UpdateShowSeat(ShowSeatDto updateShowSeat, int ShowSeatID);
        public Task<ShowSeat> DeleteShowSeat(int ShowSeatID);
    }
}
