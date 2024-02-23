using Dommel;
using System.Linq.Expressions;

namespace DesafioAutoglass.Adapters.Persistence.Adapters.Repositories.Default
{
    using DesafioAutoglass.Adapters.Persistence.Adapters.Configuration;
    using DesafioAutoglass.Core.Domain.Abstractions.Repository;
    using global::Dapper;

    public class DapperReadRepository<T> : IEntityReadRepository<T>                          
        where T : class
    {
        private readonly DapperContext context;


        public DapperReadRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<T> Get(object id)
        {
            using (var db = context.CreateConnection())
            {
                var result = await db.GetAsync<T>(id);
                return result;
            }
        }

        public async Task<T> Get(long code)
        {
            using (var db = context.CreateConnection())
            {
                var result = await db.GetAsync<T>(code);
                return result;
            }
        }

        public async Task<T[]> GetAll()
        {
            using (var db = context.CreateConnection())
            {
                var result = await db.GetAllAsync<T>();
                if (result != null && result.Any())
                {
                    return result.ToArray();
                }

                return Array.Empty<T>();
            }
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            using (var db = context.CreateConnection())
            {
                var result = await db.AnyAsync<T>(predicate);
                return result;
            }
        }

        public async Task<T[]> QueryAsync(string query)
        {
            using (var db = context.CreateConnection())
            {
                var result = await db.QueryAsync<T>(query);
                if (result != null && result.Any())
                {
                    return result.ToArray();
                }

                return Array.Empty<T>();
            }
        }
    }
}
