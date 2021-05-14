using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category> 
    {
        public CategoryValidator() //constructor methodu
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Adı Bu Kadar Kısa Olamaz!");
            RuleFor(x => x.CategoryName).MaximumLength(100).WithMessage("Kategori Adı Bu Kadar Uzun Olamaz!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklaması Boş Geçilemez!");
            RuleFor(x => x.CategoryDescription).MinimumLength(50).WithMessage("Kategori Açıklaması Bu Kadar Kısa Olamaz!");
            RuleFor(x => x.CategoryDescription).MaximumLength(1000).WithMessage("Kategori Açıklaması Bu Kadar Uzun Olamaz!");
        }
    }
}
