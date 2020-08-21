using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLAYER;
using ELAYER;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WEB_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {

        private IConfiguration configuration;
        public BusinessController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult GetCalculateHourlySalary([FromBody] decimal? hourlySalary)
        {
            DBusinessParam businessParam = new DBusinessParam(configuration);
            ResponseDTO  response = businessParam.GetCalculateHourlySalary(hourlySalary);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult GetCalculateMonthlySalary([FromBody] decimal? monthlySalary)
        {
            DBusinessParam businessParam = new DBusinessParam(configuration);
            ResponseDTO response = businessParam.GetCalculateMonthlySalary(monthlySalary);
            return Ok(response);
        }



        
    }
}