using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiKey;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB_LIZARZABURU.Models;

namespace WEB_LIZARZABURU.Controllers
{
    public class EmployeeController : Controller
    {
        Client api = new Client();
        [HttpGet]
        public async Task<IActionResult> Index(int idEmployee)
        {
            List<Employee> lstEmployees = await GetEmployees(idEmployee);
            return View(lstEmployees);
        }
        [HttpPost]
        public async Task<List<Employee>> GetEmployees(int idEmployee)
        {
            List<Employee> lstEmployee = new List<Employee>();
            using (var httpClient = api.GetClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("api/Employee/GetEmployee", idEmployee))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lstEmployee = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                }
            }
            return lstEmployee;
        }

        [HttpGet("idEmployee")]
        public async Task<IActionResult> InformationDetail(int idEmployee)
        {
            Employee model = new Employee();
            List<Employee> lstEmployee = await GetEmployees(idEmployee);
            ResponseDTO response = new ResponseDTO();

            foreach (var item in lstEmployee)
            {
                model.Id = item.Id;
                model.FirstName = item.FirstName;
                model.LastName = item.LastName;
                model.Gender = item.Gender;
                model.Identification = item.Identification;
                model.Gender = item.Gender;
                model.DistrictResidence = item.DistrictResidence;
                model.AddressResidence = item.AddressResidence;
                model.EmailAddress = item.EmailAddress;
                model.PhoneNumber = item.PhoneNumber;
                model.DateBirth = item.DateBirth;
                model.Occupation = item.Occupation;
                model.RegisterDate = item.RegisterDate;
                model.TypeContract = item.TypeContract;

                model.MonthlyContract = item.MonthlyContract;
                model.HourlyContract = item.HourlyContract;

            }

            switch (model.TypeContract)
            {
                case 1:
                    ViewBag.HourlySalary = await GetCalculateHourlySalary(model.HourlyContract);
                    break;
                case 2:
                    ViewBag.MonthlyContract = await GetCalculateHourlySalary(model.MonthlyContract);
                    break;
                default:
                    ViewBag.HourlySalary = await GetCalculateHourlySalary(model.HourlyContract);
                    ViewBag.MonthlyContract = await GetCalculateMonthlySalary(model.MonthlyContract);
                    break;

            }

            return View(model);
        }

        [HttpPost]
        public async Task<decimal> GetCalculateHourlySalary(decimal? hourlySalary)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            using (var httpClient = api.GetClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("api/Business/GetCalculateHourlySalary", hourlySalary))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseDTO = JsonConvert.DeserializeObject<ResponseDTO>(apiResponse);
                }
            }
            return responseDTO.responseDecimal;
        }

        [HttpPost]
        public async Task<decimal> GetCalculateMonthlySalary(decimal? monthlySalary)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            using (var httpClient = api.GetClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("api/Business/GetCalculateMonthlySalary", monthlySalary))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseDTO = JsonConvert.DeserializeObject<ResponseDTO>(apiResponse);
                }
            }
            return responseDTO.responseDecimal;
        }

    }
}