namespace PPM.Model
{
    public interface IEmployeeProjectRelationInterfaceClass
    {
        public void AddNewObject(EmployeeProjectRelationClass Obj);

        public List<EmployeeProjectRelationClass> GetAllObject ();

        public List<EmployeeProjectRelationClass> GetObjectByProjectId (long ProjectId);

        public List<EmployeeProjectRelationClass> GetObjectByEmployeeId (long EmployeeId);

        public List<EmployeeProjectRelationClass> GetObjectByProjectIdAndEmployeeId (long ProjectId, long EmployeeId);
        // public void DeleteObject(EmployeeProjectRelationClass IdToRemove);
        public void DeleteObject(long Id);
        // public long AssignPrimaryId();
    }
}