using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.App.Api.Entities.Trace
{
    public class PropertyTraceENT
    {
        public int? PropertyTraceId { get; set; }
        public int? PropertyId { get; set; }
        [Required]
        public DateTime DateSale { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public decimal Tax { get; set; }     
    }
}
