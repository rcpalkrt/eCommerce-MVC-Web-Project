using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicECommerce.BLL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetBy(Expression<Func<T, bool>> expression);//Filtreleme
        IQueryable<T> GetAll();//Listeleme
        void Add(T entity);//Ekle
        void AddRange(ICollection<T> entities);//Toplu Ekle
        void Remove(T entity);//Sil
        void RemoveRange(ICollection<T> entities);//Toplu Sil
        void Update(T entity);//Güncelle
    }
}
