using PPM.Model;
using PPM.Dal;
using PPM.Entity.Framework;
namespace PPM.Domain
{
    public class EmployeeMethods : IEntityOperation<EmployeeClass>
    {
        // readonly EmployeeDal employeeDal = new();
        readonly EmployeeEntityClass employeeEntityClass = new();
        public static List<EmployeeClass> EmployeeList { get; set; } = new List<EmployeeClass>(); // Change to instance field

        public void AddNewObject(EmployeeClass entity)
        {
            // EmployeeList.Add(entity);
            // employeeDal.AddEmployee(entity);
            employeeEntityClass.AddEmployee(entity);
        }

        public List<EmployeeClass> GetAllObject()
        {
            // return EmployeeList;
            // return employeeDal.GetAllemployee();
            return employeeEntityClass.GetAllemployee();
        }

        public List<EmployeeClass> GetObjectById(long id)
        {
            // return EmployeeList.FindAll(x => x.EmployeeId == id);
            // return employeeDal.GetEmployeeById(id);
            return employeeEntityClass.GetEmployeeById(id);
        }

        public List<EmployeeClass> GetObjectByFirstName(string FirstName)
        {
            // return EmployeeList.FindAll(x => x.FirstName.Contains(FirstName));
            // return employeeDal.GetEmployeeByFirstName(FirstName);
            return employeeEntityClass.GetEmployeeByFirstName(FirstName);
        }

        public List<EmployeeClass> GetObjectByLastName(string LastName)
        {
            // return EmployeeList.FindAll(x => x.LastName.Contains(LastName));
            // return employeeDal.GetEmployeeByLastName(LastName);
            return employeeEntityClass.GetEmployeeByLastName(LastName);
        }

        public List<EmployeeClass> GetObjectByFullName(string FirstName, string LastName)
        {
            // return EmployeeList.FindAll(x => x.FirstName.Contains(FirstName) && x.LastName.Contains(LastName));
            // return employeeDal.GetEmployeeByFullName(FirstName, LastName);
            return employeeEntityClass.GetEmployeeByFullName(FirstName, LastName);
        }

        // public void DeleteObject(EmployeeClass entity)
        public void DeleteObject(long Id)
        {
            // EmployeeList.Remove(entity);
            // employeeProjectRelationDal.DeleteProEmpRel(Id);
            // employeeDal.DeleteEmployee(Id);
            employeeEntityClass.DeleteEmployee(Id);
        }

        public List<EmployeeClass> GetObjectByName(string Name)
        {
            throw new NotImplementedException();
        }
        // public long AssignPrimaryId()
        // {
        //     long count = EmployeeList.Count;
        //     count++;
        //     return count;
        // }
    }
}