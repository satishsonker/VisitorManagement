using System.ComponentModel.DataAnnotations.Schema;

namespace VisitorManagement.DataModels
{
    public class TimeSlotMapping:BaseDataModel
    {
        public int HallId { get; set; }
        public int TimeSlotId { get; set; }

        [ForeignKey(nameof(HallId))]
        public Hall Hall { get; set; }

        [ForeignKey(nameof(TimeSlotId))]
        public TimeSlot TimeSlot { get; set; }
    }

}
