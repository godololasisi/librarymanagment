using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using BibliotecaBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BibliotecaDomain.Users;
using BibliotecaBusiness.Common.Constants;

namespace BibliotecaInfrastructure.Persistence.Repositories.UserRepository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly IConfiguration? _config;
        public UserRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<User>> GetListAsync()
        {
            var users = new List<User>();
            using (var connection = GetConnection(_config))
            {
                SqlCommand cmd = new SqlCommand(StoredProceduresConstants.GetUsersAsync, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var user = new User();
                        user.Id = Convert.ToInt32(rdr["Id"]);
                        user.Names = Convert.ToString(rdr["Names"])!;
                        user.LastName = Convert.ToString(rdr["LastName"])!;
                        user.IdentificationNumber = Convert.ToString(rdr["IdentificationNumber"]);
                        user.PhoneNumber = Convert.ToInt32(rdr["PhoneNumber"]);
                        user.IsActive = Convert.ToBoolean(rdr["IsActive"]);
                        user.Email = Convert.ToString(rdr["Email"]);
                        user.DescriptionRole = Convert.ToString(rdr["DescriptionRole"]);
                        users.Add(user);
                    }
                }
                connection.Close();
            }
            return users;
        }
    }
}
