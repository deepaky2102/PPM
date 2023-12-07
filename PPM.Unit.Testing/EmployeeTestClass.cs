using NUnit.Framework;
using PPM.Model;
using PPM.Domain;

namespace PPM.Unit.Testing
{
    public class EmployeeTestClass
    {
        //  Arrange
        EmployeeClass Employee1 = new EmployeeClass() 
        {
            EmployeeId = 1,
            FirstName = "First1",
            LastName = "Last1",
            Email = "Email1@gmail.com",
            MobileNumber = "1234567890",
            Address = "Address1",
            RoleId = 1
        };
        EmployeeClass Employee2 = new EmployeeClass() 
        {
            EmployeeId = 2,
            FirstName = "First2",
            LastName = "Last2",
            Email = "Email2@gmail.com",
            MobileNumber = "2345678901",
            Address = "Address3",
            RoleId = 2
        };
        EmployeeClass Employee3 = new EmployeeClass() 
        {
            EmployeeId = 3,
            FirstName = "First3",
            LastName = "Last3",
            Email = "Email3@gmail.com",
            MobileNumber = "3456789012",
            Address = "Address3",
            RoleId = 3
        };

        EmployeeMethods employeeMethods = new();

        [Test]
        public void Employee_Add_Test()
        {
            // Act
            employeeMethods.AddNewObject(Employee1);
            employeeMethods.AddNewObject(Employee2);
            employeeMethods.AddNewObject(Employee3);

            // Assert
            CollectionAssert.Contains(EmployeeMethods.EmployeeList, Employee3);
        }
        
        [Test]
        public void Retrieve_Employee()
        {
            // Act
            employeeMethods.AddNewObject(Employee1);
            employeeMethods.AddNewObject(Employee2);
            employeeMethods.AddNewObject(Employee3);

            // Assert
            CollectionAssert.IsNotEmpty(employeeMethods.GetAllObject());
        }

        [Test]
        public void Retrieve_Employee_By_Id()
        {
            // Arrange
            long employeeIdToFind = 1;

            // Act
            employeeMethods.AddNewObject(Employee1);
            employeeMethods.AddNewObject(Employee2);
            employeeMethods.AddNewObject(Employee3);

            List<EmployeeClass> employee = employeeMethods.GetObjectById(employeeIdToFind);

            EmployeeClass foundEmployee = employee.FirstOrDefault(em => em.EmployeeId == employeeIdToFind);

            // Assert
            Assert.IsNotNull(employee, "Expected to find an Employee with EmployeeId " + employeeIdToFind);
            Assert.AreEqual(employeeIdToFind, foundEmployee.EmployeeId);
        }

        [Test]
        public void RetrieveEmployeeByFirstName()
        {
            //  Arrange
            string firstName = "First1";

            //  Act
            employeeMethods.AddNewObject(Employee1);
            employeeMethods.AddNewObject(Employee2);
            employeeMethods.AddNewObject(Employee3);

            List<EmployeeClass> employee = employeeMethods.GetObjectByFirstName(firstName);

            EmployeeClass foundEmployee = employee.FirstOrDefault(em => em.FirstName == firstName);

            //  Assert
            Assert.IsNotNull(employee, "Expected to find an Employee with First Name " + firstName);
            Assert.AreEqual(firstName, foundEmployee.FirstName);
        }

        [Test]
        public void RetrieveEmployeeByLastName()
        {
            //  Arrange
            string lastName = "Last1";

            //  Act
            employeeMethods.AddNewObject(Employee1);
            employeeMethods.AddNewObject(Employee2);
            employeeMethods.AddNewObject(Employee3);

            List<EmployeeClass> employee = employeeMethods.GetObjectByLastName(lastName);

            EmployeeClass foundEmployee = employee.FirstOrDefault(em => em.LastName == lastName);

            //  Assert
            Assert.IsNotNull(employee, "Expected to find an Employee with Last Name " + lastName);
            Assert.AreEqual(lastName, foundEmployee.LastName);
        }
        
        [Test]
        public void RetrieveEmployeeByFullName()
        {
            //  Arrange
            string firstName = "First1";
            string lastName = "Last1";

            //  Act
            employeeMethods.AddNewObject(Employee1);
            employeeMethods.AddNewObject(Employee2);
            employeeMethods.AddNewObject(Employee3);

            List<EmployeeClass> employee = employeeMethods.GetObjectByFullName(firstName, lastName);

            EmployeeClass foundEmployee = employee.FirstOrDefault(em => em.FirstName == firstName && em.LastName == lastName);

            //  Assert
            Assert.IsNotNull(employee, "Expected to find an Employee with First Name " + firstName + " Last Name " + lastName);
            Assert.AreEqual(firstName, foundEmployee.FirstName);
            Assert.AreEqual(lastName, foundEmployee.LastName);
        }

        [Test]
        public void DeleteEmployeeIfExist()
        {
            // Arrange
            long EmployeeIdToDelete = 2;

            // Act
            employeeMethods.AddNewObject(Employee1);
            employeeMethods.AddNewObject(Employee2);
            employeeMethods.AddNewObject(Employee3);
            // EmployeeMethods.AddNewObject(Employee);

            List<EmployeeClass> Employees = employeeMethods.GetObjectById(EmployeeIdToDelete);

            EmployeeClass EmployeeClass = EmployeeMethods.EmployeeList.FirstOrDefault(Employee => Employee.EmployeeId == EmployeeIdToDelete);

            employeeMethods.DeleteObject(EmployeeClass.EmployeeId);

            // Assert
            Assert.That(EmployeeMethods.EmployeeList, Has.None.Property("EmployeeId").EqualTo(EmployeeIdToDelete), $"Employee with EmployeeId {EmployeeIdToDelete} should no longer exist");
        }

    }
}