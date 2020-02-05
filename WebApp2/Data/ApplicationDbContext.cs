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
        public DbSet<ReservationEvent> ReservationEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Event>()
                .HasData(
                    new Event { EventId = 1, EventTitle = "Ultra", Video = "https://www.youtube.com/embed/uPlmijjHRvw?autoplay=1;" },
                    new Event { EventId = 2, EventTitle = "Electric Zoo", Video = "https://www.youtube.com/embed/opXnPgW8FdY?autoplay=1;"},
                    new Event { EventId = 3, EventTitle = "Alpha", Video = "https://www.youtube.com/embed/bzlMCtirKRU?autoplay=1;"},
                    new Event { EventId = 4, EventTitle = "Omega", Video = "https://www.youtube.com/embed/PbW1FFarLrg?autoplay=1;"},
                    new Event { EventId = 5, EventTitle = "Coachella", Video = "https://www.youtube.com/embed/rD_iJSEBBmE?autoplay=1;"},
                    new Event { EventId = 6, EventTitle = "Electric Daisy", Video = "https://www.youtube.com/embed/vALaiN71aVI?autoplay=1;"}
                );
        }

    }
}
    