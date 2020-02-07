using System.Collections.Generic;

namespace WebApp2.Models
{

    public class Reservation
    {
        public int ReservationId { get; set; }
        public ApplicationUser User {get;set;}
       
        public string DrinkRequest { get; set; }
        public string SongRequest { get; set; }
        public string SpecialRequest { get; set; }
        public virtual Event Event { get; set; }
    }
}