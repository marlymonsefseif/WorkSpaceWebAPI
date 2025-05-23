using Microsoft.EntityFrameworkCore;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;
using Stripe;
using Microsoft.Extensions.Options;
using WorkSpaceWebAPI.Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WorkSpaceWebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<WorkSpaceDbContext>(options =>
                //options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
                options.UseSqlServer(builder.Configuration.GetConnectionString("CS"))
            //options.UseSqlServer(builder.Configuration.GetConnectionString("Rahma"))
            //options.UseSqlServer(builder.Configuration.GetConnectionString("MarlyCS"))
            );


            builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<ISpaceRepository, SpaceRepository>();
            builder.Services.AddScoped<IMembershipPlansRepository, MembershipPlansRepository>();
            builder.Services.AddScoped<IUserMembershipPlansRepository, UserMembershipPlansRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<ISpaceRepository, SpaceRepository>();
            builder.Services.AddScoped<IAmenityRepository, AmenityRepsitory>();
            builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
            builder.Services.AddScoped<IFileService, Services.FileService>();

            // Configure Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }
            ).AddEntityFrameworkStores<WorkSpaceDbContext>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                    policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
                );
            });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                         policy.WithOrigins("http://localhost:4200")
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowAnyOrigin()
                );
            });


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:Iss"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:Aud"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Token failed: " + context.Exception.Message);
                        return Task.CompletedTask;
                    }
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Token failed: " + context.Exception.Message);
                        return Task.CompletedTask;
                    }
                };
            });



            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 5 Web API",
                    Description = " ITI Projrcy"
                });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                    }
                    },
                    new string[] {}
                    }
                    });
            });




            var app = builder.Build();

            // Configure Stripe API key
            var stripeSettings = app.Services.GetRequiredService<IOptions<StripeSettings>>().Value;
            StripeConfiguration.ApiKey = stripeSettings.SecretKey;

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("MyPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

           

            app.Run();
        }

    }
}
