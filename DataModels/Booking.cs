using System.ComponentModel.DataAnnotations.Schema;

namespace VisitorManagement.DataModels
{
    public class Booking:BaseDataModel
    {
        public int HallId { get; set; }
        [ForeignKey(nameof(HallId))]
        public Hall Hall { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public DateTime BookingDate { get; set; }
        public int TimeSlotMappingId { get; set; }
        [ForeignKey(nameof(TimeSlotMappingId))]
        public TimeSlotMapping TimeSlotMapping { get; set; }
        public DateTime? RescheduleDate { get; set; }
        public decimal BookingAmount { get; set; }
        public decimal Advance { get; set; }
        public decimal BalanceAmount { get; set; }
        public bool IsCancel { get; set; }
    }

}
