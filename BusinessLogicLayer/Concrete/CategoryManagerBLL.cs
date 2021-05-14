using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class CategoryManagerBLL : ICategoryService
    {
        ICategoryDAL _CategoryDal;

        public CategoryManagerBLL(ICategoryDAL CategoryDal) //sınıfla aynı isimde bir constructor oluştu.
        {
            _CategoryDal = CategoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _CategoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _CategoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _CategoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _CategoryDal.Get(x => x.CategoryId == id);
        }

        public List<Category> GetList()
        {
            return _CategoryDal.List();
        }

        

    }
}
