using Entities;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Categories
{
    public class SvCategory : ISvCategory
    {

        private MyContext _myContext;

        public SvCategory()
        {
            _myContext = new MyContext();
        }

        public Category AddCategory(Category category)
        {
           _myContext.Categories.Add(category);
           _myContext.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            Category catToRemove = _myContext.Categories.Find(id);

            if (catToRemove != null)
            {
                _myContext.Categories.Remove(catToRemove);
                _myContext.SaveChanges();
            }
        }

        public List<Category> GetALLCategories()
        {
            return _myContext.Categories.Include(x => x.products).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _myContext.Categories.Include(x => x.products).SingleOrDefault(x => x.Id == id);
        }

        public Category UpdateCategory(int id, Category category)
        {
            Category catToUpdate = _myContext.Categories.Find(id);
            catToUpdate.Name = category.Name;

            _myContext.Update(catToUpdate);
            _myContext.SaveChanges();

            return category;
        }
    }
}
