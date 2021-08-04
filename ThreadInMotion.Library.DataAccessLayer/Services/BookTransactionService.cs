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
    public class BookTransactionService : IBookTransactionsService
    {
        private readonly IConfiguration _configuration;

        public BookTransactionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int Create(BookTransaction entity)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("usp_INS_BookTransaction", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId", entity.BookId);
                    cmd.Parameters.AddWithValue("@MemberId", entity.MemberId);
                    cmd.Parameters.AddWithValue("@ExitDate", entity.ExitDate);
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(cmd.Parameters["@Id"].Value);
                }
            }
        }

        public void Update(BookTransaction entity)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UPD_BookTransaction", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId", entity.BookId);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
