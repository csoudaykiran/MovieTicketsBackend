﻿using MovieTickets.Models.Bookings;
using MovieTickets.ModelsDto.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Repository.BookingRepo
{
    public interface IBookingRepository
    {
        public Task<IEnumerable<Booking>> getBookings();
        public Task<Booking> GetBookingByID(int BookingID);
        public Task<IEnumerable<Booking>> GetBookingByuserID(int userID);

        public Task<Booking> CreateBooking(BookingDto createBooking);
        public Task<Booking> CreateBookingWithData(Booking booking);
        public Task<Booking> UpdateBooking(BookingDto updateBooking, int BookingID);
        public Task<Booking> DeleteBooking(int BookingID);


    }
}
