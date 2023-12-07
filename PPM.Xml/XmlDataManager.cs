using PPM.Model;
using PPM.Domain;
using System.Xml.Serialization;

namespace PPM.Xml
{
    public class XmlDataManager
    {
        private static readonly string BasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "PPM", "PPM.Xml");
        private const string EmployeeDataFileName = "employees.xml";
        private const string ProjectDataFileName = "projects.xml";
        private const string RoleDataFileName = "roles.xml";
        private const string EPRDataFileName = "employeeProjectRelations.xml";
        private static string GetFilePath(string fileName) => Path.Combine(BasePath, fileName);

        public void UpdateAndSaveDataButton()
        {
            // Clear and update XML files with list data
            UpdateAndSaveEmployeeData();
            UpdateAndSaveProjectData();
            UpdateAndSaveRoleData();
            UpdateAndSaveEPRData();

            // System.Console.WriteLine("Data updated and saved to XML files.");
        }

        public void UpdateAndSaveEmployeeData()
        {
            ClearAndSaveData(EmployeeMethods.EmployeeList, GetFilePath(EmployeeDataFileName));
        }

        public void UpdateAndSaveProjectData()
        {
            ClearAndSaveData(ProjectMethods.ProjectList, GetFilePath(ProjectDataFileName));
        }

        public void UpdateAndSaveRoleData()
        {
            ClearAndSaveData(RoleMethods.RoleList, GetFilePath(RoleDataFileName));
        }

        public void UpdateAndSaveEPRData()
        {
            ClearAndSaveData(EmployeeProjectRelationMethod.EmpProRelList, GetFilePath(EPRDataFileName));
        }

        private void ClearAndSaveData<T>(List<T> list, string filePath)
        {
            try
            {
                // Use a temporary list for serialization
                List<T> tempList = new List<T>(list);

                // Clear the file by deleting it.
                File.Delete(filePath);

                // Create an empty file.
                File.Create(filePath).Close();

                // Serialize and save the updated data.
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    serializer.Serialize(writer, tempList);
                }

                // Console.WriteLine($"All data in {filePath} updated and saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating and saving data to {filePath}: {ex.Message}");
            }
        }

        public void RetrieveButton()
        {
            // Retrieve XML data and update lists
            ProjectMethods.ProjectList = RetrieveXmlToList<ProjectClass>(GetFilePath(ProjectDataFileName));
            RoleMethods.RoleList = RetrieveXmlToList<RoleClass>(GetFilePath(RoleDataFileName));
            EmployeeMethods.EmployeeList = RetrieveXmlToList<EmployeeClass>(GetFilePath(EmployeeDataFileName));
            EmployeeProjectRelationMethod.EmpProRelList = RetrieveXmlToList<EmployeeProjectRelationClass>(GetFilePath(EPRDataFileName));

            Console.WriteLine("XML file values retrieved and updated in the lists.");
        }

        private List<T> RetrieveXmlToList<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
                {
                    Console.WriteLine($"File {filePath} does not exist or is empty. Returning an empty list.");
                    return new List<T>();
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    var deserializedObject = serializer.Deserialize(reader);

                    if (deserializedObject is List<T> result)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine($"Error retrieving data from {filePath}: Deserialization result is not of type List<{typeof(T).Name}>.");
                        return new List<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving data from {filePath}: {ex.Message}");
                return new List<T>();
            }
        }
    }
}