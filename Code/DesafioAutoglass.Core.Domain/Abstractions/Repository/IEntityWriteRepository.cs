namespace DesafioAutoglass.Adapters.Persistence.Adapters.Repositories.Interfaces
{
    public interface IEntityWriteRepository<T>
    {
        Task<long> Create(T command);
        Task Create(T[] command);
        Task<bool> UpdateAsync(T command);
        Task<bool> Delete(object commandKey);
        Task<int> DeleteAllAsync(T[] command);
    }
}