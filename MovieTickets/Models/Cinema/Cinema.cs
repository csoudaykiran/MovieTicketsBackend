﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieTickets.Models.Cinema
{
    public class Cinema
    {
        // User ID is the Primary Key 
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int CinemaID { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int TotalCinemaHalls { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string City { get; set; }

        // Navigation Properties

        public ICollection<CinemaHall> CinemaHalls { get; set; }
        
        



    }
}
