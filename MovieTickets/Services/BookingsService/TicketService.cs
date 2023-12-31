using MovieTickets.Models.Bookings;
using MovieTickets.Repository.BookingRepo;
using MovieTickets.Repository.MovieRepo;
using MovieTickets.Repository.PaymentRepo;
using MovieTickets.Services.MovieService;
using MovieTickets.Repository.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services.BookingsService
{
    public class TicketService : ITicketService
    {
        public IBookingRepository bookingRepo;
        public IMovieRepository movieRepo;
        public IUserRepository userRepo;
        public IPaymentRepository paymentRepo;
        public TicketService(
            IBookingRepository _bookingRepo,
            IMovieRepository movieRepo,
            IUserRepository userRepo,
            IPaymentRepository paymentRepo
            ) // Dependency Injection. 
        {

        }
        public Task<IEnumerable<Ticket>> getTickets(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
