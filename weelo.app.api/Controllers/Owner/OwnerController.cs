using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Weelo.App.Api.Entities.Owner;
using Weelo.App.Api.LogicLayer;

namespace Weelo.App.Api.Controllers.Owner
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OwnerController : ControllerBase
    {
        /// <summary>
        /// Insert data of owners
        /// </summary>
        /// <remarks>Send files less than 1500 KB! and extencion .png</remarks>
        [HttpPost]
        [Route("save")]
        public IActionResult Save([FromForm] OwnerENT entity)
        {
            int response = 0;
            try
            {
                if (entity.Photo.Length.Equals(1500000) || !Path.GetExtension(entity.Photo.FileName).ToLower().Equals(".png"))
                    return BadRequest("Longitud y/o extención no valida");
                else
                    if (entity.OwnerId is null)
                        response = OwnerBLL.Instance.Insert(entity, entity.Photo);
                    else
                        response = OwnerBLL.Instance.Update(entity, entity.Photo);
                return Ok(new { OwnerId = response });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }

    public class StudentForm
    {
        [Required] public int FormId { get; set; }
        [Required] public IFormFile StudentFile { get; set; }
    }
}
