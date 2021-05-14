using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAdd(Category category);
        Category GetByID(int id); //dışarıdan bir id değeri gibi düşünülebilir.
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
    }
}
