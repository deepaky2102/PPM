using PPM.Model;

namespace PPM.Entity.Framework
{
    public class RoleEntityClass
    {
        private List<RoleClass> roleList {get; set;} = new List<RoleClass>();

        public void AddRole(RoleClass role)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    context.PPM_Role.Add(role);
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

        public List<RoleClass> GetAllRole()
        {
            try
            {
                roleList.Clear();
                using (var context = new EntityFrameworkClass())
                {
                    roleList.AddRange(context.PPM_Role.ToList());
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return roleList;
        }

        public List<RoleClass> GetRoleById(long RoleId)
        {
            roleList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var role = context.PPM_Role.Find(RoleId);
                    if (role != null)
                    {
                        roleList.Add(role);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return roleList;
        }

        public List<RoleClass> GetRoleByName(string Name)
        {
            roleList.Clear();
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var roles = context.PPM_Role
                                       .Where(e => e.Name.Contains(Name))
                                       .ToList();

                    roleList.AddRange(roles);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the calling code
            }

            return roleList;
        }

        public void DeleteRole(long RoleId)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    var role = context.PPM_Role.Find(RoleId);
                    if (role != null)
                    {
                        context.PPM_Role.Remove(role);
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

        public bool RoleExist(long RoleId)
        {
            try
            {
                using (var context = new EntityFrameworkClass())
                {
                    return context.PPM_Role.Any(e => e.RoleId == RoleId);
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