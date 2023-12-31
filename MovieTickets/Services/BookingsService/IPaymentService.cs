using MovieTickets.Models.Bookings;
using MovieTickets.ModelsDto.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services.BookingsService
{
    public interface IPaymentService
    {
        public Task<IEnumerable<Payment>> getPayments();
        public Task<Payment> GetPaymentByID(int PaymentID);
        public Task<Payment> CreatePayment(PaymentDto createPayment);
        public Task<Payment> UpdatePayment(PaymentDto updatePayment, int PaymentID);
        public Task<Payment> DeletePayment(int PaymentID);
    }
}
