﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkSpaceWebAPI.Models;

#nullable disable

namespace WorkSpaceWebAPI.Migrations
{
    [DbContext(typeof(WorkSpaceDbContext))]
    partial class WorkSpaceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ImageProfileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeOnly?>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.ContactMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("ContactMessages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 5, 28, 17, 7, 2, 110, DateTimeKind.Utc).AddTicks(7517),
                            Email = "ahmed@example.com",
                            FullName = "Ahmed Ali",
                            IsRead = false,
                            Message = "Can I get the pricing details and booking information?",
                            Subject = "Inquiry about rooms"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 5, 28, 17, 7, 2, 110, DateTimeKind.Utc).AddTicks(7520),
                            Email = "sara@example.com",
                            FullName = "Sara Mohamed",
                            IsRead = false,
                            Message = "I booked a room but didn’t receive a confirmation. Can you contact me?",
                            Subject = "Issue with booking"
                        });
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Gallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpaceId");

                    b.ToTable("Galleries");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.MembershipPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationInDays")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MembershipPlans");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BookingId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.SpaceAmenity", b =>
                {
                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("SpaceId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("SpaceAmenities");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Spaces", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("AvailableFrom")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("AvailableTo")
                        .HasColumnType("time");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("PricePerHour")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("SpaceType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Spaces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableFrom = new TimeSpan(0, 8, 0, 0, 0),
                            AvailableTo = new TimeSpan(0, 16, 0, 0, 0),
                            Capacity = 50,
                            Description = "Room To Study",
                            IsAvailable = true,
                            IsDeleted = false,
                            Name = "StudyRoom 1",
                            PricePerHour = 20m,
                            SpaceType = 0
                        },
                        new
                        {
                            Id = 2,
                            AvailableFrom = new TimeSpan(0, 9, 0, 0, 0),
                            AvailableTo = new TimeSpan(0, 17, 0, 0, 0),
                            Capacity = 30,
                            Description = "Lab for practice",
                            IsAvailable = true,
                            IsDeleted = false,
                            Name = "ITI Lab",
                            PricePerHour = 25m,
                            SpaceType = 3
                        },
                        new
                        {
                            Id = 3,
                            AvailableFrom = new TimeSpan(0, 10, 0, 0, 0),
                            AvailableTo = new TimeSpan(0, 14, 0, 0, 0),
                            Capacity = 10,
                            Description = "Team meetings",
                            IsAvailable = false,
                            IsDeleted = false,
                            Name = "Meeting Room A",
                            PricePerHour = 15m,
                            SpaceType = 1
                        },
                        new
                        {
                            Id = 4,
                            AvailableFrom = new TimeSpan(0, 9, 0, 0, 0),
                            AvailableTo = new TimeSpan(0, 18, 0, 0, 0),
                            Capacity = 100,
                            Description = "Events and workshops",
                            IsAvailable = true,
                            IsDeleted = false,
                            Name = "Workshop Hall",
                            PricePerHour = 50m,
                            SpaceType = 2
                        },
                        new
                        {
                            Id = 5,
                            AvailableFrom = new TimeSpan(0, 7, 0, 0, 0),
                            AvailableTo = new TimeSpan(0, 22, 0, 0, 0),
                            Capacity = 20,
                            Description = "For focused study",
                            IsAvailable = true,
                            IsDeleted = false,
                            Name = "Silent Study Room",
                            PricePerHour = 10m,
                            SpaceType = 0
                        });
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.UserMembership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MembershipPlans_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MembershipPlans_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("UserMemberships");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("WorkSpaceWebAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("WorkSpaceWebAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkSpaceWebAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("WorkSpaceWebAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Booking", b =>
                {
                    b.HasOne("WorkSpaceWebAPI.Models.ApplicationUser", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkSpaceWebAPI.Models.Spaces", "zone")
                        .WithMany("Bookings")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("zone");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Gallery", b =>
                {
                    b.HasOne("WorkSpaceWebAPI.Models.Spaces", "Space")
                        .WithMany("Gallery")
                        .HasForeignKey("SpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Space");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Payment", b =>
                {
                    b.HasOne("WorkSpaceWebAPI.Models.ApplicationUser", null)
                        .WithMany("Payments")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("WorkSpaceWebAPI.Models.Booking", null)
                        .WithMany("Payments")
                        .HasForeignKey("BookingId");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Review", b =>
                {
                    b.HasOne("WorkSpaceWebAPI.Models.Spaces", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkSpaceWebAPI.Models.ApplicationUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.SpaceAmenity", b =>
                {
                    b.HasOne("WorkSpaceWebAPI.Models.Amenity", "Amenity")
                        .WithMany("SpaceAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkSpaceWebAPI.Models.Spaces", "Space")
                        .WithMany("SpaceAmenities")
                        .HasForeignKey("SpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Space");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.UserMembership", b =>
                {
                    b.HasOne("WorkSpaceWebAPI.Models.MembershipPlan", "MembershipPlan")
                        .WithMany("UserMemberships")
                        .HasForeignKey("MembershipPlans_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkSpaceWebAPI.Models.ApplicationUser", "User")
                        .WithMany("Memberships")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipPlan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Amenity", b =>
                {
                    b.Navigation("SpaceAmenities");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.ApplicationUser", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Memberships");

                    b.Navigation("Payments");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Booking", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.MembershipPlan", b =>
                {
                    b.Navigation("UserMemberships");
                });

            modelBuilder.Entity("WorkSpaceWebAPI.Models.Spaces", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Gallery");

                    b.Navigation("SpaceAmenities");
                });
#pragma warning restore 612, 618
        }
    }
}
