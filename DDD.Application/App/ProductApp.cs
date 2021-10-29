using System.Collections.Generic;
using DDD.Application.Interfaces;
using DDD.Domain.Enties;
using DDD.Domain.Interfaces;

namespace DDD.Application.App
{
    public class ProductApp : IProductApp
    {
        private readonly IProduct productRepository;

        public ProductApp(IProduct _productRepository)
        {
            productRepository = _productRepository;
        }

        public void Add(Product _obj)
        {
            productRepository.Add(_obj);
        }

        public List<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return (Product)productRepository.GetById(id);
        }

        public void Remove(Product _obj)
        {
            productRepository.Remove(_obj);
        }

        public void Update(Product _obj)
        {
            productRepository.Update(_obj);
        }
    }
}
