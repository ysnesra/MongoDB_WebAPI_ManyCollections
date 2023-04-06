using MongoDB_WebAPI.Model.Abstract;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace MongoDB_WebAPI.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);  //filtreleyerek listelemek için Expression yazarız

        T Get(Expression<Func<T, bool>> filter);

        //T GetById(Expression<Func<T, bool>> filter); //Get ile aynı olduğından iki kez yazmaya gerek yok

        T Add(T entity);

        long Update(Expression<Func<T, bool>> filter, T entity);

        long Delete(Expression<Func<T, bool>> filter);
    }
}
