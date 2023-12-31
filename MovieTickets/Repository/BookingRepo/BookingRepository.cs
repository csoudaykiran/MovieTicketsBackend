using AutoMapper;
using MovieTickets.Models.Bookings;
using MovieTickets.ModelsDto.BookingDto;
using MovieTickets.Environment;
using MovieTickets.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Repository.BookingRepo
{
    public class BookingRepository:IBookingRepository
    {
        private readonly MovieTicketsDbContext context;
        private IMapper mapper;
        public BookingRepository(MovieTicketsDbContext _context, IMapper _mapper) // Dependency Injection
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<Booking> CreateBooking(BookingDto createBooking)
        {
            var booking = mapper.Map<Booking>(createBooking);
            await context.Bookings.AddAsync(booking);
            await context.SaveChangesAsync();
            return booking;
        }
        public async Task<Booking> CreateBookingWithData(Booking booking)
        {
            await context.Bookings.AddAsync(booking);
            return booking;
        }
        public async Task<Booking> DeleteBooking(int BookingID)
        {
            var deleteBooking = await context.Bookings.FindAsync(BookingID);
            if (deleteBooking != null)
            {
                 context.Bookings.Remove(deleteBooking);
                await context.SaveChangesAsync();
            }
            return deleteBooking;

        }

        public async Task<Booking> GetBookingByID(int BookingID)
        {
            return await context.Bookings.FindAsync(BookingID);

        }
        public async Task<IEnumerable<Booking>> GetBookingByuserID(int userID)
        {
            return await context.Bookings.Where(b => b.UserID == userID).ToListAsync();

        }

        public async Task<IEnumerable<Booking>> getBookings()
        {
            return await context.Bookings.Include(b=>b.ShowSeats).ToListAsync();
        }

        public async Task<Booking> UpdateBooking(BookingDto UpdateBooking, int BookingID)
        {
            var updatedBooking = mapper.Map<Booking>(UpdateBooking);
            var Booking = await context.Bookings.FindAsync(BookingID);
            if (Booking == null)
            {
                throw new AppException("Booking not found");

            }
            if (!string.IsNullOrWhiteSpace(updatedBooking.NumberOfSeats.ToString()))
            {
                Booking.NumberOfSeats = updatedBooking.NumberOfSeats;
            }
            if (!string.IsNullOrWhiteSpace(updatedBooking.ShowID.ToString()))
            {
                Booking.ShowID = updatedBooking.ShowID;
            }
            if (!string.IsNullOrWhiteSpace(updatedBooking.Status.ToString()))
            {
                Booking.Status = updatedBooking.Status;
            }
            if (!string.IsNullOrWhiteSpace(updatedBooking.UserID.ToString()))
            {
                Booking.UserID = updatedBooking.UserID;
            }
            if (!string.IsNullOrWhiteSpace(updatedBooking.TimeStamp.ToString()))
            {
                Booking.TimeStamp = updatedBooking.TimeStamp;
            }
            context.Bookings.Update(Booking);
            await context.SaveChangesAsync();

            return Booking ;

        }
    }
}
