using PPM.Dal;
using PPM.Model;
using PPM.Entity.Framework;

namespace PPM.Domain
{
    public class EmployeeProjectRelationMethod: IEmployeeProjectRelationInterfaceClass
    {
        // readonly EmployeeProjectRelationDal employeeProjectRelationDal = new();
        readonly EmployeeProjectEntityClass employeeProjectEntityClass = new();
        public static List<EmployeeProjectRelationClass> EmpProRelList { get; set; } = new List<EmployeeProjectRelationClass>();

        public void AddNewObject(EmployeeProjectRelationClass Obj)
        {
            // EmpProRelList.Add(Obj);
            // employeeProjectRelationDal.AddProEmpRel(Obj);
            employeeProjectEntityClass.AddProEmpRel(Obj);
        }

        public List<EmployeeProjectRelationClass> GetAllObject ()
        {
            // return EmpProRelList;
            // return employeeProjectRelationDal.GetAllProEmpRel();
            return employeeProjectEntityClass.GetAllProEmpRel();
        }

        public List<EmployeeProjectRelationClass> GetEmployeeProjectById(long Id)
        {
            // return EmpProRelList.FindAll(x => x.Id == Id);
            // return employeeProjectRelationDal.GetEmployeeProjectById(Id);
            return employeeProjectEntityClass.GetEmployeeProjectById(Id);
        }

        public List<EmployeeProjectRelationClass> GetObjectByProjectId (long ProjectId)
        {
            // return EmpProRelList.FindAll(x => x.ProjectId == ProjectId);
            // return employeeProjectRelationDal.GetProEmpRelByProjectId(ProjectId);
            return employeeProjectEntityClass.GetProEmpRelByProjectId(ProjectId);
        }

        public List<EmployeeProjectRelationClass> GetObjectByEmployeeId (long EmployeeId)
        {
            // return EmpProRelList.FindAll(x => x.EmployeeId == EmployeeId);
            // return employeeProjectRelationDal.GetProEmpRelByEmployeeId(EmployeeId);
            return employeeProjectEntityClass.GetProEmpRelByEmployeeId(EmployeeId);
        }

        public List<EmployeeProjectRelationClass> GetObjectByProjectIdAndEmployeeId (long ProjectId, long EmployeeId)
        {
            // return EmpProRelList.FindAll(x => x.ProjectId == ProjectId && x.EmployeeId == EmployeeId);
            // return employeeProjectRelationDal.GetProEmpRelByProjectIdAndEmployeeId(ProjectId, EmployeeId);
            return employeeProjectEntityClass.GetProEmpRelByProjectIdAndEmployeeId(ProjectId, EmployeeId);
        }

        // public void DeleteObject(EmployeeProjectRelationClass IdToRemove)
        public void DeleteObject(long Id)
        {
            // EmpProRelList.Remove(IdToRemove);
            // employeeProjectRelationDal.DeleteProEmpRel(IdToRemove.Id);
            // employeeProjectRelationDal.DeleteProEmpRel(Id);
            employeeProjectEntityClass.DeleteProEmpRel(Id);
        }

        // public long AssignPrimaryId()
        // {
        //     long count = EmpProRelList.Count;
        //     count++;
        //     return count;
        // }
    }
}