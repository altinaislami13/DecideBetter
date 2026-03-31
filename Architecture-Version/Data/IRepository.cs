using System.Collections.Generic;

namespace DecideWise.Data
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T? GetById(int id);   // ✅ FIXED (nullable)
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}