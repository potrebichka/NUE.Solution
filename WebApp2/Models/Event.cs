using System.Collections.Generic;
using System;

namespace WebApp2.Models
{
    public class Event
    {

        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Dj { get; set; }
        public string Video { get; set; }
        // public int UserId {get; set; }
        // public ICollection<ReservationEvent> Reservations { get; }

    }
}