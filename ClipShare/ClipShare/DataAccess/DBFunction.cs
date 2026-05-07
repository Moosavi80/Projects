using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DBFunction
    {
        public string CreateConnectionString()
        {
            return @"Server=.\MHD2022;Database=youTube;User Id=sa;Password=138043148122@@;TrustServerCertificate=True";
        }

        public async Task<DataTable> Pr_Select_Login(string UserName, string Password)
        {
            SqlConnection sqlConnection = new SqlConnection(CreateConnectionString());
            SqlCommand sqlCommand = new SqlCommand("Pr_Login", sqlConnection);
            try
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;
                sqlCommand.Parameters.Add("@PassWord", SqlDbType.NVarChar).Value = Password;

                await sqlConnection.OpenAsync();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                DataTable table = new DataTable();
                table.Load(reader);

                return table;
            }
            catch
            {
                return null;
            }
            finally { sqlConnection.Close(); }
        }

        public async Task<string> Pr_InsUp_SignUp(string Name, string Password, bool IsAdmin)
        {
            SqlConnection sqlConnection = new SqlConnection(CreateConnectionString());
            SqlCommand sqlCommand = new SqlCommand("Pr_SignUp", sqlConnection);
            try
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;
                sqlCommand.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = IsAdmin;

                SqlParameter resParam = new SqlParameter("@ResId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };
                sqlCommand.Parameters.Add(resParam);

                await sqlConnection.OpenAsync();

                await sqlCommand.ExecuteNonQueryAsync();

                long res = Convert.ToInt64(resParam.Value);

                return res.ToString();
            }
            catch
            {
                return "0";
            }
            finally { sqlConnection.Close(); }
        }

        public async Task<DataTable> Pr_Select_Channel(string Id)
        {
            SqlConnection sqlConnection = new SqlConnection(CreateConnectionString());
            SqlCommand sqlCommand = new SqlCommand("Pr_Select_Channel", sqlConnection);
            try
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = $"SELECT * FROM dbo.Channel ch WHERE ch.Del = 0 AND ch.AppUserId = {Id}";
                await sqlConnection.OpenAsync();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                DataTable table = new DataTable();
                table.Load(reader);

                return table;
            }
            catch
            {
                return null;
            }
            finally { sqlConnection.Close(); }
        }


        public async Task<string> Pr_InsUp_Channel(string Channel, string About, string UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(CreateConnectionString());
            SqlCommand sqlCommand = new SqlCommand("Pr_InsUp_Channel", sqlConnection);
            try
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Channel", SqlDbType.NVarChar).Value = Channel;
                sqlCommand.Parameters.Add("@About", SqlDbType.NVarChar).Value = About;
                sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                SqlParameter resParam = new SqlParameter("@ResId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };
                sqlCommand.Parameters.Add(resParam);

                await sqlConnection.OpenAsync();

                await sqlCommand.ExecuteNonQueryAsync();

                long res = Convert.ToInt64(resParam.Value);

                return res.ToString();
            }
            catch
            {
                return "0";
            }
            finally { sqlConnection.Close(); }
        }


        public async Task<DataTable> Pr_Select_Category()
        {
            SqlConnection sqlConnection = new SqlConnection(CreateConnectionString());
            SqlCommand sqlCommand = new SqlCommand("Pr_Select_Category", sqlConnection);
            try
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlConnection.OpenAsync();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                DataTable table = new DataTable();
                table.Load(reader);

                return table;
            }
            catch
            {
                return null;
            }
            finally { sqlConnection.Close(); }
        }

        public async Task<string> Pr_InsUp_Category(string Id, string Name)
        {
            SqlConnection sqlConnection = new SqlConnection(CreateConnectionString());
            SqlCommand sqlCommand = new SqlCommand("Pr_InsUp_Category", sqlConnection);
            try
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                sqlCommand.Parameters.Add("@Id", SqlDbType.NVarChar).Value = Id;

                SqlParameter resParam = new SqlParameter("@ResId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };
                sqlCommand.Parameters.Add(resParam);

                await sqlConnection.OpenAsync();

                await sqlCommand.ExecuteNonQueryAsync();

                long res = Convert.ToInt64(resParam.Value);

                return res.ToString();
            }
            catch
            {
                return "";
            }
            finally { sqlConnection.Close(); }
        }

        public async Task<string> Pr_Del_Category(string Id)
        {
            SqlConnection sqlConnection = new SqlConnection(CreateConnectionString());
            SqlCommand sqlCommand = new SqlCommand("Pr_Del_Category", sqlConnection);
            try
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Id", SqlDbType.NVarChar).Value = Id;

                SqlParameter resParam = new SqlParameter("@ResId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };
                sqlCommand.Parameters.Add(resParam);

                await sqlConnection.OpenAsync();

                await sqlCommand.ExecuteNonQueryAsync();

                long res = Convert.ToInt64(resParam.Value);

                return res.ToString();
            }
            catch
            {
                return "0";
            }
            finally { sqlConnection.Close(); }
        }


    }
}
