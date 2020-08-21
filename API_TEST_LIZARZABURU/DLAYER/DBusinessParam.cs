using ELAYER;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DLAYER
{
    public class DBusinessParam
    {

        private IConfiguration configuration;

        public DBusinessParam(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public ResponseDTO GetCalculateHourlySalary(decimal? hourlySalary)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("TESTCONEXION")))
                {
                    SqlCommand command = new SqlCommand("MASGLOBAL_CALCULATE_HOURLYSALARY", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@HOURLY_SALARY", hourlySalary ?? 0);
                    connection.Open();
                    SqlDataReader lector = command.ExecuteReader();
                    while (lector.Read())
                    {
                        response.responseDecimal = lector["HOURLYSALARY"] == DBNull.Value ? Decimal.MinValue : (Decimal)lector["HOURLYSALARY"];
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return response;

        }
        public ResponseDTO GetCalculateMonthlySalary(decimal? monthlySalary)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("TESTCONEXION")))
                {
                    SqlCommand command = new SqlCommand("MASGLOBAL_CALCULATE_MONTHLYSALARY", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MONTHLYSALARY", monthlySalary ?? 0);
                    connection.Open();
                    SqlDataReader lector = command.ExecuteReader();
                    while (lector.Read())
                    {
                        response.responseDecimal = lector["MONTHLYSALARY"] == DBNull.Value ? Decimal.MinValue : (Decimal)lector["MONTHLYSALARY"];
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return response;
        }


    }
}
