﻿using MovieTickets.ModelsDto.BookingDto;
using MovieTickets.Services.BookingsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public IPaymentService context { get; set; }

        public PaymentController(IPaymentService _context)
        {
            context = _context;
        }


        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            try
            {
                var Payments = await context.getPayments();
                return Ok(Payments);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpGet("{PaymentID}")]
        public async Task<IActionResult> GetPaymentID(int PaymentID)
        {
            try
            {
                var Payment = await context.GetPaymentByID(PaymentID);
                return Ok(Payment);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpPost("CreatePayment")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDto Payment)
        {
            try
            {
                var newPayment = await context.CreatePayment(Payment);
                return Ok(newPayment);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpPut("UpdatePayment/{PaymentID}")]
        public async Task<IActionResult> UpdatePayment([FromBody] PaymentDto Payment, int PaymentID)
        {
            try
            {
                var updatePayment = await context.UpdatePayment(Payment, PaymentID);
                return Ok(updatePayment);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpDelete("DeletePayment/{PaymentID}")]
        public async Task<IActionResult> DeletePayment(int PaymentID)
        {
            try
            {
                var deletePayment = await context.DeletePayment(PaymentID);
                return Ok(deletePayment);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
