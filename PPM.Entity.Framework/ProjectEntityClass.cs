using PPM.Model;

namespace PPM.Entity.Framework
{
    public class ProjectEntityClass
    {
        private List<ProjectClass> projectList { get; set; } = new List<ProjectClass>(); // Change to instance field

        public void AddProject(ProjectClass project)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    context.PPM_Project.Add(project);
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

        public List<ProjectClass> GetAllProject()
        {
            projectList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    projectList.AddRange(context.PPM_Project.ToList());
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return projectList;
        }

        public List<ProjectClass> GetProjectById(long ProjectId)
        {
            projectList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var project = context.PPM_Project.Find(ProjectId);
                    if (project != null)
                    {
                        projectList.Add(project);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return projectList;
        }

        public List<ProjectClass> GetProjectByName(string Name)
        {
            projectList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var projects = context.PPM_Project
                                          .Where(e => e.Name.Contains(Name))
                                          .ToList();

                    projectList.AddRange(projects);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return projectList;
        }

        public void DeleteProject(long ProjectId)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var project = context.PPM_Project.Find(ProjectId);
                    if (project != null)
                    {
                        context.PPM_Project.Remove(project);
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

        public bool ProjectExist(long ProjectId)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    return context.PPM_Project.Any(e => e.ProjectId == ProjectId);
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