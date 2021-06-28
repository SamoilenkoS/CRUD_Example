namespace CRUD_Core
{
  public interface IRepository<T> where T : class
  {
    T DbRepository { get; }
  }
}
