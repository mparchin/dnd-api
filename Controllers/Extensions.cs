using api.Models;
using Newtonsoft.Json;

namespace api.Controllers
{
    public static class Extensions
    {
        public static IQueryable<TEntity> FindByKey<TEntity>(this IQueryable<TEntity> dbSet, int key)
            where TEntity : class, IModel =>
            dbSet.Where(entity => entity.Id == key);

        public static async Task<TEntity?> DeserializeWithNewton<TEntity>(this HttpContext context)
        {
            if (!context.Request.HasJsonContentType())
            {
                throw new BadHttpRequestException(
                        "Request content type was not a recognized JSON content type.",
                        StatusCodes.Status415UnsupportedMediaType);
            }
            using var sr = new StreamReader(context.Request.Body);
            var str = await sr.ReadToEndAsync();

            return JsonConvert.DeserializeObject<TEntity>(str);
        }
        public static List<int> GetDeletedIds(this int[] original, int[] updated) =>
            original.Where(oId => updated.All(uId => uId != oId)).ToList();

        public static List<int> GetAddedIds(this int[] original, int[] updated) =>
            updated.Where(uId => original.All(oId => oId != uId)).ToList();

    }
}