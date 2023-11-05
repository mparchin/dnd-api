using System.Text.Json;
using System.Text.Json.Serialization;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace api.Controllers
{
    public abstract class BaseODataController<TEntity> : ODataController
        where TEntity : class, IModel, new()
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly DbContext Db;
        private readonly Action<TEntity, TEntity> _updateEntity;
        protected readonly IQueryable<TEntity> BaseQuery;

        private readonly ILogger _logger;

        public BaseODataController(DbContext db, DbSet<TEntity> dbSet, ILogger logger,
            Action<TEntity, TEntity> updateEntity, IQueryable<TEntity>? baseQuery = null)
        {
            Db = db;
            DbSet = dbSet;
            _updateEntity = updateEntity;
            BaseQuery = baseQuery ?? DbSet;
            _logger = logger;
        }

        [EnableQuery(MaxExpansionDepth = 2)]
        public IQueryable<TEntity> Get() =>
            BaseQuery;

        [EnableQuery(MaxExpansionDepth = 2)]
        public SingleResult Get([FromRoute] int key) =>
            SingleResult.Create(BaseQuery.FindByKey(key));

        public async Task<ActionResult> Post()
        {
            var result = await HttpContext.DeserializeWithNewton<TEntity>() ?? throw new BadHttpRequestException(
                        "Request content type was not a recognized JSON content type.",
                        StatusCodes.Status415UnsupportedMediaType);
            var entity = new TEntity();
            await DbSet.AddAsync(entity);
            _updateEntity.Invoke(entity, result);
            entity.UpdatedOn = DateTime.UtcNow;
            await Db.SaveChangesAsync();
            return Created(entity);
        }

        public async Task<ActionResult> Put([FromRoute] int key, [FromBody] TEntity updatedEntity)
        {
            var entity = await BaseQuery.FindByKey(key).FirstOrDefaultAsync();
            if (entity is null)
                return NotFound();

            _updateEntity.Invoke(entity, updatedEntity);

            entity.UpdatedOn = DateTime.UtcNow;
            await Db.SaveChangesAsync();
            return Updated(entity);
        }

        public async Task<ActionResult> Patch([FromRoute] int key)
        {
            var result = await HttpContext.DeserializeWithNewton<TEntity>();
            var entity = await BaseQuery.FindByKey(key).FirstOrDefaultAsync();
            if (entity is null)
                return NotFound();

            if (result is { })
                _updateEntity.Invoke(entity, result);
            else
                _logger.LogCritical("patch input is null");

            entity.UpdatedOn = DateTime.UtcNow;
            await Db.SaveChangesAsync();
            return Updated(entity);
        }

        public async Task<ActionResult> Delete([FromRoute] int key)
        {
            var entity = await BaseQuery.FindByKey(key).FirstOrDefaultAsync();

            if (entity is { })
                DbSet.Remove(entity);

            await Db.SaveChangesAsync();
            return NoContent();
        }
    }
}