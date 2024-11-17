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
    internal class PelangganContext : DatabaseWrapper
    {
        public static bool LoginPelanggan(string username, string password)
        {
            try
            {
                string loginQuery = "SELECT COUNT(*) FROM pelanggan WHERE username_pelanggan = @username AND password_pelanggan = @password";
                NpgsqlParameter[] loginParams = {
                    new NpgsqlParameter("@username", NpgsqlDbType.Varchar) { Value = username},
                    new NpgsqlParameter("@password", NpgsqlDbType.Varchar) { Value = password}
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
