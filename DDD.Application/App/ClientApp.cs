using System.Collections.Generic;
using DDD.Domain.Enties;
using DDD.Domain.Interfaces;

namespace DDD.Application.App
{
    public class ClientApp
    {
        private readonly IClient clientRepository;

        public ClientApp(IClient _ClientRepository)
        {
            clientRepository = _ClientRepository;
        }

        public void Add(Client _obj)
        {
            clientRepository.Add(_obj);
        }

        public List<Client> GetAll()
        {
            return clientRepository.GetAll();
        }

        public Client GetById(int id)
        {
            return (Client)clientRepository.GetById(id);
        }

        public void Remove(Client _obj)
        {
            clientRepository.Remove(_obj);
        }

        public void Update(Client _obj)
        {
            clientRepository.Update(_obj);
        }
    }
}
