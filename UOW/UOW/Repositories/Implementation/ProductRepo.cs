using Microsoft.EntityFrameworkCore;
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

        public async Task Add(Product product)
        {
            _dbContext.products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _dbContext.products.FindAsync(id);
            if (product != null)
            {
                _dbContext.products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
            
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbContext.products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dbContext.products.ToListAsync();
        }

        public async Task Update(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
