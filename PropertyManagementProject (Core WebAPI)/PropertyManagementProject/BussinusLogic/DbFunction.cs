using DataAccess.DTOs.Block;
using DataAccess.DTOs.BoardMembers;
using DataAccess.DTOs.OfficialExperts;
using DataAccess.DTOs.Plot;
using DataAccess.DTOs.TownShip;
using DataAccess.DTOs.Users;
using ErrorLogs.FileLogger;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BussinusLogic
{
    public class DbFunction
    {
        private readonly string _connectionString;

        public DbFunction(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<DataTable?> Pr_Select_Login(string UserName, string Password, string Type = "0")
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand sqlCommand = new SqlCommand("Pr_Select_Login", sqlConnection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;
                    sqlCommand.Parameters.Add("@PassWord", SqlDbType.NVarChar).Value = Password;
                    sqlCommand.Parameters.Add("@Type", SqlDbType.NVarChar).Value = Type;

                    await sqlConnection.OpenAsync();

                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                    DataTable table = new DataTable();
                    table.Load(reader);

                    return table;
                }
                catch { return null; }
                finally { sqlConnection.Close(); }
            }
        }

        public async Task<bool> Pr_SaveRefreshToken(string UserId, string TokenHash, DateTime ExpireDate, string IPAddress, string Device)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_SaveRefreshToken", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", UserId);
                    cmd.Parameters.AddWithValue("@TokenHash", TokenHash);
                    cmd.Parameters.AddWithValue("@ExpireDate", ExpireDate);
                    cmd.Parameters.AddWithValue("@Device", Device ?? "");
                    cmd.Parameters.AddWithValue("@IPAddress", IPAddress ?? "");

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch { return false; }
                finally { con.Close(); }
            }
        }

        public async Task<DataTable?> Pr_GetRefreshToken(string tokenHash)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand sqlCommand = new SqlCommand("Pr_GetRefreshToken", sqlConnection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@TokenHash", tokenHash);

                    await sqlConnection.OpenAsync();

                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                    DataTable table = new DataTable();
                    table.Load(reader);

                    return table;
                }
                catch { return null; }
                finally { sqlConnection.Close(); }
            }
        }

        public async Task<bool> Pr_RevokeRefreshToken(string id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_RevokeRefreshToken", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch { return false; }
                finally { con.Close(); }
            }
        }

        public async Task<bool> Pr_RevokeAllRefreshTokens(string userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_RevokeAllRefreshTokens", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch { return false; }
                finally { con.Close(); }
            }
        }

        public async Task<string> Pr_ChangePassword(string userId, string OldPass, string NewPass, string NewUserName, int Type)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_ChangePassword", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Type", Type);
                    cmd.Parameters.AddWithValue("@OldPass", OldPass);
                    cmd.Parameters.AddWithValue("@NewPass", NewPass);
                    cmd.Parameters.AddWithValue("@NewUserName", NewUserName);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);


                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }

        public async Task<bool> Pr_Ins_UserLogs(string userId, string refType, string operation, string? refId = null, bool isSuccess = true, string? errorMessage = null, string? Comment = null)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_Ins_UserLogs", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@RefType", refType);
                    cmd.Parameters.AddWithValue("@Operation", operation);
                    cmd.Parameters.AddWithValue("@RefId", (object?)refId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsSuccess", isSuccess);
                    cmd.Parameters.AddWithValue("@ErrorMessage", (object?)errorMessage ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Comment", (object?)Comment ?? DBNull.Value);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch { return false; }
                finally { con.Close(); }
            }
        }

        public async Task<string> Pr_ChangeStatus_ByUser(string Id, bool Status, string userId, int type)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_ChangeStatus_ByUser", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Type", type);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }

        public bool Pr_HasPermission_ForUser(string userId, string permissionCode)
        {
            try
            {
                using SqlConnection con = new(_connectionString);
                SqlCommand cmd = new("Pr_HasPermission", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@PermissionCode", permissionCode);

                con.Open();

                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                new FileLoggerService().LogException(ex, "DBFunction::HasPermission()" + $" User:{userId} + {permissionCode}");
                return false;
            }
        }

        public async Task<string> Pr_InsUp_Users(UserInsert_Update request, string userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_InsUp_Users", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", request.ID);
                    cmd.Parameters.AddWithValue("@UserType", request.UserType);
                    cmd.Parameters.AddWithValue("@UserGroup", request.UserGroup);
                    cmd.Parameters.AddWithValue("@UserName", request.UserName);
                    cmd.Parameters.AddWithValue("@Password", request.Password);
                    cmd.Parameters.AddWithValue("@Name", request.Name);
                    cmd.Parameters.AddWithValue("@FamilyName", request.FamilyName);
                    cmd.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    cmd.Parameters.AddWithValue("@NationalNumber", request.NationalNumber);
                    cmd.Parameters.AddWithValue("@FatherName", request.FatherName);
                    cmd.Parameters.AddWithValue("@BirthDay", request.BirthDay);
                    cmd.Parameters.AddWithValue("@UserAccess", request.UserAccess);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }

        public async Task<DataTable?> Pr_Select_Users(string Id = "0")
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand sqlCommand = new SqlCommand("Pr_Select_Users", sqlConnection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                    await sqlConnection.OpenAsync();

                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                    DataTable table = new DataTable();
                    table.Load(reader);

                    return table;
                }
                catch { return null; }
                finally { sqlConnection.Close(); }
            }
        }

        public async Task<string> Pr_ChangeStatus_ForTownShip(string Number, bool Status, string userId, int type)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_ChangeStatus_ForTownShip", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Number", Number);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Type", type);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }

        public async Task<DataTable?> Pr_Select_TownShip(string Number = "0", string Type = "-1", string Value = "")
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand sqlCommand = new SqlCommand("Pr_Select_TownShip", sqlConnection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@Number", SqlDbType.NVarChar).Value = Number;
                    sqlCommand.Parameters.Add("@Type", SqlDbType.Int).Value = Type;
                    sqlCommand.Parameters.Add("@Value", SqlDbType.NVarChar).Value = Value;

                    await sqlConnection.OpenAsync();

                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                    DataTable table = new DataTable();
                    table.Load(reader);

                    return table;
                }
                catch { return null; }
                finally { sqlConnection.Close(); }
            }
        }

        public async Task<string> Pr_InsUp_TownShip(TownShip_InsUp request, string userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_InsUp_TownShip", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Number", request.Number);
                    cmd.Parameters.AddWithValue("@Name", request.Name);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.NVarChar, 4000)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }

        public async Task<string> Pr_ChangeStatus_ForBlocks(string Number, bool Status, string userId, int type)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_ChangeStatus_ForBlocks", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Number", Number);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Type", type);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }

        public async Task<string> Pr_InsUp_Blocks(Block_InsUp request, string userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_InsUp_Blocks", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BlockNumber", request.BlockNumber);
                    cmd.Parameters.AddWithValue("@TownShipNumber", request.TownShipNumber);
                    cmd.Parameters.AddWithValue("@Name", request.BlockName);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.NVarChar, 4000)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }

        public async Task<DataTable?> Pr_Select_Blocks(string Number = "0", string Type = "-1", string TypeStatus = "0", string Value = "", string PageNumber = "1", string PageSize = "10")
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand sqlCommand = new SqlCommand("Pr_Select_Blocks", sqlConnection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@Number", SqlDbType.NVarChar).Value = Number;
                    sqlCommand.Parameters.Add("@Type", SqlDbType.Int).Value = Type;
                    sqlCommand.Parameters.Add("@TypeStatus", SqlDbType.Int).Value = TypeStatus;
                    sqlCommand.Parameters.Add("@Value", SqlDbType.NVarChar).Value = Value;
                    sqlCommand.Parameters.Add("@PageNumber", SqlDbType.Int).Value = PageNumber;
                    sqlCommand.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;

                    await sqlConnection.OpenAsync();

                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                    DataTable table = new DataTable();
                    table.Load(reader);

                    return table;
                }
                catch { return null; }
                finally { sqlConnection.Close(); }
            }
        }

        public async Task<string> Pr_ChangeStatus_ForPlots(string Number, bool Status, string userId, int type)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_ChangeStatus_ForPlots", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Number", Number);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Type", type);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }

        public async Task<DataTable?> Pr_Select_Plots(string Number = "0", string Type = "-1", string SubType = "-1", string TypeStatus = "0", string Value = "", string SubValue = "", string PageNumber = "1", string PageSize = "10")
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand sqlCommand = new SqlCommand("Pr_Select_Plots", sqlConnection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@Number", SqlDbType.NVarChar).Value = Number;
                    sqlCommand.Parameters.Add("@Type", SqlDbType.Int).Value = Type;
                    sqlCommand.Parameters.Add("@SubType", SqlDbType.Int).Value = SubType;
                    sqlCommand.Parameters.Add("@TypeStatus", SqlDbType.Int).Value = TypeStatus;
                    sqlCommand.Parameters.Add("@Value", SqlDbType.NVarChar).Value = Value;
                    sqlCommand.Parameters.Add("@SubValue", SqlDbType.NVarChar).Value = SubValue;
                    sqlCommand.Parameters.Add("@PageNumber", SqlDbType.Int).Value = PageNumber;
                    sqlCommand.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;

                    await sqlConnection.OpenAsync();

                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                    DataTable table = new DataTable();
                    table.Load(reader);

                    return table;
                }
                catch { return null; }
                finally { sqlConnection.Close(); }
            }
        }

        public async Task<DataTable?> Pr_Select_LandUseTypes()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand sqlCommand = new SqlCommand("Pr_Select_LandUseTypes", sqlConnection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    await sqlConnection.OpenAsync();

                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                    DataTable table = new DataTable();
                    table.Load(reader);

                    return table;
                }
                catch { return null; }
                finally { sqlConnection.Close(); }
            }
        }

        public async Task<string> Pr_InsUp_Plots(Plot_InsUp request, string userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_InsUp_Plots", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BlockNumber", request.BlockNumber);
                    cmd.Parameters.AddWithValue("@TownShipNumber", request.TownShipNumber);
                    cmd.Parameters.AddWithValue("@PlotNumber", request.PlotNumber);
                    cmd.Parameters.AddWithValue("@PlotName", request.PlotName);
                    cmd.Parameters.AddWithValue("@Area", request.Area);
                    cmd.Parameters.AddWithValue("@LandUseType", request.LandUseType);
                    cmd.Parameters.AddWithValue("@CadastralNumber", request.CadastralNumber);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.NVarChar, 4000)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }

        public async Task<string> Pr_ChangeStatus_ForBoardMembers(string Number, bool Status, string userId, int type)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_ChangeStatus_ForBoardMembers", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Number", Number);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Type", type);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }

        public async Task<DataTable?> Pr_Select_BoardMembers(string Number = "0", string Type = "-1", string TypeStatus = "0", string Value = "", string PageNumber = "1", string PageSize = "10")
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand sqlCommand = new SqlCommand("Pr_Select_BoardMembers", sqlConnection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@Number", SqlDbType.NVarChar).Value = Number;
                    sqlCommand.Parameters.Add("@Type", SqlDbType.Int).Value = Type;
                    sqlCommand.Parameters.Add("@TypeStatus", SqlDbType.Int).Value = TypeStatus;
                    sqlCommand.Parameters.Add("@Value", SqlDbType.NVarChar).Value = Value;
                    sqlCommand.Parameters.Add("@PageNumber", SqlDbType.Int).Value = PageNumber;
                    sqlCommand.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;

                    await sqlConnection.OpenAsync();

                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                    DataTable table = new DataTable();
                    table.Load(reader);

                    return table;
                }
                catch { return null; }
                finally { sqlConnection.Close(); }
            }
        }

        public async Task<string> Pr_InsUp_BoardMembers(BoardMembers_InsUp request, string userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_InsUp_BoardMembers", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BoardMembersNumbers", request.BoardMembersNumber);
                    cmd.Parameters.AddWithValue("@Name", request.Name);
                    cmd.Parameters.AddWithValue("@FamilyName", request.FamilyName);
                    cmd.Parameters.AddWithValue("@BirthCertificateNumber", request.BirthCertificateNumber);
                    cmd.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    cmd.Parameters.AddWithValue("@NationalNumber", request.NationalNumber);
                    cmd.Parameters.AddWithValue("@FatherName", request.FatherName);
                    cmd.Parameters.AddWithValue("@BirthDay", request.BirthDay);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }

        public async Task<string> Pr_ChangeStatus_ForOfficialExperts(string Number, bool Status, string userId, int type)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_ChangeStatus_ForOfficialExperts", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Number", Number);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Type", type);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }

        public async Task<DataTable?> Pr_Select_OfficialExperts(string Number = "0", string Type = "-1", string TypeStatus = "0", string Value = "", string PageNumber = "1", string PageSize = "10")
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            using (SqlCommand sqlCommand = new SqlCommand("Pr_Select_OfficialExperts", sqlConnection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@Number", SqlDbType.NVarChar).Value = Number;
                    sqlCommand.Parameters.Add("@Type", SqlDbType.Int).Value = Type;
                    sqlCommand.Parameters.Add("@TypeStatus", SqlDbType.Int).Value = TypeStatus;
                    sqlCommand.Parameters.Add("@Value", SqlDbType.NVarChar).Value = Value;
                    sqlCommand.Parameters.Add("@PageNumber", SqlDbType.Int).Value = PageNumber;
                    sqlCommand.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;

                    await sqlConnection.OpenAsync();

                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                    DataTable table = new DataTable();
                    table.Load(reader);

                    return table;
                }
                catch { return null; }
                finally { sqlConnection.Close(); }
            }
        }

        public async Task<string> Pr_InsUp_OfficialExperts(OfficialExperts_InsUp request, string userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("Pr_InsUp_OfficialExperts", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OfficialExpertsNumbers", request.OfficialExpertsNumber);
                    cmd.Parameters.AddWithValue("@Name", request.Name);
                    cmd.Parameters.AddWithValue("@FamilyName", request.FamilyName);
                    cmd.Parameters.AddWithValue("@ExpertLicenseNumber", request.ExpertLicenseNumber);
                    cmd.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    cmd.Parameters.AddWithValue("@NationalNumber", request.NationalNumber);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    SqlParameter outputMessage = new("@ResId", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputMessage);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return outputMessage.Value?.ToString() ?? "0";
                }
                catch { return "0"; }
                finally { con.Close(); }
            }
        }
    }
}
