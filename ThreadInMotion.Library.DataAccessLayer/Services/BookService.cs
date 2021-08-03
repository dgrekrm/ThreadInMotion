using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ThreadInMotion.Library.DataAccessLayer.Interfaces;
using ThreadInMotion.Library.SharedModels.Models;

namespace ThreadInMotion.Library.DataAccessLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IConfiguration _configuration;

        public BookService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Create(Book entity)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("usp_INS_Book", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Author", entity.Author);
                    cmd.Parameters.AddWithValue("@Isbn", entity.Isbn);
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(cmd.Parameters["@Id"].Value);
                }
            }
        }

        public IEnumerable<Book> Read(Book entity)
        {
            var list = new List<Book> { };
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                using (SqlCommand cmd = new SqlCommand("usp_SEL_Book", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", entity.Name ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Author", entity.Author ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Isbn", entity.Isbn ?? string.Empty);

                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Book
                        {
                            Name = Convert.ToString(reader[nameof(Book.Name)]),
                            Isbn = Convert.ToString(reader[nameof(Book.Isbn)]),
                            Author = Convert.ToString(reader[nameof(Book.Author)])
                        });
                    }

                }
            }
            return list;
        }
    }
}
