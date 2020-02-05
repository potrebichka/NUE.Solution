using System.Collections.Generic;
using System;

namespace WebApp2.Models
{
    public class Event
    {
        public Event()
        {
            //this.Reservations = new HashSet<Reservation>();
            this.Comments = new HashSet<Comment>();
        }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Dj { get; set; }
        public string Video { get; set; }
        // public int UserId {get; set; }
        // public ICollection<ReservationEvent> Reservations { get; }
        public ICollection<Comment> Comments {get;set;}

    }
}