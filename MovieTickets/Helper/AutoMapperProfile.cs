using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieTickets.Models.Bookings;
using MovieTickets.Models.Cinema;
using MovieTickets.Models.Movie;
using MovieTickets.Models.Show;
using MovieTickets.ModelsDto;
using MovieTickets.ModelsDto.BookingDto;
using MovieTickets.ModelsDto.CinemaDto;
using MovieTickets.ModelsDto.MovieDto;
using MovieTickets.ModelsDto.ShowDto;
using MovieTickets.Models;

namespace MovieTickets.Helper
{
    //The automapper profile contains the mapping configuration used by the application, AutoMapper is a package available on Nuget that enables automatic mapping of one type of classes to another.
    //In this example we're using it to map between User entities and a few different model types - UserModel, RegisterModel and UpdateModel.
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<RegisterModelUser, User>().ReverseMap();
            CreateMap<UpdateModel, User>().ReverseMap();
            CreateMap<MovieWithGenreName, Movie>().ReverseMap();
            // This will Map the remaning property and in this case Gernes Names will be stored in an array from Collection Genre.
            
           //CreateMap<MovieWithGenreName, Movie>().ReverseMap();
            //    .ForMember(Movie => Movie.Genres, Igenre => Igenre.MapFrom(genre => new Genre() { }));
            CreateMap<CreateMovieModel, Movie>().ReverseMap();
            CreateMap<UpdateMovieModel, Movie>().ReverseMap();
            CreateMap<Cinema, CinemaModelDto>().ReverseMap();
            CreateMap<CinemaSeat, CinemaSeatModelDto>().ReverseMap();
            CreateMap<CinemaHall,CinemaHallDto>().ReverseMap();
            CreateMap<Show, ShowDetailsDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<ShowSeat, ShowSeatDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
        }
    }
}
