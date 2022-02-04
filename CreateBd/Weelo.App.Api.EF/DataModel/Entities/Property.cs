using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Weelo.App.Api.EF.DataModel
{
    [Index(nameof(Year))]
    public class Property
    {
        [Key]
        [Required]
        public int? PropertyId { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        [Required]
        [StringLength(256)]
        public string Address { get; set; }
        [Required]
        public double Price { get; set; }
        public int CodeInternal { get; set; }
        public int Year { get; set; }
        public List<Owner> Owners { get; set; }
        public List<PropertyImage> Images { get; set; }

    }
}
