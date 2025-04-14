namespace WorkSpaceWebAPI.Repository
{
    public interface IGenericRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void DeleteById(int id);
        void Delete(T entity);
        void Save();
    }
}
