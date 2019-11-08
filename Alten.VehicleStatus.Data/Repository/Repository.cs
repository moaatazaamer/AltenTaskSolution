using System;
using System.Collections.Generic;
using System.Text;

namespace Alten.VehicleStatus.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly List<TEntity> entities;
        public Repository()
        {
            entities = new List<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            entities.Add(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {           
            entities.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities;
        }

        public TEntity GetById(int id)
        {
            return entities[id];
        }

        public bool Update(TEntity entity, int oldEntityId)
        {
            entities[oldEntityId] = entity;
            return entities[oldEntityId] == entity;
        }
    }
}
