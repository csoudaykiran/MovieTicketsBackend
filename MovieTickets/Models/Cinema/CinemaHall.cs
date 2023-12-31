﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Models.Cinema
{
    public class CinemaHall
    {
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int CinemaHallID { get; set; }


        [Column(TypeName = "varchar(20)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int TotalSeats { get; set; }

        // Navigation Property
        public ICollection<CinemaSeat> CinemaSeats { get; set; }
        public Show.Show Show { get; set; }

        public int CinemaID { get; set; }
        public Cinema Cinema { get; set; }

    }
}
