using System;
using System.ComponentModel.DataAnnotations;

namespace Weelo.App.Api.EF.DataModel
{
    public class Owner
    {
        [Key]
        [Required]
        public int? OwnerId { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(256)]
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        [StringLength(256)]
        public string PhotoName { get; set; }
        public DateTime Birthday { get; set; }
        public int? PropertyId { get; set; }
    }
}
