using System.Collections.Generic;

namespace DDD.Domain.Interfaces
{
    public interface IGenericEntie<T> where T : class
    {
        void Add(T _obj);
        void Remove(T _obj);
        void Update(T _obj);
        T GetById(int id);
        List<T> GetAll();

    }
}
