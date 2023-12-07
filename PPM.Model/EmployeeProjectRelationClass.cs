using System.ComponentModel.DataAnnotations;
namespace PPM.Model
{
    public class EmployeeProjectRelationClass
    {
        [Key]
        public long Id { get; set; }     //  Id: Employee Project Relationship Id.
        public long ProjectId { get; set; }     //  ProjectId: ProjectId.
        public long EmployeeId { get; set; }     //  EmployeeId: Employee Id.
        public long RoleId { get; set; }     //  RoleId: Role Id.
        public  string Status { get; set; }     //  Status: Employee Status shows that employee is active or not within the project.

        public EmployeeProjectRelationClass()
        {
            Id = 0;
            ProjectId = 0;
            EmployeeId = 0;
            RoleId = 0;
            Status = "Active";
        }
    }
}