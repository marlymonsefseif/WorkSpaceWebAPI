
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
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();

            // Registering the Controllers
            builder.Services.AddControllers();

            // Swagger Configuration
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "API", Description = "Example API" });

                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token"
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
                new string[] { }
            }
        });
            });

            // Add DbContext and Identity configuration
            builder.Services.AddDbContext<WorkSpaceDbContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
                options.UseSqlServer(builder.Configuration.GetConnectionString("Rahma"))
            );

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<WorkSpaceDbContext>();

            // Add custom services and repositories
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

            // Stripe configuration
            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

            // Authentication Configuration (JWT)
            builder.Services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:Iss"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:Aud"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });

            // Authorization Configuration
            builder.Services.AddAuthorization();
            



            var app = builder.Build();

            // Configure Stripe API key
            var stripeSettings = app.Services.GetRequiredService<IOptions<StripeSettings>>().Value;
            StripeConfiguration.ApiKey = stripeSettings.SecretKey;

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();  
            app.UseAuthorization();

            app.MapControllers(); 

            app.Run();
        }

    }
}
