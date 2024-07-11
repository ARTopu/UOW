using UOW.Models;

namespace UOW.Repositories
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProductById(int id);

        Task Add(Product product);

        Task Update(Product product);

        Task Delete(int id);
    }
}
