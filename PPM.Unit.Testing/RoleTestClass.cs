using NUnit.Framework;
using PPM.Model;
using PPM.Domain;

namespace PPM.Unit.Testing
{
    public class RoleTestClass
    {
        // Arrange
        RoleClass Role1 = new RoleClass
        {
            RoleId = 1,
            Name = "Role1"
        };

        RoleClass Role2 = new RoleClass
        {
            RoleId = 2,
            Name = "Role2"
        };

        RoleClass Role3 = new RoleClass
        {
            RoleId = 3,
            Name = "Role3"
        };

        RoleClass Role = new RoleClass()
        {
            RoleId = 100,
            Name = "Role100"
        };

        RoleMethods roleMethods = new();

        [Test]
        public void Role_Add_Test()
        {
            // Act
            roleMethods.AddNewObject(Role1);
            roleMethods.AddNewObject(Role2);
            roleMethods.AddNewObject(Role3);

            // Assert
            CollectionAssert.Contains(RoleMethods.RoleList, Role3);
        }

        [Test]
        public void Retrieve_Role_Test()
        {
            // Act
            roleMethods.AddNewObject(Role1);
            roleMethods.AddNewObject(Role2);
            roleMethods.AddNewObject(Role3);
            roleMethods.AddNewObject(Role);

            // Assert
            CollectionAssert.IsNotEmpty(roleMethods.GetAllObject());
        }

        [Test]
        public void Retrieve_Role_By_Id_Test()
        {
            // Arrange
            long roleIdToFind = 1;

            // Act
            roleMethods.AddNewObject(Role1);
            roleMethods.AddNewObject(Role2);
            roleMethods.AddNewObject(Role3);

            List<RoleClass> Role = roleMethods.GetObjectById(roleIdToFind);

            RoleClass foundRole = Role.FirstOrDefault(em => em.RoleId == roleIdToFind);

            // Assert
            Assert.IsNotNull(Role, "Expected to find an Role with RoleId " + roleIdToFind);
            Assert.AreEqual(roleIdToFind, foundRole.RoleId);
        }

        [Test]
        public void Retrieve_Roles_By_Name() 
        {
            // Arrange
            string roleNameToFind = "Role"; // Change to the search string you want to use

            // Act
            roleMethods.AddNewObject(Role1);
            roleMethods.AddNewObject(Role2);
            roleMethods.AddNewObject(Role3);
            roleMethods.AddNewObject(Role);

            List<RoleClass> roles = roleMethods.GetObjectByName(roleNameToFind);

            // Assert
            Assert.That(roles, Has.Some.Property("Name").Contains(roleNameToFind), $"Expected to find at least one role with Name containing: {roleNameToFind}");
        }

        [Test]
        public void Delete_Roles_If_Exist()
        {
            // Arrange
            long RoleIdToDelete = 2;

            // Act
            roleMethods.AddNewObject(Role1);
            roleMethods.AddNewObject(Role2);
            roleMethods.AddNewObject(Role3);
            roleMethods.AddNewObject(Role);

            List<RoleClass> roles = roleMethods.GetObjectById(RoleIdToDelete);

            RoleClass roleClass = RoleMethods.RoleList.FirstOrDefault(role => role.RoleId == RoleIdToDelete);

            roleMethods.DeleteObject(roleClass.RoleId);

            // Assert
            Assert.That(RoleMethods.RoleList, Has.None.Property("RoleId").EqualTo(RoleIdToDelete), $"Role with RoleId {RoleIdToDelete} should no longer exist");
        }

    }
}