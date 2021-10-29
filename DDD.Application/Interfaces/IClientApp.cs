using System.Collections.Generic;
using DDD.Domain.Enties;

namespace DDD.Application.Interfaces
{
    public interface IClientApp
    {
        void Add(Client _obj);
        void Remove(Client _obj);
        void Update(Client _obj);
        Client GetById(int id);
        List<Client> GetAll();
    }
}
