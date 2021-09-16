using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib.model;

namespace ClassDemo2021PizzaRest.managers
{
    public class ManagePizza:IManagePizzas
    {
        private static List<Pizza> _data = new List<Pizza>()
        {
            new Pizza(10, "magurita", 34.50),
            new Pizza(12, "Peters", 55)

        };

        public ManagePizza()
        {
            //_data.Add(new Pizza());

            // dårlig ide flydes på hver gang der laves et objekt
        }


        public IEnumerable<Pizza> Get()
        {
            return new List<Pizza>(_data);
        }

        public Pizza Get(int id)
        {
            return _data.Find(p => p.Id == id);
        }

        public bool Create(Pizza pizza)
        {
            // todo check for duplicates
            _data.Add(pizza);
            return true;
        }

        public bool Update(int id, Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public Pizza Delete(int id)
        {
            Pizza p = Get(id);
            _data.Remove(p);
            return p;
        }
    }
}
