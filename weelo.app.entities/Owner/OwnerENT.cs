using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Weelo.App.Api.Entities.Owner
{
    public class OwnerENT
    {
        public int? OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public IFormFile Photo { get; set; }

        public int? PropertyId { get; set; }
    }
}
