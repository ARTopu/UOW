using UOW.DAL;
using UOW.Models;

namespace UOW.Repositories.Implementation
{
    public class ProductRepo : IProductRepo
    {
        private readonly MyAppDbContext _dbContext;

        public ProductRepo(MyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
