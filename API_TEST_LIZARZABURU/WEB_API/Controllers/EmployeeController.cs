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
    public class EmployeeController : ControllerBase
    {

        private IConfiguration configuration;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult GetEmployee([FromBody] int idEmployee)
        {
            DEmployee employee = new DEmployee(configuration);
            List<EmployeeDTO> response = employee.GetEmployee(idEmployee);
            return Ok(response);
        }

    }
}