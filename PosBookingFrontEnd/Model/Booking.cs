namespace PosBookingFrontEnd.Model
{
    public class Booking
    {
        
        public int? Id { get; set; }
        public BookingType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? Note { get; set; }
    }
}
