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

        public List<EmployeeProjectRelationClass> GetEmployeeProjectById(long Id)
        {
            employeeProjectList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var EmployeeProject = context.PPM_ProEmpRel.Find(Id);
                    if (EmployeeProject != null)
                    {
                        employeeProjectList.Add(EmployeeProject);
                    }
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
                        context.PPM_ProEmpRel.Remove(relation);
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
                    return context.PPM_ProEmpRel.Any(e => e.ProjectId == ProjectId && e.EmployeeId == EmployeeId);
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
                    return context.PPM_ProEmpRel.Any(e => e.ProjectId == ProjectId);
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
                    return context.PPM_ProEmpRel.Any(e => e.EmployeeId == EmployeeId);
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