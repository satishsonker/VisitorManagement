namespace VisitorManagement.DataModels
{
    public class TimeSlot:BaseDataModel
    {
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

}
