using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Weelo.App.Api.Entities.Owner;

namespace Weelo.App.Api.Entities.Property
{
    public class PropertyENT
    {
        public int? PropertyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double Price { get; set; }
        public int CodeInternal { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public List<IFormFile> Photos { get; set; }
       
    }

}

