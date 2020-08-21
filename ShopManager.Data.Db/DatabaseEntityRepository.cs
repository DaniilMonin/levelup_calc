using System;
using System.Collections.Generic;
using System.Linq;
using ShopManager.Core.Generic;
using ShopManager.Data.Db.Context;

namespace ShopManager.Data.Db
{
    internal sealed class DatabaseEntityRepository<TEntity> : EntityRepository<TEntity>
        where TEntity : Entity
    {
        private readonly ShopManagerDatabaseContext _context;

        public DatabaseEntityRepository(IEntityFactory<TEntity> factory, ShopManagerDatabaseContext context) : base(factory)
        {
            _context = context;
        }

        public override IReadOnlyList<TEntity> Get()
        {
            return _context.Set<TEntity>().ToList();
        }

        public override void Update(TEntity entity)
        {
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            TEntity entity = _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);

            if (entity is null)
            {
                throw new NullReferenceException();
            }

            _context.Remove(entity);
            _context.SaveChanges();
        }
    }
}
