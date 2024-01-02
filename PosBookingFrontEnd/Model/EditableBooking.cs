using System.ComponentModel.DataAnnotations;

namespace PosBookingFrontEnd.Model
{
    public class EditableBooking
    {
        
        
        public int? Id { get; set; }
        public BookingType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? Note { get; set; }
        public TimeSpan Duration { get; set; }
        public string DurationString
        {
            get 
            {
                return Duration.ToString("hh\\:mm");
            }
            set
            {
                TimeSpan duration;
                if(TimeSpan.TryParse(value, out duration))
                {
                    Duration = duration;
                }
            }

        }
        public int BookingTypeId { get; set; }
        
        public string StartTimeString
        {
            get
            {
                return StartTime.ToString("yyyy-MM-dd HH:ss");
            }
            set
            {

            }
        }
    }
}
