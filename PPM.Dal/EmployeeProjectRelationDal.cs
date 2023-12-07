using PPM.Model;
using System.Data.SqlClient;

namespace PPM.Dal
{
    public class EmployeeProjectRelationDal
    {
        readonly string connectionString = "Server=RHJ-9F-D218\\SQLEXPRESS; Database=PPM; Integrated Security=SSPI";

        public EmployeeProjectRelationDal()
        {

        }

        public void AddProEmpRel(EmployeeProjectRelationClass employeeProjectRelationClass)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = "INSERT INTO PPM_ProEmpRel (ProjectId, EmployeeId, RoleId) VALUES (@ProjectId, @EmployeeId, @RoleId)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ProjectId", employeeProjectRelationClass.ProjectId);
                        cmd.Parameters.AddWithValue("@EmployeeId", employeeProjectRelationClass.EmployeeId);
                        cmd.Parameters.AddWithValue("@RoleId", employeeProjectRelationClass.RoleId);

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

        public List<EmployeeProjectRelationClass> GetAllProEmpRel()
        {
            List<EmployeeProjectRelationClass> employeeList = new List<EmployeeProjectRelationClass>(); // Use a local list instead of a static list
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = "SELECT Id, ProjectId, EmployeeId, RoleId, Status FROM PPM_ProEmpRel;";
                    SqlCommand cm = new SqlCommand(query, con);

                    using (SqlDataReader sdr = cm.ExecuteReader()) // Use 'using' statement to ensure the SqlDataReader is properly disposed
                    {
                        while (sdr.Read()) // Iterating Data
                        {
                            EmployeeProjectRelationClass employeeProjectRelationClass = new()
                            {
                                Id = (long)sdr["Id"],
                                ProjectId = (long)sdr["ProjectId"],
                                EmployeeId = (long)sdr["EmployeeId"],
                                RoleId = (long)sdr["RoleId"],
                                Status = sdr["Status"]?.ToString() ?? string.Empty
                            };
                            employeeList.Add(employeeProjectRelationClass);
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

            return employeeList;
        }

        public List<EmployeeProjectRelationClass> GetProEmpRelByProjectId(long ProjectId)
        {
            List<EmployeeProjectRelationClass> employeeList = new List<EmployeeProjectRelationClass>(); // Use a local list instead of a static list
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = $"SELECT Id, ProjectId, EmployeeId, RoleId, Status FROM PPM_ProEmpRel where ProjectId = {ProjectId};";
                    SqlCommand cm = new SqlCommand(query, con);

                    using (SqlDataReader sdr = cm.ExecuteReader()) // Use 'using' statement to ensure the SqlDataReader is properly disposed
                    {
                        while (sdr.Read()) // Iterating Data
                        {
                            EmployeeProjectRelationClass employeeProjectRelationClass = new()
                            {
                                Id = (long)sdr["Id"],
                                ProjectId = (long)sdr["ProjectId"],
                                EmployeeId = (long)sdr["EmployeeId"],
                                RoleId = (long)sdr["RoleId"],
                                Status = sdr["Status"]?.ToString() ?? string.Empty
                            };
                            employeeList.Add(employeeProjectRelationClass);
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

            return employeeList;
        }

        public List<EmployeeProjectRelationClass> GetProEmpRelByEmployeeId(long EmployeeId)
        {
            List<EmployeeProjectRelationClass> employeeList = new List<EmployeeProjectRelationClass>(); // Use a local list instead of a static list
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = $"SELECT Id, ProjectId, EmployeeId, RoleId, Status FROM PPM_ProEmpRel where EmployeeId = {EmployeeId};";
                    SqlCommand cm = new SqlCommand(query, con);

                    using (SqlDataReader sdr = cm.ExecuteReader()) // Use 'using' statement to ensure the SqlDataReader is properly disposed
                    {
                        while (sdr.Read()) // Iterating Data
                        {
                            EmployeeProjectRelationClass employeeProjectRelationClass = new()
                            {
                                Id = (long)sdr["Id"],
                                ProjectId = (long)sdr["ProjectId"],
                                EmployeeId = (long)sdr["EmployeeId"],
                                RoleId = (long)sdr["RoleId"],
                                Status = sdr["Status"]?.ToString() ?? string.Empty
                            };
                            employeeList.Add(employeeProjectRelationClass);
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

            return employeeList;
        }

        public List<EmployeeProjectRelationClass> GetProEmpRelByProjectIdAndEmployeeId(long ProjectId, long EmployeeId)
        {
            List<EmployeeProjectRelationClass> employeeList = new List<EmployeeProjectRelationClass>(); // Use a local list instead of a static list
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = $"SELECT Id, ProjectId, EmployeeId, RoleId, Status FROM PPM_ProEmpRel where ProjectId ={ProjectId} And EmployeeId = {EmployeeId};";
                    SqlCommand cm = new SqlCommand(query, con);

                    using (SqlDataReader sdr = cm.ExecuteReader()) // Use 'using' statement to ensure the SqlDataReader is properly disposed
                    {
                        while (sdr.Read()) // Iterating Data
                        {
                            EmployeeProjectRelationClass employeeProjectRelationClass = new()
                            {
                                Id = (long)sdr["Id"],
                                ProjectId = (long)sdr["ProjectId"],
                                EmployeeId = (long)sdr["EmployeeId"],
                                RoleId = (long)sdr["RoleId"],
                                Status = sdr["Status"]?.ToString() ?? string.Empty
                            };
                            employeeList.Add(employeeProjectRelationClass);
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

            return employeeList;
        }

        public void DeleteProEmpRel(long Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = "UPDATE PPM_ProEmpRel SET Status = 'Inactive' WHERE Id = @Id;";


                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
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

        public bool EmployeeExistsInProject(long ProjectId, long EmployeeId)
        {
            bool check = false; // Initialize to a default value

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = $"SELECT * FROM PPM_ProEmpRel WHERE ProjectId = {ProjectId} AND EmployeeId = {EmployeeId} AND Status = 'Active'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        check = reader.Read(); // Check if there are rows
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return check;
        }
        

        public bool EmployeeActiveInProject(long ProjectId)
        {
            bool check = false; // Initialize to a default value

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = $"SELECT * FROM PPM_ProEmpRel WHERE ProjectId = {ProjectId} AND Status = 'Active'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        check = reader.Read(); // Check if there are rows
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return check;
        }

        public bool EmployeeActiveAsRole(long RoleId)
        {
            bool check = false; // Initialize to a default value

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = $"SELECT * FROM PPM_ProEmpRel WHERE RoleId = {RoleId} AND Status = 'Active'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        check = reader.Read(); // Check if there are rows
                    }
                }

            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return check;
        }

        public bool EmployeeExistsInProject(long EmployeeId)
        {
            bool check = false; // Initialize to a default value

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = $"SELECT * FROM PPM_ProEmpRel WHERE EmployeeId = {EmployeeId} AND Status = 'Active'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        check = reader.Read(); // Check if there are rows
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return check;
        }
    }
}