
using Microsoft.EntityFrameworkCore;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;

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
                contextbuilder => contextbuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<ISpaceRepository, SpaceRepository>();
            builder.Services.AddScoped<IMembershipPlansRepository, MembershipPlansRepository>();
            builder.Services.AddScoped<IUserMembershipPlansRepository, UserMembershipPlansRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();







            var app = builder.Build();

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
