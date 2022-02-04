using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using Weelo.App.Api.Entities.Property;
using Weelo.App.Api.LogicLayer;

namespace Weelo.App.Api.Controllers.Property
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertyController : ControllerBase
    {
        /// <summary>
        /// Insert data data into table property
        /// </summary>
        /// <remarks>Send files less than 1500 KB! and extencion .png</remarks>
        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromForm] PropertyENT entity)
        {
            try
            {
                if (entity.Photos.Where(l => !Path.GetExtension(l.FileName).ToLower().Equals(".png") || l.Length.Equals(1500000)).Count() > 0)
                    return BadRequest("Longitud y/o extención no valida");
                else
                {
                    if (entity.PropertyId is null)
                        return Ok(new { PropertyId = PropertyBLL.Instance.Insert(entity, entity.Photos) });
                    else
                        return Ok(new { PropertyId = PropertyBLL.Instance.Update(entity, entity.Photos) });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/by/year/{year}")]
        public IActionResult Insert(int year)
        {
            try
            {
                return Ok(PropertyBLL.Instance.FindPropertiesByYear(year));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/between/yearInit/{yearInit}/yearEnd/{yearEnd}")]
        public IActionResult FindBetween(int yearInit, int yearEnd)
        {
            try
            {
                return Ok(PropertyBLL.Instance.FindPropertiesBetweenYear(yearInit, yearEnd));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/by/initPrice/{initPrice}/endPrice/{endPrice}")]
        public IActionResult FindBetween(double initPrice, double endPrice)
        {
            try
            {
                return Ok(PropertyBLL.Instance.FindPropertiesByPrice(initPrice, endPrice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
