using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Weelo.App.Api.EF.DataModel
{
    public class PropertyImage
    {
        [Key]
        [Required]
        public int PropertyImageId { get; set; }
        public Property Property { get; set; }
        [Required]
        public byte[] File { get; set; }
        public bool Enabled { get; set; }

        [StringLength(256)]
        public string ImageName { get; set; }

        public static implicit operator List<object>(PropertyImage v)
        {
            throw new NotImplementedException();
        }
    }
}
