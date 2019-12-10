using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NToastNotify;
using XArbete.Web.Data;
using XArbete.Web.Models;
using XArbete.Web.Services;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.Utils.Services;

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

            services.AddDbContext<XArbeteContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<XArbeteContext>();

            //SetRepository();
            services.Configure<WebOptions>(Configuration)
                .AddMvc()
                .AddNToastNotifyToastr(new ToastrOptions()
                {
                    ProgressBar = true,
                    PositionClass = ToastPositions.BottomCenter
                });

            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDogService, DogService>();
            services.AddScoped<IDogHotelService, DogHotelService>();
            services.AddScoped<ITrainingHallService, TrainingHallService>();
            services.AddScoped<IGuestBookService, GuestBookService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            //SetRepository();
            app.UseNToastNotify();

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

        //public void SetRepository()
        //{

        //    //using (var ctx = new XArbeteContext())
        //    //{
        //    //    var stud = new Customer() { CustomerID = 1, Name = "Bill" };

        //    //    ctx.Customers.Add(stud);
        //    //    ctx.SaveChanges();
        //    //}
        //    var Dogs = new List<Dog>()
        //        {
        //            new Dog()
        //            {
        //                ID = 1,
        //                Name = "Fridolf",
        //                Sex = "Hane",
        //                CustomerID = 1,
        //                Ras = "Vinthund",
        //                Other = "Skygg för män",
        //                Kastrated = false,
        //                CanLiveWithOtherDogs = true
        //            },
        //            new Dog()
        //            {
        //                ID = 2,
        //                Name = "Stella",
        //                Sex = "Tik",
        //                CustomerID = 2,
        //                Ras = "Border Collie",
        //                Other = "Spannmålsallergiker",
        //                Kastrated = true,
        //                CanLiveWithOtherDogs = false
        //            }
        //        };
        //    var Customers = new List<Customer>()
        //        {
        //            new Customer()
        //            {
        //                ID = 1,
        //                Name = "Karin",
        //                Email = "karin@hotmail.com",
        //                Number = "0700103256"
        //            },
        //            new Customer()
        //            {
        //                ID = 2,
        //                Name = "Rolf",
        //                Email = "rolf@hotmai.com",
        //                Number = "0701847572"
        //            }
        //    };
        //    var HotelBookings = new List<HotelBooking>()
        //        {
        //            new HotelBooking()
        //            {
        //                ID = 1,
        //                Customer=Repository.Customers.SingleOrDefault(a => a.ID == 1),
        //                Dog = Repository.Dogs.SingleOrDefault(a => a.ID == 1),
        //                From = new DateTime(2019,11,29,09,00,00),
        //                To = new DateTime(2019,11,30,09,00,00),
        //                CustomerMessage = "Min hund vill ha mat kl 15,19"
        //            },
        //              new HotelBooking()
        //            {
        //                ID = 2,
        //                Customer=Repository.Customers.SingleOrDefault(a => a.ID == 2),
        //                Dog=Repository.Dogs.SingleOrDefault(a => a.ID == 2),
        //                From = new DateTime(2019,11,30,09,00,00),
        //                To = new DateTime(2019,12,01,09,00,00),
        //                CustomerMessage = "Min hund tycker om att leka och söka"
        //            }
        //        };
        //    var TrainingHallBookings = new List<TrainingHallBooking>()
        //        {
        //            new TrainingHallBooking()
        //            {
        //                ID = 1,
        //                Customer=Repository.Customers.SingleOrDefault(a => a.ID == 1),
        //                StartTime = new DateTime(2019,12,06,20,00,00),
        //                EndTime = new DateTime(2019,12,06,21,00,00),
        //                Payed = false

        //            },
        //             new TrainingHallBooking()
        //            {
        //                ID = 2,
        //               Customer=Repository.Customers.SingleOrDefault(a => a.ID == 2),
        //                StartTime = new DateTime(2019,12,05,15,00,00),
        //                EndTime = new DateTime(2019,12,05,17,00,00),
        //                Payed = false

        //            }
        //        };
        //    var Comments = new List<GuestBookComment>()
        //        {
        //            new GuestBookComment()
        //            {
        //                WrittenBy = "Göran",
        //                Comment = "Fin och trevlig träningshall.",
        //                ID = 1
        //            },
        //            new GuestBookComment()
        //            {
        //                WrittenBy = "Patrik",
        //                Comment = "Fina hundar",
        //                ID = 2
        //            }
        //        };

        //    Repository.Customers = Customers;
        //    Repository.Dogs = Dogs;
        //    Repository.GuestBookComments = Comments;
        //    Repository.HotelBookings = HotelBookings;
        //    Repository.TrainingHallBookings = TrainingHallBookings;

        //}
    }
}
