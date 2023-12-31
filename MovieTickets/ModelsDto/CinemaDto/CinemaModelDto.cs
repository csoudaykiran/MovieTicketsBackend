using MovieTickets.Models.Cinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieTickets.ModelsDto.CinemaDto
{
    public class CinemaModelDto
    {
        [JsonIgnore]
        public int CinemaID { get; set; }
        public string Name { get; set; }
        public int TotalCinemaHalls { get; set; }

        public string City { get; set; }
        

    }
}
