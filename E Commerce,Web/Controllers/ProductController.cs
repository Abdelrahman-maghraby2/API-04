using E_Commerce_Web.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet ("{id}")]   
        public ActionResult<Product> Get(int id)
        {
            return new Product() {Id=id, Name="Test" };        
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return new List<Product>();
        }

        [HttpPost]  
        public ActionResult<Product> AddProduct(Product product)
        {
            return product;
        }
        [HttpPut]  
        public ActionResult<Product> Update(Product product)
        {
            return product;
        }
        [HttpDelete]  
        public ActionResult<Product> Delete(Product product)
        {
            return product;
        }

    }
}
