using Microsoft.EntityFrameworkCore;
using PPM.Model;
namespace PPM.Entity.Framework
{
    public class EntityFrameworkClass : DbContext
    {
        public DbSet<ProjectClass> PPM_Project { get; set; }
        public DbSet<EmployeeClass> PPM_Employee { get; set; }
        public DbSet<RoleClass> PPM_Role { get; set; }
        public DbSet<EmployeeProjectRelationClass> PPM_ProEmpRel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database connection string
            optionsBuilder.UseSqlServer("Server=RHJ-9F-D218\\SQLEXPRESS; Database = PPM_EntityFramework; Integrated Security = true; TrustServerCertificate=True; Encrypt=False;");
        }
    }
}