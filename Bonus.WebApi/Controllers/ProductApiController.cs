using Bonus.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Bonus.WebApi.Controllers
{
    public class ProductApiController : ApiController
    {
        public static Lazy<List<ProductViewModels>> products = new Lazy<List<ProductViewModels>>();
        public static int PgaeLoadFlag = 1;
        public static int ProductID = 4;

        public ProductApiController()
        {
            if (PgaeLoadFlag == 1)
            {
                products.Value.Add(new ProductViewModels { ID = 1, Name = "bus", Category = "Toy", Price = 200.12M });
                products.Value.Add(new ProductViewModels { ID = 2, Name = "Car", Category = "Toy", Price = 300 });
                products.Value.Add(new ProductViewModels { ID = 3, Name = "robot", Category = "Toy", Price = 3000 });
                PgaeLoadFlag++;
            }
        }

        //GET api/products
        public List<ProductViewModels> GetAllProducts()
        {
            return products.Value;
        }

        // GET api/product/5
        public IHttpActionResult GetProduct(int id)
        {
            ProductViewModels product = products.Value.FirstOrDefault((p) => p.ID == id);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public void ProductAdd(ProductViewModels product)
        {
            product.ID = ProductID;
            products.Value.Add(product);
            ProductID++;
        }
    }
}
