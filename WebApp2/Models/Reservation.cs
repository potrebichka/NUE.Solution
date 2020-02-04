using System.Collections.Generic;

namespace WebApp2.Models
{
    public class Reservation
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string Nickname { get; set; }
        public int ReservationId { get; set; }
        public int UserId {get; set; }
        public string DrinkRequest { get; set; }
        public string SongRequest { get; set; }
        public string SpecialRequest { get; set; }
        public virtual Event Event { get; set; }

    }
}