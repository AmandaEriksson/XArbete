using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NToastNotify;
using XArbete.Domain.Models;
using XArbete.Services.Data;
using XArbete.Services.Interfaces;
using XArbete.Services.Services;
using XArbete.Services.Utils.Services;
using XArbete.Web.Services.Interfaces;
using XArbete.Web.Utils.AutoMapper;

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

            services.Configure<RazorViewEngineOptions>(o =>
            {
                o.ViewLocationExpanders.Add(new MyViewLocationExpander());
            });
            //SetRepository();
            services.Configure<WebOptions>(Configuration)
                .AddMvc()
                .AddNToastNotifyToastr(new ToastrOptions()
                {
                    ProgressBar = true,
                    PositionClass = ToastPositions.BottomCenter
                });

            services.AddDbContext<XArbeteContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<XArbeteContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.  
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;


                // User settings.  
                options.User.RequireUniqueEmail = true;
            });

            /* AutoMapper */
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerDogService, CustomerDogService>();
            services.AddScoped<IDogHotelService, DogHotelService>();
            services.AddScoped<ITrainingHallService, TrainingHallService>();
            services.AddScoped<IGuestBookService, GuestBookService>();
            services.AddScoped<IKennelDogService, KennelDogService>();
            services.AddScoped<IPuppyGroupService, PuppyGroupService>();
            services.AddScoped<IPuppyService, PuppyService>();
            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<IContentSectionService, ContentSectionService>();
            services.AddScoped<ICustomerCourseService, CustomerCourseService>();

            services.AddScoped<ICourseService, CourseService>();


            //services.AddTransient<IRazorViewEngine, Core.CustomRazorViewEngine>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseAuthentication();

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

    }
}
