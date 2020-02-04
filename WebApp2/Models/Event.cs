using System.Collections.Generic;

namespace WebApp2.Models
{
    public class Event
    {
        public Event()
        {
            this.Reservations = new HashSet<ReservationEvent>();
        }

        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public int UserId {get; set; }
        public ICollection<ReservationEvent> Reservations { get; }

    }
}