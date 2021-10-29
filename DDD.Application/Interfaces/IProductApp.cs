using DDD.Domain.Enties;
using System.Collections.Generic;

namespace DDD.Application.Interfaces
{
    public interface IProductApp
    {
        void Add(Product _obj);
        void Remove(Product _obj);
        void Update(Product _obj);
        Product GetById(int id);
        List<Product> GetAll();
    }
}
