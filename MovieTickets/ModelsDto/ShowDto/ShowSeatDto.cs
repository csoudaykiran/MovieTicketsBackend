using MovieTickets.Models.Bookings;
using MovieTickets.Models.Cinema;
using MovieTickets.Models.Show;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.ModelsDto.ShowDto
{
    public class ShowSeatDto
    {

        public int Status { get; set; }

        public decimal Price { get; set; }


        // Navigation Properties
        public int ShowID { get; set; }


        public int CinemaSeatID { get; set; }
 

        public int? BookingID { get; set; }

    }
}
