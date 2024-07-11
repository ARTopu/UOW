
using UOW.DAL;

namespace UOW.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyAppDbContext _appDbContext;

        public IProductRepo ProductRepo { get; private set; }

        public UnitOfWork(MyAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            ProductRepo =new ProductRepo(appDbContext);
        }

        

        public async Task<int> SaveAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
