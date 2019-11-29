using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XArbete.Web.Models;

namespace XArbete.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SetRepository();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void SetRepository()
        {
            var Dogs = new List<Dog>()
            {
                new Dog()
                {
                    ID = 1,
                    Name = "Fridolf",
                    Sex = "Male",
                    CustomerID = 1
                },
                new Dog()
                {
                    ID = 2,
                    Name = "Stella",
                    Sex = "Female",
                    CustomerID = 2,
                    KennelDog = true
                }
            };
            var Customers = new List<Customer>()
            {
                new Customer()
                {
                    CustomerID = 1,
                    Name = "Karin",
                    Email = "lalala"
                },
                new Customer()
                {
                    CustomerID = 2,
                    Name = "Rolf",
                    Email = "lalala"
                }
        };
            var HotelBookings = new List<HotelBooking>()
            {
                new HotelBooking()
                {
                    ID = 1,
                    CustomerID = 1,
                    DogID = 1,
                    From = new DateTime(2019,11,29,09,00,00).ToString(),
                    To = new DateTime(2019,11,30,09,00,00).ToString(),
                    CanLiveWithOtherDogs = true,
                    CustomerMessage = "Min hund vill ha mat kl 15,19"
                },
                  new HotelBooking()
                {
                    ID = 2,
                    CustomerID = 2,
                    DogID = 2,
                    From = new DateTime(2019,11,30,09,00,00).ToString(),
                    To = new DateTime(2019,12,01,09,00,00).ToString(),
                    CanLiveWithOtherDogs = false,
                    CustomerMessage = "Min hund tycker om att leka och söka"
                }
            };
            var TrainingHallBookings = new List<TrainingHallBooking>()
            {
                new TrainingHallBooking()
                {
                    ID = 1,
                    CustomerID = 1,
                    StartTime = new DateTime(2019,12,02,20,00,00),
                    EndTime = new DateTime(2019,12,02,21,00,00),
                    Payed = false

                },
                 new TrainingHallBooking()
                {
                    ID = 1,
                    CustomerID = 2,
                    StartTime = new DateTime(2019,12,02,15,00,00),
                    EndTime = new DateTime(2019,12,02,17,00,00),
                    Payed = false

                }
            };
            var Comments = new List<GuestBookComment>()
            {
                new GuestBookComment()
                {
                    WrittenBy = "Göran",
                    Comment = "Fin och trevlig träningshall.",
                    ID = 1
                },
                new GuestBookComment()
                {
                    WrittenBy = "Patrik",
                    Comment = "Fina hundar",
                    ID = 2
                }
            };

            Repository.Customers = Customers;
            Repository.Dogs = Dogs;
            Repository.GuestBookComments = Comments;
            Repository.HotelBookings = HotelBookings;
            Repository.TrainingHallBookings = TrainingHallBookings;

        }
    }
}
