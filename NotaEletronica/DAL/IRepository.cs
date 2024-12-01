using System;
using System.Collections.Generic;

namespace NotaEletronica.DAL
{
    public interface IRepository<TEntity> : IDisposable
    {
        IEnumerable<TEntity> Get();
        TEntity GetByID(int id);
        void Insert(TEntity entidade);
        void Delete(int id);
        void Update(TEntity entidade);
        void Save();
    }
}