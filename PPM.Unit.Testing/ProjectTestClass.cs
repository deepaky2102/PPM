using NUnit.Framework;
using PPM.Model;
using PPM.Domain;

namespace PPM.Unit.Testing
{
    public class ProjectTestClass
    {
        // Arrange
        ProjectClass Project1 = new ProjectClass
        {
            ProjectId = 1,
            Name = "Project1",
            StartDate = DateTime.Parse("21-02-2001"),
            EndDate = DateTime.Parse("21-02-2023")
        };

        ProjectClass Project2 = new ProjectClass
        {
            ProjectId = 2,
            Name = "Project2",
            StartDate = DateTime.Parse("21-02-2002"),
            EndDate = DateTime.Parse("21-02-2023")
        };

        ProjectClass Project3 = new ProjectClass
        {
            ProjectId = 3,
            Name = "Project3",
            StartDate = DateTime.Parse("21-02-2003"),
            EndDate = DateTime.Parse("21-02-2023")
        };

        ProjectMethods projectMethods = new();

        [Test]
        public void Project_Add_Test()
        {
            // Act
            projectMethods.AddNewObject(Project1);
            projectMethods.AddNewObject(Project2);
            projectMethods.AddNewObject(Project3);

            // Assert
            CollectionAssert.Contains(ProjectMethods.ProjectList, Project3);
        }

        [Test]
        public void Retrieve_Project_Test()
        {
            // Act
            projectMethods.AddNewObject(Project1);
            projectMethods.AddNewObject(Project2);
            projectMethods.AddNewObject(Project3);

            // Assert
            CollectionAssert.IsNotEmpty(projectMethods.GetAllObject());
        }

        [Test]
        public void Retrieve_Project_By_Id_Test()
        {
            // Arrange
            long projectIdToFind = 2;

            // Act
            projectMethods.AddNewObject(Project1);
            projectMethods.AddNewObject(Project2);
            projectMethods.AddNewObject(Project3);

            List<ProjectClass> Project = projectMethods.GetObjectById(projectIdToFind);

            ProjectClass foundProject = Project.FirstOrDefault(em => em.ProjectId == projectIdToFind);

            // Assert
            Assert.IsNotNull(Project, "Expected to find an Project with ProjectId " + projectIdToFind);
            Assert.AreEqual(projectIdToFind, foundProject.ProjectId);
        }

        [Test]
        public void Retrieve_Projects_By_Name() 
        {
            // Arrange
            string ProjectNameToFind = "Project2"; // Change to the search string you want to use

            // Act
            projectMethods.AddNewObject(Project1);
            projectMethods.AddNewObject(Project2);
            projectMethods.AddNewObject(Project3);

            List<ProjectClass> Projects = projectMethods.GetObjectByName(ProjectNameToFind);

            // Assert
            Assert.That(Projects, Has.Some.Property("Name").Contains(ProjectNameToFind), $"Expected to find at least one Project with Name containing: {ProjectNameToFind}");
        }

        [Test]
        public void Delete_Projects_If_Exist()
        {
            // Arrange
            long ProjectIdToDelete = 2;

            // Act
            projectMethods.AddNewObject(Project1);
            projectMethods.AddNewObject(Project2);
            projectMethods.AddNewObject(Project3);

            List<ProjectClass> Projects = projectMethods.GetObjectById(ProjectIdToDelete);

            ProjectClass ProjectClass = ProjectMethods.ProjectList.FirstOrDefault(Project => Project.ProjectId == ProjectIdToDelete);

            projectMethods.DeleteObject(ProjectClass.ProjectId);

            // Assert
            Assert.That(ProjectMethods.ProjectList, Has.None.Property("ProjectId").EqualTo(ProjectIdToDelete), $"Project with ProjectId {ProjectIdToDelete} should no longer exist");
        }

    }
}