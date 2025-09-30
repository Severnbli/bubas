namespace bubas.Source.Core.Interfaces;

public interface IRepository<T>
{
    public Task<T?> GetById(long id);
    public Task<bool> Merge(T entity);
    public Task<bool> Delete(long id);
    public Task<bool> Delete(T entity);
}