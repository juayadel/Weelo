using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Weelo.App.Api.Entities.Trace;
using Weelo.App.Api.LogicLayer;

namespace Weelo.App.Api.Controllers.Trace
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertyTraceController : ControllerBase
    {
        /// <summary>
        /// Insert data into table PropertyTrace
        /// </summary>
        /// <remarks>Send files less than 10mb!</remarks>
        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromForm] PropertyTraceENT entity)
        {
            try
            {
                if(entity.PropertyTraceId is null)
                    return Ok(PropertyTraceBLL.Instance.Insert(entity));
                else
                    return Ok(PropertyTraceBLL.Instance.Update(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
