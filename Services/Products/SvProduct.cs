﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Products
{
    public class SvProduct : ISvProduct
    {
        private MyContext myContext; 

        public SvProduct()
        {
            myContext = new MyContext();
        }


        public Product AddProduct(Product product)
        {
            myContext.Products.Add(product);
            myContext.SaveChanges();
            return product;
           
        }

        public void DeleteProduct(int id)
        {
            Product productToDelete = myContext.Products.Find(id);

            if (productToDelete is not null)
            {


                myContext.Products.Remove(productToDelete);
                myContext.SaveChanges();

            }


        }

        public List<Product> GetALLProducts()
        {
            return myContext.Products.Include(x =>x.Category).ToList();

        }

        public Product GetProductById(int id)
        {
            return myContext.Products.Include(x => x.Category).SingleOrDefault(x => x.id == id);


        }

        public Product UpdateProduct(int id,Product product)
        {

            Product productToUpdate = myContext.Products.Find(id);

            if (productToUpdate is not null)
            {
                productToUpdate.title = product.title;
                productToUpdate.price = product.price;
                myContext.Products.Update(productToUpdate);
                myContext.SaveChanges();

            }
            return productToUpdate;

        }
    }
}
