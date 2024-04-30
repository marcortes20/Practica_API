using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Products;
using Entities;

namespace API_Ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        public ISvProduct svProduct;

        public ProductController(ISvProduct svProduct)
        {
            this.svProduct = svProduct;
        }


        // GET api/ProductsController
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return svProduct.GetALLProducts();
        }


        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return svProduct.GetProductById(id);
        }


        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            svProduct.AddProduct(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            svProduct.UpdateProduct(id, new Product
            {
                price = product.price,
                title = product.title,
            });
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            svProduct.DeleteProduct(id);
        }

    }
}
