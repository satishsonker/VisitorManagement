using System.ComponentModel.DataAnnotations;

namespace VisitorManagement.DataModels
{
    public class BaseDataModel
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
