using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List(); //listeleme için kullanılacak method.
        void Insert(T p); //ekleme için kullanılacak method.
        void Update(T p); //güncelleme için kullanılacak method.
        void Delete(T p); //silme için kullanılacak method.               
        List<T> List(Expression<Func<T, bool>> filter);  //filtreleme(şartlı liste) için kullanılacak method.
        T Get(Expression<Func<T, bool>> filter); //Bu kısımda id'ye göre listeleme işlemi.
    }
}
