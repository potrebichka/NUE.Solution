using System.Collections.Generic;

namespace WebApp2.Models
{

    public class Reservation
    {
        // public Reservation()
        // {
        //     this.Events = new HashSet<ReservationEvent>();
        // }

        //public int EventId { get; set; }
        //public string EventTitle { get; set; }
        public int ReservationId { get; set; }
        public ApplicationUser User {get;set;}
        //public int UserId {get; set; }
        public string DrinkRequest { get; set; }
        public string SongRequest { get; set; }
        public string SpecialRequest { get; set; }
        public virtual Event Event { get; set; }
        // public virtual ICollection<ReservationEvent> Events { get; set; }
    }
}