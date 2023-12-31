using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.ModelsDto.CinemaDto
{
    public class CinemaSeatModelDto
    {


        public int StartSeatNumber { get; set; }

        public int EndSeatNumber { get; set; }

        public int type { get; set; } //ENUM

        // Navigation Property
        public int CinemaHallID { get; set; }
    }
}
