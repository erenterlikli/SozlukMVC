using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDAL
    {

        Context c = new Context();
        DbSet<Category> _object;


        public void Delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges();  //Ado.net deki karşılığı ExecuteNonQuery() dir.
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //SingleOrDefault: Dizi ve listelerde tek bir değeri döndürür.
        }

        public void Insert(Category p)
        {
            _object.Add(p);
            c.SaveChanges();  //Ado.net deki karşılığı ExecuteNonQuery() dir.
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(Category p)
        {
            c.SaveChanges();
        }
    }
}
