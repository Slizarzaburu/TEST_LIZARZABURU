using ELAYER;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DLAYER
{
    public class DEmployee
    {

        private IConfiguration configuration;

        public DEmployee(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public List<EmployeeDTO> GetEmployee(int? idEmployee)
        {
            List<EmployeeDTO> lstEmployee = new List<EmployeeDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("TESTCONEXION")))
                {
                    SqlCommand command = new SqlCommand("MASGLOBAL_GET_EMPLOYEE", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@P_IDEMPLOYEE", idEmployee ?? 0);
                    connection.Open();
                    SqlDataReader lector = command.ExecuteReader();
                    while (lector.Read())
                    {
                        EmployeeDTO employeeDTO = new EmployeeDTO();
                        employeeDTO.Id = lector["ID"] == DBNull.Value ? Int32.MinValue : (int)lector["ID"] ;
                        employeeDTO.FirstName = lector["first_name"] as string ?? "";
                        employeeDTO.LastName = lector["last_name"] as string ?? "";
                        employeeDTO.Gender = lector["Gender"] as string ?? "";
                        employeeDTO.Identification = lector["identification"] as string ?? "";
                        employeeDTO.DistrictResidence = lector["district_residence"] as string ?? "";
                        employeeDTO.AddressResidence = lector["address_residence"] as string ?? "";
                        employeeDTO.EmailAddress = lector["email_address"] as string ?? "";
                        employeeDTO.PhoneNumber = lector["phone_number"] as string ?? "";
                        employeeDTO.DateBirth = lector["date_birth"] == DBNull.Value ? DateTime.MinValue : (DateTime)lector["date_birth"];
                        employeeDTO.Occupation = lector["occupation"] as string ?? "";
                        employeeDTO.RegisterDate = lector["register_date"] == DBNull.Value ? DateTime.MinValue : (DateTime)lector["register_date"];
                        employeeDTO.MonthlyContract = lector["monthly_contract"] == DBNull.Value ? Decimal.MinValue : (Decimal)lector["monthly_contract"];
                        employeeDTO.HourlyContract = lector["hourly_contract"] == DBNull.Value ? Decimal.MinValue : (Decimal)lector["hourly_contract"];
                        employeeDTO.TypeContract = lector["type_contract"] == DBNull.Value ? Int32.MinValue : (Int32)lector["type_contract"];
                        lstEmployee.Add(employeeDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return lstEmployee;

        }

    }
}
