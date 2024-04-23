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


        // GET api/PRODUCTS
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


        //Terminar los demas endponts

    }
}
