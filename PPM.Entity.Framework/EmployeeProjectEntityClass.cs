using PPM.Model;

namespace PPM.Entity.Framework
{
    public class EmployeeProjectEntityClass
    {
        private List<EmployeeProjectRelationClass> employeeProjectList { get; set; } = new List<EmployeeProjectRelationClass>();

        public void AddProEmpRel(EmployeeProjectRelationClass employeeProjectRelation)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    context.PPM_ProEmpRel.Add(employeeProjectRelation);
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

        public List<EmployeeProjectRelationClass> GetAllProEmpRel()
        {
            employeeProjectList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    
                    employeeProjectList.AddRange(context.PPM_ProEmpRel.ToList());
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return employeeProjectList;
        }

        public List<EmployeeProjectRelationClass> GetProEmpRelByProjectId(long ProjectId)
        {
            employeeProjectList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    employeeProjectList.AddRange(context.PPM_ProEmpRel.Where(e => e.ProjectId == ProjectId).ToList());
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return employeeProjectList;
        }

        public List<EmployeeProjectRelationClass> GetProEmpRelByEmployeeId(long EmployeeId)
        {
            employeeProjectList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    employeeProjectList.AddRange(context.PPM_ProEmpRel.Where(e => e.EmployeeId == EmployeeId).ToList());
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return employeeProjectList;
        }

        public List<EmployeeProjectRelationClass> GetProEmpRelByProjectIdAndEmployeeId(long ProjectId, long EmployeeId)
        {
            employeeProjectList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    employeeProjectList.AddRange(context.PPM_ProEmpRel.Where(e => e.ProjectId == ProjectId && e.EmployeeId == EmployeeId).ToList());
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return employeeProjectList;
        }

        public void DeleteProEmpRel(long Id)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var relation = context.PPM_ProEmpRel.Find(Id);
                    if (relation != null)
                    {
                        relation.Status = "Inactive";
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

        public bool EmployeeExistsInProject(long ProjectId, long EmployeeId)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    return context.PPM_ProEmpRel.Any(e => e.ProjectId == ProjectId && e.EmployeeId == EmployeeId && e.Status == "Active");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }
        }

        public bool EmployeeActiveInProject(long ProjectId)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    return context.PPM_ProEmpRel.Any(e => e.ProjectId == ProjectId && e.Status == "Active");
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
                    return context.PPM_ProEmpRel.Any(e => e.RoleId == RoleId && e.Status == "Active");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }
        }

        public bool EmployeeExistsInProject(long EmployeeId)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    return context.PPM_ProEmpRel.Any(e => e.EmployeeId == EmployeeId && e.Status == "Active");
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