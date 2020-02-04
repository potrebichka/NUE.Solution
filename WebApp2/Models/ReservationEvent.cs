namespace WebApp2.Models
{
  public class ReservationEvent
    {       
        public int ReservationEventId { get; set; }
        public int ReservationId { get; set; }
        public int EventId { get; set; }
        public Reservation Reservation { get; set; }
        public Event Event { get; set; }
    }
}