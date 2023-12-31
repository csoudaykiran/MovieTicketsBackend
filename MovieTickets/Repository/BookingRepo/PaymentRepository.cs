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

namespace MovieTickets.Repository.PaymentRepo
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly MovieTicketsDbContext context;
        private IMapper mapper;
        public PaymentRepository(MovieTicketsDbContext _context, IMapper _mapper) // Dependency Injection
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<Payment> CreatePayment(PaymentDto createPayment)
        {
            var Payment = mapper.Map<Payment>(createPayment);
            await context.Payments.AddAsync(Payment);
            await context.SaveChangesAsync();
            return Payment;
        }

        public async Task<Payment> DeletePayment(int PaymentID)
        {
            var deletePayment = await context.Payments.FindAsync(PaymentID);
            if (deletePayment != null)
            {
                context.Payments.Remove(deletePayment);
                await context.SaveChangesAsync();
            }
            return deletePayment;

        }

        public async Task<Payment> GetPaymentByID(int PaymentID)
        {
            return await context.Payments.FindAsync(PaymentID);

        }

        public async Task<IEnumerable<Payment>> getPayments()
        {
            return await context.Payments.ToListAsync();
        }

        public async Task<Payment> UpdatePayment(PaymentDto UpdatePayment, int PaymentID)
        {
            var updatedPayment = mapper.Map<Payment>(UpdatePayment);
            var Payment = await context.Payments.FindAsync(PaymentID);
            if (Payment == null)
            {
                throw new AppException("Payment not found");

            }
            if (!string.IsNullOrWhiteSpace(updatedPayment.Amount.ToString()))
            {
                Payment.Amount = updatedPayment.Amount;
            }
            if (!string.IsNullOrWhiteSpace(updatedPayment.TimeStamp.ToString()))
            {
                Payment.TimeStamp = updatedPayment.TimeStamp;
            }
            if (!string.IsNullOrWhiteSpace(updatedPayment.DiscountCuponID.ToString()))
            {
                Payment.DiscountCuponID = updatedPayment.DiscountCuponID;
            }
            if (!string.IsNullOrWhiteSpace(updatedPayment.PaymentMethod.ToString()))
            {
                Payment.PaymentMethod = updatedPayment.PaymentMethod;
            }
            if (!string.IsNullOrWhiteSpace(updatedPayment.BookingID.ToString()))
            {
                Payment.BookingID = updatedPayment.BookingID;
            }
            context.Payments.Update(Payment);
            await context.SaveChangesAsync();

            return Payment;

        }
    }
}
