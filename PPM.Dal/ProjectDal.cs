using PPM.Model;
using System.Data.SqlClient;

namespace PPM.Dal
{
    public class ProjectDal
    {
        readonly string connectionString = "Server=RHJ-9F-D218\\SQLEXPRESS; Database=PPM; Integrated Security=SSPI";

        public ProjectDal()
        {

        }

        public long GetLastProjectId()
        {
            long lastProjectId = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT TOP 1 ProjectId FROM PPM_Project ORDER BY ProjectId DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lastProjectId = reader.GetInt64(0); // Assuming ProjectId is of type LONG
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return lastProjectId;
        }

        public void AddProject(ProjectClass projectClass)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO PPM_Project (Name, StartDate, EndDate) VALUES (@Name, @StartDate, @EndDate)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", projectClass.Name);
                        cmd.Parameters.AddWithValue("@StartDate", projectClass.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", projectClass.EndDate);
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

        public List<ProjectClass> GetAllProject()
        {
            List<ProjectClass> ProjectList = new List<ProjectClass>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = "SELECT ProjectId, Name, StartDate, EndDate FROM PPM_Project;";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ProjectClass projectClass = new()
                            {
                                ProjectId = (long)sdr["ProjectId"],
                                Name = sdr["Name"]?.ToString() ?? string.Empty,
                                StartDate = sdr["StartDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)sdr["StartDate"],
                                EndDate = sdr["EndDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)sdr["EndDate"]
                            };
                            ProjectList.Add(projectClass);
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

            return ProjectList;
        }

        public List<ProjectClass> GetProjectById(long id)
        {
            List<ProjectClass> ProjectList = new List<ProjectClass>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = $"SELECT ProjectId, Name, StartDate, EndDate FROM PPM_Project WHERE ProjectId = {id};";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ProjectClass projectClass = new()
                            {
                                ProjectId = (long)sdr["ProjectId"],
                                Name = sdr["Name"]?.ToString() ?? string.Empty,
                                StartDate = sdr["StartDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)sdr["StartDate"],
                                EndDate = sdr["EndDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)sdr["EndDate"]
                            };
                            ProjectList.Add(projectClass);
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

            return ProjectList;
        }

        public List<ProjectClass> GetProjectByName(string Name)
        {
            List<ProjectClass> ProjectList = new List<ProjectClass>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = $"SELECT ProjectId, Name, StartDate, EndDate FROM PPM_Project WHERE Name LIKE '%{Name}%';";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ProjectClass projectClass = new()
                            {
                                ProjectId = (long)sdr["ProjectId"],
                                Name = sdr["Name"]?.ToString() ?? string.Empty,
                                StartDate = sdr["StartDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)sdr["StartDate"],
                                EndDate = sdr["EndDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)sdr["EndDate"]
                            };
                            ProjectList.Add(projectClass);
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

            return ProjectList;
        }

        public void DeleteProject(long ProjectId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = "DELETE FROM PPM_Project WHERE ProjectId = @ProjectId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
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

        public bool ProjectExist(long projectId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "IF EXISTS (SELECT 1 FROM PPM_Project WHERE ProjectId = @ProjectId) SELECT 1 ELSE SELECT 0";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ProjectId", projectId);
                        return (int)cmd.ExecuteScalar() == 1;
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