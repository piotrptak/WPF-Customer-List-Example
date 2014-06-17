using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainServices
{
    public interface IGenericRepositoryServices<T>
    {
        T Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T Get(Func<T, bool> filter);
        IList<T> GetAll();
    }
    
}
