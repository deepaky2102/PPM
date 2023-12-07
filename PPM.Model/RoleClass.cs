using System.ComponentModel.DataAnnotations;
namespace PPM.Model
{
    public class RoleClass
    {
        [Key]
        public long RoleId { get; set; }     // ProjectId: Project Id.
        public string Name { get; set; }     // Name: Project Name.

        public RoleClass()
        {
            RoleId = 0;
            Name = "null";
        }
    }
}