using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApp2.Models;

namespace WebApp2.Data
{
    public class ApplicationDbContext  : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Comment> Comments {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Event>()
                .HasData(
                    new Event { EventId = 1, EventTitle = "ULTRA", Date = new DateTime (2020,02,28,21,0,0), Location ="Bayfront Park", Dj = "Ohm", Video = "https://www.youtube.com/embed/uPlmijjHRvw?autoplay=1"},
                    new Event { EventId = 2, EventTitle = "ELECTRIC ZOO", Date = new DateTime (2020,03,15,21,0,0), Location = "Randall’s Island", Dj = "Magnetic Man", Video = "https://www.youtube.com/embed/opXnPgW8FdY?autoplay=1&mute=1;"},
                    new Event { EventId = 3, EventTitle = "ALPHA", Date = new DateTime (2020,03,30,21,0,0), Location = "TMobile Stadium", Dj = "ZHU", Video = "https://www.youtube.com/embed/bzlMCtirKRU?autoplay=1&mute=1;"},
                    new Event { EventId = 4, EventTitle = "OMEGA", Date = new DateTime (2020,04,10,21,0,0), Location = "Seattle Arena", Dj = "Kaskade", Video = "https://www.youtube.com/embed/PbW1FFarLrg?autoplay=1&mute=1;"},
                    new Event { EventId = 5, EventTitle = "COACHELLA", Date = new DateTime (2020,04,29,21,0,0), Location = "Empire Polo Club", Dj = "Steve Aoki", Video = "https://www.youtube.com/embed/rD_iJSEBBmE?autoplay=1&mute=1;"},
                    new Event { EventId = 6, EventTitle = "ELECTRIC DAISY", Date = new DateTime (2020,05,20,21,0,0), Location = "Las Vegas Motor Speedway", Dj = "Martin Garrix", Video = "https://www.youtube.com/embed/vALaiN71aVI?autoplay=1&mute=1;"}
                );
        }

    }
}