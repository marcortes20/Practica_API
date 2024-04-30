using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Categories
{
    public interface ISvCategory
    {
        public List<Category> GetALLCategories();

        public Category GetCategoryById(int id);

        public Category AddCategory(Category category);

        public Category UpdateCategory(int id, Category category);

        public void DeleteCategory(int id);
    }
}
