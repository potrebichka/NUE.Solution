// using System;
// using System.Collections.Generic;
// using System.Text;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;
// using WebApp2.Models;

// namespace WebApp2.Data
// {
//     public class ApplicationDbContext : IdentityDbContext
//     {
//         public virtual DbSet<Reservation> Reservations { get; set; }
//         public DbSet<Event> Events { get; set; }
//         public DbSet<ReservationEvent> ReservationEvent { get; set; }
//         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//             : base(options)
//         {
//         }
//     }
// }
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
                    new Event { EventId = 1, EventTitle = "Matilda | 02/30/20" },
                    new Event { EventId = 2, EventTitle = "Rexie | 02/30/20"},
                    new Event { EventId = 3, EventTitle = "Matilda | 02/30/20" },
                    new Event { EventId = 4, EventTitle = "Pip | 02/30/20" },
                    new Event { EventId = 5, EventTitle = "Bartholomew | 02/30/20" },
                    new Event { EventId = 6, EventTitle = "Bartholomew | 02/30/20" }
                );
        }


    }
}


    