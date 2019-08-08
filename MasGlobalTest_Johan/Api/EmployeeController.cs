using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Business;
using Dto;
using MasGlobalTest_Johan.Api.Contracts;

namespace MasGlobalTest_Johan.Api
{
    public class EmployeeController : ApiController, IEmployeeController
    {             
        [ResponseType(typeof(IEnumerable<EmployeeDto>))]
        [HttpGet]
        public IHttpActionResult GetEmployees(int? employeeId = null)
        {
            Business.Business bus = new Business.Business();
            try
            {
                var result = bus.GetEmployees(employeeId);
                return Ok(result);
            }
            catch(Exception ex)
            {
               return BadRequest(string.Format("An error ahs ocurred: {0}", ex.Message));
            }            
        }
    }
}
