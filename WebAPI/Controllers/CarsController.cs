using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CarsController : Controller
    {
        [HttpGet]
        public  List<Car> Get()
        {
            return new List<Car> {
                new Car
                {
                    Id = 1,
                    Description = "Renault"
                },
                new Car
                {
                    Id = 1,
                    Description = "Renault"
                }
            };

        }
    }
}
