using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Member> Read(Member entity)
        {
            var list = new List<Member> { };
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("usp_SEL_Member", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FullName", entity.FullName ?? string.Empty);

                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Member
                        {
                            Id = Convert.ToInt32(reader[nameof(Member.Id)]),
                            FullName = Convert.ToString(reader[nameof(Member.FullName)]),
                        });
                    }
                }
            }
            return list;
        }
    }
}
