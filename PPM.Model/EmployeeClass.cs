using System.ComponentModel.DataAnnotations;
namespace PPM.Model
{
    public class EmployeeClass
    {
        [Key]
        public long EmployeeId { get; set; }     //  Id: Employee Id.
        public  string FirstName { get; set; }     //  FirstName: Employee First Name.
        public  string LastName { get; set; }     //  LastName: Employee Last Name.
        public  string Email { get; set; }     //  Email: Email Id of Employee.
        public  string MobileNumber { get; set; }     //  MobileNumber: Employe Contact Number
        public  string Address { get; set; }     //  Address: Employee Address.
        public long RoleId { get; set; }     //  RoleId: Employee RoleId.

        public EmployeeClass()
        {
            EmployeeId = 0;
            FirstName = "null";
            LastName = "null";
            Email = "null";
            MobileNumber = "null";
            Address = "null";
            RoleId = 0;
        }
    }
}