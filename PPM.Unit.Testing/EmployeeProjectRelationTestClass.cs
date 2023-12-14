using NUnit.Framework;
using PPM.Model;
using PPM.Domain;

namespace PPM.Unit.Testing
{
    public class EmployeeProjectRelationTestClass
    {
        //  Arrange
        EmployeeProjectRelationClass EPR1 = new EmployeeProjectRelationClass
        {
            Id = 1,
            ProjectId = 1,
            EmployeeId = 1
        };

        EmployeeProjectRelationClass EPR2 = new EmployeeProjectRelationClass
        {
            Id = 2,
            ProjectId = 1,
            EmployeeId = 2
        };

        EmployeeProjectRelationClass EPR3 = new EmployeeProjectRelationClass
        {
            Id = 3,
            ProjectId = 2,
            EmployeeId = 3
        };

        EmployeeProjectRelationClass EPR4 = new EmployeeProjectRelationClass
        {
            Id = 4,
            ProjectId = 2,
            EmployeeId = 4
        };

        EmployeeProjectRelationClass EPR5 = new EmployeeProjectRelationClass
        {
            Id = 5,
            ProjectId = 1,
            EmployeeId = 3
        };
        EmployeeProjectRelationMethod employeeProjectRelationmethod = new();

        [Test]
        public void Employee_To_Project_Add_Test()
        {
            // Act
            employeeProjectRelationmethod.AddNewObject(EPR1);
            employeeProjectRelationmethod.AddNewObject(EPR2);
            employeeProjectRelationmethod.AddNewObject(EPR3);
            employeeProjectRelationmethod.AddNewObject(EPR4);
            employeeProjectRelationmethod.AddNewObject(EPR5);

            // Assert
            CollectionAssert.Contains(EmployeeProjectRelationMethod.EmpProRelList, EPR3);
        }

        [Test]
        public void Retrieve_Details_Test()
        {
            // Act
            employeeProjectRelationmethod.AddNewObject(EPR1);
            employeeProjectRelationmethod.AddNewObject(EPR2);
            employeeProjectRelationmethod.AddNewObject(EPR3);
            employeeProjectRelationmethod.AddNewObject(EPR4);
            employeeProjectRelationmethod.AddNewObject(EPR5);

            // Assert
            CollectionAssert.IsNotEmpty(employeeProjectRelationmethod.GetAllObject());
        }

        [Test]
        public void Retrieve_Details_By_Project_Test()
        {
            // Arrange
            long projectIdToFind = 1;

            // Act
            employeeProjectRelationmethod.AddNewObject(EPR1);
            employeeProjectRelationmethod.AddNewObject(EPR2);
            employeeProjectRelationmethod.AddNewObject(EPR3);
            employeeProjectRelationmethod.AddNewObject(EPR4);
            employeeProjectRelationmethod.AddNewObject(EPR5);

            List<EmployeeProjectRelationClass> Project = employeeProjectRelationmethod.GetObjectByProjectId(projectIdToFind);

            EmployeeProjectRelationClass foundProject = Project.FirstOrDefault(em => em.ProjectId == projectIdToFind);

            // Assert
            Assert.IsNotNull(Project, "Expected to find an Project with ProjectId " + projectIdToFind);
            Assert.AreEqual(projectIdToFind, foundProject.ProjectId);
        }

        [Test]
        public void Retrieve_Details_By_Employee_Test()
        {
            // Arrange
            long employeeIdToFind = 1;

            // Act
            employeeProjectRelationmethod.AddNewObject(EPR1);
            employeeProjectRelationmethod.AddNewObject(EPR2);
            employeeProjectRelationmethod.AddNewObject(EPR3);
            employeeProjectRelationmethod.AddNewObject(EPR4);
            employeeProjectRelationmethod.AddNewObject(EPR5);

            List<EmployeeProjectRelationClass> Employee = employeeProjectRelationmethod.GetObjectByEmployeeId(employeeIdToFind);

            EmployeeProjectRelationClass foundEmployee = Employee.FirstOrDefault(em => em.EmployeeId == employeeIdToFind);

            // Assert
            Assert.IsNotNull(Employee, "Expected to find an Employee with EmployeeId " + employeeIdToFind);
            Assert.AreEqual(employeeIdToFind, foundEmployee.EmployeeId);
        }

        [Test]
        public void Retrieve_Details_By_Project_And_Employee_Test()
        {
            // Arrange
            long projectIdToFind = 1;
            long employeeIdToFind = 3;

            // Act
            employeeProjectRelationmethod.AddNewObject(EPR1);
            employeeProjectRelationmethod.AddNewObject(EPR2);
            employeeProjectRelationmethod.AddNewObject(EPR3);
            employeeProjectRelationmethod.AddNewObject(EPR4);
            employeeProjectRelationmethod.AddNewObject(EPR5);

            List<EmployeeProjectRelationClass> ProjectEmployee = employeeProjectRelationmethod.GetObjectByProjectIdAndEmployeeId( projectIdToFind, employeeIdToFind);

            EmployeeProjectRelationClass foundEmployee = ProjectEmployee.FirstOrDefault(em => em.ProjectId == projectIdToFind && em.EmployeeId == employeeIdToFind);

            // Assert
            Assert.IsNotNull(ProjectEmployee, "Expected to find an Project with ProjectId " + projectIdToFind);
            Assert.IsNotNull(ProjectEmployee, "Expected to find an Employee with EmployeeId " + employeeIdToFind);
            Assert.AreEqual(projectIdToFind, foundEmployee.ProjectId);
            Assert.AreEqual(employeeIdToFind, foundEmployee.EmployeeId);
        }

        [Test]
        public void Delete_Employee_From_Project_If_Exist()
        {
            // Act
            employeeProjectRelationmethod.AddNewObject(EPR1);
            employeeProjectRelationmethod.AddNewObject(EPR2);
            employeeProjectRelationmethod.AddNewObject(EPR3);
            employeeProjectRelationmethod.AddNewObject(EPR4);
            employeeProjectRelationmethod.AddNewObject(EPR5);

            employeeProjectRelationmethod.DeleteObject(EPR3.Id);

            List<EmployeeProjectRelationClass> EPRList = employeeProjectRelationmethod.GetAllObject();

            // Assert
            // Assert.That(EPRList, Has.Some.Property("Status").Contains("Inactive"), $"Expected to change the Status as Inactive.");
        }

    }
}