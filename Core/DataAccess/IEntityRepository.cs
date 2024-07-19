using Core.Entites;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public interface IEntityRepository<T> where T : class, IEntity, new()

    { 
        List<T> HepsiniGetir(Expression<Func<T, bool>> filter = null);
        void Ekle(T entity);
        void Guncelle(T entity);
        void Sil(T entity);
        T IdyeGoreGetir(Expression<Func<T, bool>> filter);
    }
}
