using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform_mvc.App.Core;

namespace BengkelinAja.Context
{
    internal class BengkelContext : DatabaseWrapper
    {
        public static bool LoginBengkel(string username, string password)
        {
            try
            {
                string loginQuery = "SELECT COUNT(*) FROM bengkel WHERE username = @username AND password = @password";
                NpgsqlParameter[] loginParams = {
                    new NpgsqlParameter("@username", NpgsqlDbType.Varchar) { Value = username },
                    new NpgsqlParameter("@password", NpgsqlDbType.Varchar) { Value = password }
                };

                DataTable result = queryExecutor(loginQuery, loginParams);
                return Convert.ToInt32(result.Rows[0][0]) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error during login: " + ex.Message);
            }

        }
    }
}
