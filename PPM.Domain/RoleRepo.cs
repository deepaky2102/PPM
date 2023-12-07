using PPM.Dal;
using PPM.Model;
using PPM.Entity.Framework;

namespace PPM.Domain
{
    public class RoleMethods: IEntityOperation<RoleClass>
    {
        // readonly RoleDal roleDal = new();
        readonly RoleEntityClass roleEntityClass = new();
        public static List<RoleClass> RoleList { get; set; } = new List<RoleClass>(); // RoleList: List created to store information of RoleClass.

        public void AddNewObject(RoleClass entity)
        {    
            // RoleList.Add(entity);
            // roleDal.AddRole(entity);
            roleEntityClass.AddRole(entity);
        }

        public List<RoleClass> GetAllObject()
        {
            // return RoleList;
            // return roleDal.GetAllRole();
            return roleEntityClass.GetAllRole();
        }

        public List<RoleClass> GetObjectById(long id)
        {
            // return RoleList.FindAll(x => x.RoleId == id);
            // return roleDal.GetRoleById(id);
            return roleEntityClass.GetRoleById(id);
        }

        public List<RoleClass> GetObjectByName(string Name)
        {
            // return RoleList.FindAll(x => x.Name.Contains(Name));
            // return roleDal.GetRoleByName(Name);
            return roleEntityClass.GetRoleByName(Name);
        }

        // public void DeleteObject(RoleClass entity)
        public void DeleteObject(long Id)
        {
            // RoleList.Remove(entity);
            // roleDal.DeleteRole(entity.RoleId);
            // roleDal.DeleteRole(Id);
            roleEntityClass.DeleteRole(Id);
        }

        // public long AssignPrimaryId()
        // {
        //     long count = RoleList.Count;
        //     count++;
        //     return count;
        // }
    }
}