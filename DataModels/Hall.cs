using System.ComponentModel.DataAnnotations.Schema;

namespace VisitorManagement.DataModels
{
    public class Hall:BaseDataModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public Property Property { get; set; }

        public ICollection<HallImage> Images { get; set; }
        public ICollection<HallAmenityMapper> HallAmenities { get; set; }
        public ICollection<TimeSlotMapping> TimeSlotMappings { get; set; }
    }

    public class HallImage:BaseDataModel
    {
        public string ImageUrl { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }

    public class HallAmenityMapper : BaseDataModel
    {
        public string? ImageUrl { get; set; }
        public int HallId { get; set; }
        public int AmenityId { get; set; }

        [ForeignKey(nameof(HallId))]
        public Hall Hall { get; set; }

        [ForeignKey(nameof(AmenityId))]
        public Amenity Amenity { get; set; }
    }

    public class Amenity:BaseDataModel
    {
        public string Name { get; set; }
        public string? Icon { get; set; }
    }

}
