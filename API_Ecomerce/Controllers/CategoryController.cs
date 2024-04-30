using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Categories;
using Services.Products;

namespace API_Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        public ISvCategory svCategory;

        public CategoryController(ISvCategory svCategory)
        {
            this.svCategory = svCategory;
        }


        // GET api/CategoriesController
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return svCategory.GetALLCategories();
        }


        [HttpGet("{id}")]
        public Category GetById(int id)
        {
            return svCategory.GetCategoryById(id);
        }


        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            svCategory.AddCategory(category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category category)
        {
            svCategory.UpdateCategory(id, new Category
            {
                Name = category.Name,
            });
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            svCategory.DeleteCategory(id);
        }
    } }
