using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ThreadInMotion.Library.DataAccessLayer.Interfaces;
using ThreadInMotion.Library.SharedModels.Models;

namespace ThreadInMotion.Library.DataAccessLayer.Services
{
    public class DailyReportService : IDailyReportService
    {
        private readonly IConfiguration _configuration;

        public DailyReportService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<DailyReport> Read(DailyReport entity)
        {
            var list = new List<DailyReport> { };
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("usp_SEL_DailyReport", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new DailyReport
                        {
                            BookName = Convert.ToString(reader[nameof(DailyReport.BookName)]),
                            MemberName = Convert.ToString(reader[nameof(DailyReport.MemberName)]),
                            ExitDate = Convert.ToDateTime(reader[nameof(DailyReport.ExitDate)]),
                            TimeSpent = Convert.ToInt32(reader[nameof(DailyReport.TimeSpent)]),
                            PenaltyGoal = Convert.ToInt32(reader[nameof(DailyReport.PenaltyGoal)])
                        });
                    }
                }
            }
            return list;
        }
    }
}
