﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WhiteLagoon.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [DisplayName("Price Per Night")]
        [Range(10, 10000)]
        public double Price { get; set; }
        [DisplayName("Square Feet")]
        public int Sqft { get; set; }
        [Range(1, 10)]
        public int Occupancy { get; set; }
        [DisplayName("Image URL")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
