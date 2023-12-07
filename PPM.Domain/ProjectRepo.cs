using PPM.Model;
using PPM.Dal;
using PPM.Entity.Framework;

namespace PPM.Domain
{
    public class ProjectMethods : IEntityOperation<ProjectClass>
    {
        // readonly ProjectDal projectDal = new();
        readonly ProjectEntityClass projectEntityClass = new();

        public static List<ProjectClass> ProjectList { get; set; } = new List<ProjectClass>();

        public int InsertDate(int Year, int Month)
        {
            int[] DayArr1 = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] DayArr2 = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] selectedDayArr = (Year % 4 == 0 && (Year % 100 != 0 || Year % 400 == 0)) ? DayArr2 : DayArr1;
            return selectedDayArr[Month - 1];
        }

        public void AddNewObject(ProjectClass entity)
        {
            // ProjectList.Add(entity);
            // projectDal.AddProject(entity);
            projectEntityClass.AddProject(entity);
        }

        public List<ProjectClass> GetAllObject()
        {
            // return ProjectList;
            // return projectDal.GetAllProject();
            return projectEntityClass.GetAllProject();
        }

        public List<ProjectClass> GetObjectById(long id)
        {
            // return ProjectList.FindAll(x => x.ProjectId == id);
            // return projectDal.GetProjectById(id);
            return projectEntityClass.GetProjectById(id);
        }

        public List<ProjectClass> GetObjectByName(string Name)
        {
            // return ProjectList.FindAll(x => x.Name.Contains(Name));
            // return projectDal.GetProjectByName(Name);
            return projectEntityClass.GetProjectByName(Name);
        }

        // public void DeleteObject(ProjectClass entity)
        public void DeleteObject(long Id)
        {
            // ProjectList.Remove(entity);
            // projectDal.DeleteProject(entity.ProjectId);
            // projectDal.DeleteProject(Id);
            projectEntityClass.DeleteProject(Id);
        }
        
        // public long AssignPrimaryId()
        // {
        //     long count = ProjectList.Count;
        //     count++;
        //     return count;
        // }
    }
}