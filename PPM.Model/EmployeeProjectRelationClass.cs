using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PPM.Model
{
    public class EmployeeProjectRelationClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }     //  Id: Employee Project Relationship Id.

        [Required]
        public long ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public ProjectClass? Project { get; set; }

        [Required]
        public long EmployeeId { get; set; }
        [ForeignKey("EmployeeId")] // Explicitly specifying the foreign key relationship
        public EmployeeClass? Employee { get; set; } // Navigation property for the EmployeeClass

    }
}