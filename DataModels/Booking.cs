namespace VisitorManagement.DataModels
{
    public class Booking:BaseDataModel
    {
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime BookingDate { get; set; }
        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public DateTime? RescheduleDate { get; set; }
        public decimal BookingAmount { get; set; }
        public decimal Advance { get; set; }
        public decimal BalanceAmount { get; set; }
        public bool IsCancel { get; set; }
    }

}
