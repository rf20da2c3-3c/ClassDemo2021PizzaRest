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
            if (_data.Exists(p => p.Id == id))
            {
                return _data.Find(p => p.Id == id);
            }

            throw new KeyNotFoundException($"Id {id} findes ikke");
        }

        public IEnumerable<Pizza> GetName(string name)
        {
            return _data.FindAll(p => p.Name.StartsWith(name));
        }

        public IEnumerable<Pizza> Search(PizzaFilter filter)
        {
            double min = filter.MinPris;
            double max = (filter.MaxPris == 0) ? Double.MaxValue : filter.MaxPris;

            return _data.Where(p => min <= p.Price && p.Price <= max);
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
