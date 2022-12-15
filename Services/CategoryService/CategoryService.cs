using FinanceManager.Data;
using FinanceManager.Models;
using System;

namespace FinanceManager.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            return _db.Categories.ToList();
        }
        public CategoryModel GetCategoryById(int id)
        {
            return _db.Categories.Find(id);
        }
        public void AddCategory(CategoryModel category)
        {
            try
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RemoveCategory(CategoryModel category)
        {
            try
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void EditCategory(CategoryModel category)
        {
            try
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
