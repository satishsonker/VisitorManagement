using System.ComponentModel.DataAnnotations.Schema;

namespace VisitorManagement.DataModels
{
    [Table("Visitors")]
    public class Visitor:BaseDataModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GovernmentIdTypeId { get; set; }

        [ForeignKey("GovernmentIdTypeId")]
        public GovernmentIdType? GovernmentIdType { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitTime { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string IdNumber { get; set; }
    }

}
