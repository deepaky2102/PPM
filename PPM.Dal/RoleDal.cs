using PPM.Model;
using System.Data;
using System.Data.SqlClient;

namespace PPM.Dal
{
    public class RoleDal
    {
        readonly string connectionString = "Server=RHJ-9F-D218\\SQLEXPRESS; Database=PPM; Integrated Security=SSPI";
        public RoleDal()
        {

        }

        public void AddRole(RoleClass roleClass)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO PPM_Role (Name) VALUES (@Name)";

                    // Use parameterized query to handle special characters
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = roleClass.Name;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }
        }


        public List<RoleClass> GetAllRole()
        {
            List<RoleClass> RoleList = new List<RoleClass>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = "SELECT RoleId, Name FROM PPM_Role;";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            RoleClass roleClass = new()
                            {
                                RoleId = (long)sdr["RoleId"],
                                Name = sdr["Name"]?.ToString() ?? string.Empty
                            };
                            RoleList.Add(roleClass);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return RoleList;
        }

        public List<RoleClass> GetRoleById(long id)
        {
            List<RoleClass> RoleList = new List<RoleClass>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = $"SELECT RoleId, Name FROM PPM_Role WHERE RoleId = {id};";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            RoleClass roleClass = new()
                            {
                                RoleId = (long)sdr["RoleId"],
                                Name = sdr["Name"]?.ToString() ?? string.Empty
                            };
                            RoleList.Add(roleClass);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return RoleList;
        }

        public List<RoleClass> GetRoleByName(string name)
        {
            List<RoleClass> RoleList = new List<RoleClass>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = "SELECT RoleId, Name FROM PPM_Role WHERE Name LIKE @Name;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", $"%{name}%");
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                RoleClass roleClass = new()
                                {
                                    RoleId = (long)sdr["RoleId"],
                                    Name = sdr["Name"]?.ToString() ?? string.Empty
                                };
                                RoleList.Add(roleClass);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return RoleList;
        }


        public void DeleteRole(long RoleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = "DELETE FROM PPM_Role WHERE RoleId = @RoleId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@RoleId", RoleId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }
        }

        public bool RoleExist(long roleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT 1 FROM PPM_Role WHERE RoleId = @RoleId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@RoleId", roleId);
                        return cmd.ExecuteScalar() != null;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }
        }

    }
}