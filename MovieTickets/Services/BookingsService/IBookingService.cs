﻿using MovieTickets.Models.Bookings;
using MovieTickets.ModelsDto.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services.BookingsService
{
    public interface IBookingService
    {
        public Task<IEnumerable<Booking>> getBookings();
        public Task<Booking> GetBookingByID(int BookingID);
        public Task<Booking> CreateBooking(BookingDto createBooking);
        public Task<Booking> CreateBookingWithData(Booking booking);
        public Task<IEnumerable<Booking>> GetBookingByuserID(int userID);

        public Task<Booking> UpdateBooking(BookingDto updateBooking, int BookingID);
        public Task<Booking> DeleteBooking(int BookingID);

    }
}
