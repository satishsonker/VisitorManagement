using System.ComponentModel.DataAnnotations.Schema;
using VisitorManagement.DataModels;

namespace VisitorManagement.DTO
{
    public class VisitorRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GovernmentIdTypeId { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitTime { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
    }
}
