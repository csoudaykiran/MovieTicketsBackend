using MovieTickets.Models.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services.BookingsService
{
    public interface ITicketService
    {
        public Task<IEnumerable<Ticket>> getTickets(int userID);
    }
}
