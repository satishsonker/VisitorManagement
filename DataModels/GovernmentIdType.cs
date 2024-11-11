using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisitorManagement.DataModels
{
    [Table("GovernmentIdType",Schema ="Master")]
    public class GovernmentIdType: BaseDataModel
    {
        public string Name { get; set; }
    }

}
