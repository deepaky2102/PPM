using PPM.Model;

namespace PPM.Domain
{
    public interface IEntityOperation<T>
    {
        void AddNewObject(T entity);
        // void DeleteObject(T entity);
        void DeleteObject(long Id);
        List<T> GetObjectById(long id);
        List<T> GetAllObject();
        List<T> GetObjectByName(string Name);
    }
}