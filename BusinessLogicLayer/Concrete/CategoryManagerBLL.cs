using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class CategoryManagerBLL
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetAllBLL()
        {
            return repo.List();
        }

        public void CategoryAddBLL(Category p)
        {
            if (p.CategoryName == " " || p.CategoryName.Length <= 3 || p.CategoryDescription == " " || p.CategoryDescription.Length >= 1001 || p.CategoryName.Length >= 101)
            {
                //hata
            }

            else
            {
                repo.Insert(p);
            }
        }
    }
}
