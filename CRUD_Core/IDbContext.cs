using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Core
{
  public interface IDbContext : IDisposable
  {
    Guid Id { get; set; }
    IDbConnection Connection { get; }

    Task<IDbTransaction> BeginTransactionAsync();

    TRepository CreateRepository<TRepository>() where TRepository : class;

    TRepository CreateRepository<TRepository>(IDbTransaction transaction) where TRepository : class;
  }
}
