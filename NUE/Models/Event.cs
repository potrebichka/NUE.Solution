using System.Collections.Generic;
using System;

namespace NUE.Models
{
    public class Event
    {
        public Event()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Dj { get; set; }
        public string Video { get; set; }
        public ICollection<Comment> Comments {get;set;}

    }
}