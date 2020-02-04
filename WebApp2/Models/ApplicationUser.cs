using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WebApp2.Models
{
    public class ApplicationUser : IdentityUser
    {
      public ApplicationUser()
      {
          this.Events = new HashSet<Event>();
      }
      public int ApplicationUserId { get; set; }
      public ICollection<Event> Events { get; set; }
    }
}