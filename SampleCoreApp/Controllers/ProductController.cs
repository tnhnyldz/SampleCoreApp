using Microsoft.AspNetCore.Mvc;
using SampleCoreApp.Models;
using System.Collections.Generic;

namespace SampleCoreApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product 
                { 
                    Id = 1,
                    Description = "Test",
                    Name = "Test",  
                },
                new Product
                {
                    Id = 2,
                    Description = "Test",
                    Name = "Test",
                },
                new Product
                {
                    Id = 3,
                    Description = "Test",
                    Name = "Test",
                },
                new Product
                {
                    Id = 4,
                    Description = "Test",
                    Name = "Test",
                },
            };
            #region Information
            //Controllerdan viewa 4 farklı sekılde veri gider 
            //biri model bazlı digerlerı verı tasıma baglerıyle gıder
            #endregion
            return View(products);
        }
    }
}
