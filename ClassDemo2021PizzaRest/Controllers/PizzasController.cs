using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassDemo2021PizzaRest.managers;
using ModelLib.model;
using Microsoft.AspNetCore.Http;

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
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(mgr.Get(id));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }


        [HttpGet]
        [Route("Name/{name}")]
        public IEnumerable<Pizza> Get(string name)
        {
            // hack 
            //return new List<Pizza>(mgr.Get()).Find(p => p.Name.Contains(name));

            return mgr.GetName(name);
        }

        [HttpGet]
        [Route("search")]
        public IEnumerable<Pizza> Search([FromQuery] PizzaFilter filter)
        {
            return mgr.Search(filter);
        }

        // POST api/<PizzasController>
        [HttpPost]
        public bool Post([FromBody] Pizza value)
        {
            return mgr.Create(value);
        }

        // PUT api/<PizzasController>/5
        [HttpPut]
        [Route("{id}")]
        public bool Put(int id, [FromBody] Pizza value)
        {
            return mgr.Update(id, value);
        }

        // DELETE api/<PizzasController>/5
        [HttpDelete]
        [Route("{id}")]
        public Pizza Delete(int id)
        {
            return mgr.Delete(id);
        }
    }
}
