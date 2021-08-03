using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using ThreadInMotion.Library.DataAccessLayer.Interfaces;
using ThreadInMotion.Library.SharedModels.Models;

namespace ThreadInMotion.Library.DataAccessLayer.Services
{
    public class MemberService : IMemberService
    {
        private readonly IConfiguration _configuration;

        public MemberService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Create(Member entity)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("usp_INS_Member", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FullName", entity.FullName);
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(cmd.Parameters["@Id"].Value);
                }
            }
        }
    }
}
