
using Microsoft.EntityFrameworkCore;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;
using Stripe;
using Microsoft.Extensions.Options;


namespace WorkSpaceWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<WorkSpaceDbContext>(
                contextbuilder => contextbuilder.UseSqlServer(builder.Configuration.GetConnectionString("asmaa"))
            );

            builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<ISpaceRepository, SpaceRepository>();
            builder.Services.AddScoped<IMembershipPlansRepository, MembershipPlansRepository>();
            builder.Services.AddScoped<IUserMembershipPlansRepository, UserMembershipPlansRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<ISpaceRepository, SpaceRepository>();





            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));



            var app = builder.Build();
          /*stripe*/

            var stripeSettings = app.Services.GetRequiredService<IOptions<StripeSettings>>().Value;
            StripeConfiguration.ApiKey = stripeSettings.SecretKey;


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
