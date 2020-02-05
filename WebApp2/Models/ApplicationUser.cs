using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WebApp2.Models
{
    public class ApplicationUser : IdentityUser
    {
      public ApplicationUser()
      {
          this.Events = new HashSet<Event>();
          this.Reservations = new HashSet<Reservation>();
          this.Comments = new HashSet<Comment>();
      }
      public int ApplicationUserId { get; set; }
      public ICollection<Event> Events { get; set; }
      public ICollection<Reservation> Reservations { get; set; }
      public ICollection<Comment> Comments {get;set;}
    }
}