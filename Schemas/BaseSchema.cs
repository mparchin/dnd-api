using api.Models;

namespace api.Schemas
{
    public class BaseSchema<TEntity>
        where TEntity : IModel
    {
        public int Id { get; set; }
        public long Time { get; set; }

        public BaseSchema(TEntity model)
        {
            Id = model.Id;
            Time = Convert.ToInt64(((model.UpdatedOn ?? new DateTime(2020, 1, 1))
                                    .ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds);
        }

    }
}