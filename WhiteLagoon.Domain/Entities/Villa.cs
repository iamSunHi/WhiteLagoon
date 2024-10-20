using System.ComponentModel;

namespace WhiteLagoon.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        [DisplayName("Price Per Night")]
        public double Price { get; set; }
        [DisplayName("Square Feet")]
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        [DisplayName("Image URL")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
