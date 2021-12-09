using System.Collections.Generic;

namespace Manasijevikj.MovieApp.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void Insert(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
