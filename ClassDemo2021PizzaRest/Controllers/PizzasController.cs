using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassDemo2021PizzaRest.managers;
using ModelLib.model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassDemo2021PizzaRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private IManagePizzas mgr = new ManagePizza();



        // GET: api/<PizzasController>
        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            return mgr.Get();
        }

        // GET api/<PizzasController>/5
        [HttpGet("{id}")]
        public Pizza Get(int id)
        {
            return mgr.Get(id);
        }

        // POST api/<PizzasController>
        [HttpPost]
        public bool Post([FromBody] Pizza value)
        {
            return mgr.Create(value);
        }

        // PUT api/<PizzasController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Pizza value)
        {
            return mgr.Update(id, value);
        }

        // DELETE api/<PizzasController>/5
        [HttpDelete("{id}")]
        public Pizza Delete(int id)
        {
            return mgr.Delete(id);
        }
    }
}
