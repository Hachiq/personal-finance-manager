using FinanceManager.Models;
using System.Diagnostics.Eventing.Reader;

namespace FinanceManager.Services.CategoryService
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetCategories();
        CategoryModel GetCategoryById(int id);
        public void AddCategory(CategoryModel category);
        public void RemoveCategory(CategoryModel category);
        public void EditCategory(CategoryModel category);
    }
}
