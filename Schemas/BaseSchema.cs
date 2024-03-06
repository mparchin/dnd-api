using api.Models;

namespace api.Schemas
{
    public class BaseSchema<TEntity>(TEntity? model = default)
        where TEntity : IModel
    {
        public int Id { get; set; } = model?.Id ?? default;
        public long Time { get; set; } = Convert.ToInt64(((model?.UpdatedOn ?? new DateTime(2020, 1, 1))
                                    .ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds);
    }
}