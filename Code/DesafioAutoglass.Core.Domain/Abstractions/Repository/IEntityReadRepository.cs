namespace DesafioAutoglass.Core.Domain.Abstractions.Repository
{
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IEntityReadRepository<T>
    {
        Task<T> Get(object id);
        Task<T[]> GetAll();
        Task<T[]> QueryAsync(string query);
        Task<T> Get(long id);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
    }
}