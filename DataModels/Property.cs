using System.ComponentModel.DataAnnotations.Schema;

namespace VisitorManagement.DataModels
{
    public class Property:BaseDataModel
    {
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Description { get; set; }
        public ICollection<PropertyImage> Images { get; set; }

        public int PropertyLocationId { get; set; }

        [ForeignKey(nameof(PropertyLocationId))]
        public PropertyLocation PropertyLocation { get; set; }
    }

    public class PropertyImage:BaseDataModel
    {
        public string ImageUrl { get; set; }
        public string ThumbImageUrl { get; set; }
        public int PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public Property Property { get; set; }
    }

}
