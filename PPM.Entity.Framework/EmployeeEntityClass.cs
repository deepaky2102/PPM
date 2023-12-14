using PPM.Model;
namespace PPM.Entity.Framework
{
    public class EmployeeEntityClass
    {
        private List<EmployeeClass> employeeList { get; set; } = new List<EmployeeClass>(); // Change to instance field

        public void AddEmployee(EmployeeClass employee)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    context.PPM_Employee.Add(employee);
                    context.SaveChanges();
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
            employeeList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    employeeList.AddRange(context.PPM_Employee.ToList());
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

        public List<EmployeeClass> GetEmployeeById(long EmployeeId)
        {
            employeeList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var emp = context.PPM_Employee.Find(EmployeeId);
                    if (emp != null)
                    {
                        employeeList.Add(emp);
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
            employeeList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var employees = context.PPM_Employee
                                          .Where(e => e.FirstName.Contains(FirstName))
                                          .ToList();

                    employeeList.AddRange(employees);
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
            employeeList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var employees = context.PPM_Employee
                                          .Where(e => e.LastName.Contains(LastName))
                                          .ToList();

                    employeeList.AddRange(employees);
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
            employeeList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var employees = context.PPM_Employee
                                          .Where(e => e.FirstName.Contains(FirstName) && e.LastName.Contains(LastName))
                                          .ToList();

                    employeeList.AddRange(employees);
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

        public void DeleteEmployee(long EmployeeId)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var employee = context.PPM_Employee.Find(EmployeeId);
                    if (employee != null)
                    {
                        context.PPM_Employee.Remove(employee);
                        context.SaveChanges();
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
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    return context.PPM_Employee.Any(e => e.EmployeeId == EmployeeId);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }
        }

        public bool EmailExist(string Email)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    return context.PPM_Employee.Any(e => e.Email == Email);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }
        }

        public bool MobileNumberExist(string MobileNumber)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    return context.PPM_Employee.Any(e => e.MobileNumber == MobileNumber);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }
        }

        public bool EmployeeActiveAsRole(long RoleId)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    return context.PPM_Employee.Any(e => e.RoleId == RoleId);
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