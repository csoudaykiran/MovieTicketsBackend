using MovieTickets.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieTickets.ModelsDto.MovieDto
{
    public class CreateMovieModel 
    {
        [JsonIgnore]
        public int MovieID { get; set; }
        public string Title { get; set; }

        public string ImgLink { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public string Language { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Censorship { get; set; }

        public string City { get; set; }

        public string TrailerLink { get; set; }
        
    }
}
