using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weelo.App.Api.EF.DataModel
{
    public class PropertyTrace
    {
        [Key]
        [Required]
        public int? PropertyTraceId { get; set; }
        [Required]
        public DateTime DateSale { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public int? PropertyId { get; set; }
    }
}
