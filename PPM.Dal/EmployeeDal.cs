using PPM.Model;
using System.Data.SqlClient;

namespace PPM.Dal
{
    public class EmployeeDal
    {
        readonly string connectionString = "Server=RHJ-9F-D218\\SQLEXPRESS; Database=PPM; Integrated Security=SSPI";

        public EmployeeDal()
        {

        }

        public void AddEmployee(EmployeeClass employeeClass)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = "INSERT INTO PPM_Employee (FirstName, LastName, Email, MobileNumber, Address, RoleId) VALUES (@FirstName, @LastName, @Email, @MobileNumber, @Address, @RoleId)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", employeeClass.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", employeeClass.LastName);
                        cmd.Parameters.AddWithValue("@Email", employeeClass.Email);
                        cmd.Parameters.AddWithValue("@MobileNumber", employeeClass.MobileNumber);
                        cmd.Parameters.AddWithValue("@Address", employeeClass.Address);
                        cmd.Parameters.AddWithValue("@RoleId", employeeClass.RoleId);

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

        public List<EmployeeClass> GetAllemployee()
        {
            List<EmployeeClass> employeeList = new List<EmployeeClass>(); // Use a local list instead of a static list
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = "SELECT EmployeeId, FirstName, LastName, Email, MobileNumber, Address, RoleId FROM PPM_Employee;";
                    SqlCommand cm = new SqlCommand(query, con);

                    using (SqlDataReader sdr = cm.ExecuteReader()) // Use 'using' statement to ensure the SqlDataReader is properly disposed
                    {
                        while (sdr.Read()) // Iterating Data
                        {
                            EmployeeClass employeeClass = new()
                            {
                                EmployeeId = (long)sdr["EmployeeId"],
                                FirstName = sdr["FirstName"]?.ToString() ?? string.Empty,
                                LastName = sdr["LastName"]?.ToString() ?? string.Empty,
                                Email = sdr["Email"]?.ToString() ?? string.Empty,
                                MobileNumber = sdr["MobileNumber"]?.ToString() ?? string.Empty,
                                Address = sdr["Address"]?.ToString() ?? string.Empty,
                                RoleId = (long)sdr["RoleId"]
                            };

                            employeeList.Add(employeeClass);
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

        public List<EmployeeClass> GetEmployeeById(long id)
        {
            List<EmployeeClass> employeeList = new List<EmployeeClass>(); // Use a local list instead of a static list
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = $"Select EmployeeId, FirstName, LastName, Email, MobileNumber, Address, RoleId From PPM_Employee where EmployeeId = {id};";
                    SqlCommand cm = new SqlCommand(query, con);

                    using (SqlDataReader sdr = cm.ExecuteReader()) // Use 'using' statement to ensure the SqlDataReader is properly disposed
                    {
                        while (sdr.Read()) // Iterating Data
                        {
                            EmployeeClass employeeClass = new()
                            {
                                EmployeeId = (long)sdr["EmployeeId"],
                                FirstName = sdr["FirstName"]?.ToString() ?? string.Empty,
                                LastName = sdr["LastName"]?.ToString() ?? string.Empty,
                                Email = sdr["Email"]?.ToString() ?? string.Empty,
                                MobileNumber = sdr["MobileNumber"]?.ToString() ?? string.Empty,
                                Address = sdr["Address"]?.ToString() ?? string.Empty,
                                RoleId = (long)sdr["RoleId"]
                            };

                            employeeList.Add(employeeClass);
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

        public List<EmployeeClass> GetEmployeeByFirstName(string FirstName)
        {
            List<EmployeeClass> employeeList = new List<EmployeeClass>(); // Use a local list instead of a static list
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = $"SELECT EmployeeId, FirstName, LastName, Email, MobileNumber, Address, RoleId FROM PPM_Employee WHERE FirstName LIKE '%{FirstName}%';";
                    SqlCommand cm = new SqlCommand(query, con);

                    using (SqlDataReader sdr = cm.ExecuteReader()) // Use 'using' statement to ensure the SqlDataReader is properly disposed
                    {
                        while (sdr.Read()) // Iterating Data
                        {
                            EmployeeClass employeeClass = new()
                            {
                                EmployeeId = (long)sdr["EmployeeId"],
                                FirstName = sdr["FirstName"]?.ToString() ?? string.Empty,
                                LastName = sdr["LastName"]?.ToString() ?? string.Empty,
                                Email = sdr["Email"]?.ToString() ?? string.Empty,
                                MobileNumber = sdr["MobileNumber"]?.ToString() ?? string.Empty,
                                Address = sdr["Address"]?.ToString() ?? string.Empty,
                                RoleId = (long)sdr["RoleId"]
                            };

                            employeeList.Add(employeeClass);
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

        public List<EmployeeClass> GetEmployeeByLastName(string LastName)
        {
            List<EmployeeClass> employeeList = new List<EmployeeClass>(); // Use a local list instead of a static list
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = $"SELECT EmployeeId, FirstName, LastName, Email, MobileNumber, Address, RoleId FROM PPM_Employee WHERE LastName LIKE '%{LastName}%';";
                    SqlCommand cm = new SqlCommand(query, con);

                    using (SqlDataReader sdr = cm.ExecuteReader()) // Use 'using' statement to ensure the SqlDataReader is properly disposed
                    {
                        while (sdr.Read()) // Iterating Data
                        {
                            EmployeeClass employeeClass = new()
                            {
                                EmployeeId = (long)sdr["EmployeeId"],
                                FirstName = sdr["FirstName"]?.ToString() ?? string.Empty,
                                LastName = sdr["LastName"]?.ToString() ?? string.Empty,
                                Email = sdr["Email"]?.ToString() ?? string.Empty,
                                MobileNumber = sdr["MobileNumber"]?.ToString() ?? string.Empty,
                                Address = sdr["Address"]?.ToString() ?? string.Empty,
                                RoleId = (long)sdr["RoleId"]
                            };

                            employeeList.Add(employeeClass);
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

        public List<EmployeeClass> GetEmployeeByFullName(string FirstName, string LastName)
        {
            List<EmployeeClass> employeeList = new List<EmployeeClass>(); // Use a local list instead of a static list
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection
                    string query = $"SELECT EmployeeId, FirstName, LastName, Email, MobileNumber, Address, RoleId FROM PPM_Employee WHERE FirstName LIKE '%{FirstName}%' AND LastName LIKE '%{LastName}%';";
                    SqlCommand cm = new SqlCommand(query, con);

                    using (SqlDataReader sdr = cm.ExecuteReader()) // Use 'using' statement to ensure the SqlDataReader is properly disposed
                    {
                        while (sdr.Read()) // Iterating Data
                        {
                            EmployeeClass employeeClass = new()
                            {
                                EmployeeId = (long)sdr["EmployeeId"],
                                FirstName = sdr["FirstName"]?.ToString() ?? string.Empty,
                                LastName = sdr["LastName"]?.ToString() ?? string.Empty,
                                Email = sdr["Email"]?.ToString() ?? string.Empty,
                                MobileNumber = sdr["MobileNumber"]?.ToString() ?? string.Empty,
                                Address = sdr["Address"]?.ToString() ?? string.Empty,
                                RoleId = (long)sdr["RoleId"]
                            };

                            employeeList.Add(employeeClass);
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

        public void DeleteEmployee(long employeeId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = "DELETE FROM PPM_Employee WHERE EmployeeId = @EmployeeId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
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

        public bool EmployeeExist(long EmployeeId)
        {
            bool Check = false; // Initialize to a default value

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = $"Select EmployeeId FROM PPM_Employee WHERE EmployeeId = {EmployeeId}";
                    SqlCommand cm = new SqlCommand(query, con);

                    using (SqlDataReader sdr = cm.ExecuteReader())
                    {
                        if (sdr.Read()) // Check if there are rows
                        {
                            Check = true;
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

            return Check; // Return the default value if an error occurs
        }

        public bool EmailExist(string Email)
        {
            bool Check = false; // Initialize to a default value

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = "SELECT * FROM PPM_Employee WHERE Email = @Email";
                    SqlCommand cm = new SqlCommand(query, con);
                    cm.Parameters.AddWithValue("@Email", Email);

                    using (SqlDataReader sdr = cm.ExecuteReader())
                    {
                        if (sdr.Read()) // Check if there are rows
                        {
                            Check = true;
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

            return Check; // Return the default value if an error occurs
        }

        public bool MobileNumberExist(string MobileNumber)
        {
            bool Check = false; // Initialize to a default value

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Opening Connection

                    string query = "SELECT * FROM PPM_Employee WHERE MobileNumber = @MobileNumber";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read()) // Check if there are rows
                        {
                            Check = true;
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

            return Check; // Return the default value if an error occurs
        }

        public bool EmployeeActiveAsRole(long RoleId)
        {
            bool check = false; // Initialize to a default value

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open(); // Opening Connection

                    string query = $"SELECT * FROM PPM_Employee WHERE RoleId = {RoleId}";
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