namespace UOW.Repositories
{
    public interface IUnitOfWork
    {

        IProductRepo ProductRepo { get; }

        Task<int> SaveAsync();

    }
}
