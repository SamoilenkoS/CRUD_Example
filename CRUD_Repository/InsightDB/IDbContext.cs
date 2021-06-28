using CRUD_DAL.Interfaces;

namespace CRUD_DAL.InsightDB
{
    public interface IDbContext : CRUD_Core.IDbContext
    {
        IProductRepository ProductRepository { get; }

        IUserRepository UserRepository { get; }
    }
}