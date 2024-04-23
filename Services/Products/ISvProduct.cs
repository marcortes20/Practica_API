using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Products
{
    public interface ISvProduct
    {
        public List<Product> GetALLProducts();

        public Product GetProductById(int id);

        public Product AddProduct(Product product);

        public Product UpdateProduct(int id ,Product product);

        public void DeleteProduct(int id);


    }
}
