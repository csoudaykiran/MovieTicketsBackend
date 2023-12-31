using MovieTickets.Environment;
using MovieTickets.Repository.UserRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieTickets.Helper;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MovieTickets.Services;
using Microsoft.IdentityModel.Tokens;
using MovieTickets.Services.MovieService;
using MovieTickets.Repository.MovieRepo;
using Newtonsoft.Json;
using MovieTickets.Repository.CinemaRepo;
using MovieTickets.Services.CinemaServices;
using MovieTickets.Repository.ShowRepo;
using MovieTickets.Services.ShowsService;
using MovieTickets.Models.Bookings;
using MovieTickets.Repository.BookingRepo;
using MovieTickets.Services.BookingsService;
using MovieTickets.Repository.PaymentRepo;
using MovieTickets.Services.PaymentsService;
using MovieTickets.Repository.CinemaSeatRepo;
using MovieTickets.Services.CinemaSeatServices;

namespace MovieTickets
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;
        public Startup(IConfiguration configuration, IWebHostEnvironment _env)
        {
            Configuration = configuration;
            env = _env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (env.IsProduction())
            {
                services.AddDbContext<MovieTicketsDbContext>();
            }

            services.AddCors();
            services.AddControllers();
            // Adding DbContext class to services. connection string to mssql database  Then we can add migration.
            services.AddDbContext<MovieTicketsDbContext>(options => {
            options.UseSqlServer(Configuration.GetConnectionString("Connection"));
              }, ServiceLifetime.Transient);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            
            


            // Adding User Scope so that we can call from Endpoint.
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<ICinemaService, CinemaService>();

            services.AddScoped<ICinemaHallRepository, CinemaHallRepository>();
            services.AddScoped<ICinemaHallService, CinemaHallService>();

            services.AddScoped<IShowRepository, ShowRepository>();
            services.AddScoped<IShowService, ShowService>();

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingService, BookingService>();

            services.AddScoped<IShowSeatRepository, ShowSeatRepository>();
            services.AddScoped<IShowSeatService, ShowSeatService>();


            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<ICinemaSeatRepository, CinemaSeatRepository>();
            services.AddScoped<ICinemaSeatService, CinemaSeatService>();


            services.AddControllers()
               .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "You api title", Version = "v1" });
                

               

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MovieTicketsDbContext DatabaseContext)
        {
            DatabaseContext.Database.Migrate();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieTickets v1"));
            }
            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
