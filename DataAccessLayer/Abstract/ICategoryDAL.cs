using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDAL
    {
        //CRUD işlemleri. (Select,Delete,Update,Insert)
        //Type Name();

        List<Category> List(); //listeleme, yani select işlemi için yazılan bir method.
        void Insert(Category p); //ekleme, yani insert işlemi için yazılan bir method.
        void Update(Category p); //güncelleme, yani update işlemi için yazılan bir method.
        void Delete(Category p); //silme, yani delete işlemi için yazılan bir method.

        List<Category> List(Expression<Func<Category, bool>> filter);  //filtreleme(şartlı liste) için kullanılacak method.
    }
}
