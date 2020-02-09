using System.Collections.Generic;
using System;

namespace NUE.Models
{
    public class Comment
    {
        public int CommentId {get;set;}
        public Event Event { get; set; }
        public int EventId {get;set;}
        public ApplicationUser User {get; set; }
        public string Title {get;set;}
        public string Description {get;set;}
        public DateTime Time {get;set;}
        public string Image {get;set;}
    }
}