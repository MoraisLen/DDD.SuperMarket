using DDD.Domain.Enties;
using DDD.Domain.Interfaces;

namespace DDD.Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProduct
    {
    }
}
