using System.ComponentModel.DataAnnotations;

namespace PosBookingFrontEnd.Model
{
    public class EditableBooking
    {
        
        
        public int? Id { get; set; }
        [Required]
        public BookingType? Type { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        [MinLength(2, ErrorMessage = "Customer Name is to short")]
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? Note { get; set; }
        [Required]
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
        public int BookingTypeId
        {
            get { return Type.Id; }
        }
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
