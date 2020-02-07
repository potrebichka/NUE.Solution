﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp2.Data;

namespace WebApp2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200207171924_Third")]
    partial class Third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebApp2.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("ApplicationUserId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebApp2.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("EventId");

                    b.Property<string>("Image");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("CommentId");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WebApp2.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Dj");

                    b.Property<string>("EventTitle");

                    b.Property<string>("Location");

                    b.Property<string>("Video");

                    b.HasKey("EventId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            Date = new DateTime(2020, 2, 28, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            Dj = "Ohm",
                            EventTitle = "ULTRA",
                            Location = "Bayfront Park",
                            Video = "https://www.youtube.com/embed/uPlmijjHRvw?autoplay=1&mute=1"
                        },
                        new
                        {
                            EventId = 2,
                            Date = new DateTime(2020, 3, 15, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            Dj = "Magnetic Man",
                            EventTitle = "ELECTRIC ZOO",
                            Location = "Randall’s Island",
                            Video = "https://www.youtube.com/embed/opXnPgW8FdY?autoplay=1&mute=1;"
                        },
                        new
                        {
                            EventId = 3,
                            Date = new DateTime(2020, 3, 30, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            Dj = "ZHU",
                            EventTitle = "ALPHA",
                            Location = "TMobile Stadium",
                            Video = "https://www.youtube.com/embed/bzlMCtirKRU?autoplay=1&mute=1;"
                        },
                        new
                        {
                            EventId = 4,
                            Date = new DateTime(2020, 4, 10, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            Dj = "Kaskade",
                            EventTitle = "OMEGA",
                            Location = "Seattle Arena",
                            Video = "https://www.youtube.com/embed/PbW1FFarLrg?autoplay=1;"
                        },
                        new
                        {
                            EventId = 5,
                            Date = new DateTime(2020, 4, 29, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            Dj = "Steve Aoki",
                            EventTitle = "COACHELLA",
                            Location = "Empire Polo Club",
                            Video = "https://www.youtube.com/embed/rD_iJSEBBmE?autoplay=1&mute=1;"
                        },
                        new
                        {
                            EventId = 6,
                            Date = new DateTime(2020, 5, 20, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            Dj = "Martin Garrix",
                            EventTitle = "ELECTRIC DAISY",
                            Location = "Las Vegas Motor Speedway",
                            Video = "https://www.youtube.com/embed/vALaiN71aVI?autoplay=1&mute=1;"
                        });
                });

            modelBuilder.Entity("WebApp2.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DrinkRequest");

                    b.Property<int?>("EventId");

                    b.Property<string>("SongRequest");

                    b.Property<string>("SpecialRequest");

                    b.Property<string>("UserId");

                    b.HasKey("ReservationId");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApp2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApp2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApp2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp2.Models.Comment", b =>
                {
                    b.HasOne("WebApp2.Models.Event", "Event")
                        .WithMany("Comments")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp2.Models.ApplicationUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebApp2.Models.Event", b =>
                {
                    b.HasOne("WebApp2.Models.ApplicationUser")
                        .WithMany("Events")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("WebApp2.Models.Reservation", b =>
                {
                    b.HasOne("WebApp2.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("WebApp2.Models.ApplicationUser", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
