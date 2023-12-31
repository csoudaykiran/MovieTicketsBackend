﻿using MovieTickets.Models.Bookings;
using MovieTickets.Models.Cinema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Models.Show
{
    public class ShowSeat
    {
        // User ID is the Primary Key 
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int ShowSeatID { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Status { get; set; }

        [Column(TypeName = "decimal")]
        [Required]
        public decimal Price { get; set; }


        // Navigation Properties
        public int ShowID { get; set; }
        public Show Show { get; set; }

        public int CinemaSeatID { get; set; }
        public CinemaSeat CinemaSeat { get; set; }

        public int? BookingID { get; set; }
        public Booking Booking { get; set; }


    }
}
