using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Alten.VehicleStatus.Data.Repository
{
    

    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        void Delete(T entity);
        bool Update(T entity, int oldEntityId);
    }
}
