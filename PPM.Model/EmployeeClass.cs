using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PPM.Model
{
    public class EmployeeClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeId { get; set; }     //  Id: Employee Id.

        [Required]
        [MaxLength]
        public string FirstName { get; set; } = "Undefined";      //  FirstName: Employee First Name.

        [Required]
        [MaxLength]
        public string LastName { get; set; }  = "Undefined";   //  LastName: Employee Last Name.

        [Required]
        [EmailAddress]
        public string Email { get; set; }  = "Undefined";   //  Email: Email Id of Employee.

        [Required]
        [MaxLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "MobileNumber must be numeric")]
        [StringLength(10, ErrorMessage = "MobileNumber must be 10 characters")]
        public string MobileNumber { get; set; }   = "Undefined";    //  MobileNumber: Employe Contact Number

        [Required]
        [MaxLength(300)]
        public string Address { get; set; }    = "Undefined";   //  Address: Employee Address.

        [Required]
        public long RoleId { get; set; }     //  RoleId: Employee RoleId.
        [ForeignKey("RoleId")] // Explicitly specifying the foreign key relationship
        public RoleClass? Role { get; set; } // Navigation property for the RoleClass

    }
}