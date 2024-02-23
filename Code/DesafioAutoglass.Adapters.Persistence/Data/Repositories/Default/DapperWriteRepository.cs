using Dommel;

namespace DesafioAutoglass.Adapters.Persistence.Adapters.Repositories.Default
{
    using DesafioAutoglass.Adapters.Persistence.Adapters.Configuration;
    using DesafioAutoglass.Adapters.Persistence.Adapters.Repositories.Interfaces;

    public class DapperWriteRepository<T> : IEntityWriteRepository<T>
        where T : class
    {
        private readonly DapperContext context;

        public DapperWriteRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<long> Create(T command)
        {
            using var db = context.CreateConnection();
            var result = await db.InsertAsync(command);
            return Convert.ToInt32(result);
        }

        public async Task Create(T[] command)
        {
            using var db = context.CreateConnection();
            await db.InsertAllAsync(command);
        }

        public async Task<bool> UpdateAsync(T command)
        {
            using var db = context.CreateConnection();
            var result = await db.UpdateAsync(command);
            return result;
        }

        public async Task<bool> Delete(object command)
        {
            using var db = context.CreateConnection();
            var result = await db.DeleteAsync(command);
            return result;
        }

        public async Task<int> DeleteAllAsync(T[] command)
        {
            using var db = context.CreateConnection();
            var result = await db.DeleteAllAsync<T>();
            return result;
        }

        private async Task<T> Get(long code)
        {
            using (var db = context.CreateConnection())
            {
                var result = await db.GetAsync<T>(code);
                return result;
            }
        }
    }
}