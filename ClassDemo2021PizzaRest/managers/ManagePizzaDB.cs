using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib.model;

namespace ClassDemo2021PizzaRest.managers
{
    public class ManagePizzaDB: IManagePizzas
    {
        private readonly PizzaContext _context;

        public ManagePizzaDB(PizzaContext context)
        {
            _context = context;
        }


        public IEnumerable<Pizza> Get()
        {
            return _context.Pizzas;
        }

        public Pizza Get(int id)
        {
            return _context.Pizzas.Find(id);
        }

        public IEnumerable<Pizza> GetName(string name)
        {
            return _context.Pizzas.Where(p => p.Name.Contains(name));
        }

        public IEnumerable<Pizza> Search(PizzaFilter filter)
        {
            throw new NotImplementedException();
        }

        public bool Create(Pizza pizza)
        {
            pizza.Id = 0;
            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
            return true;

        }

        public bool Update(int id, Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public Pizza Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
