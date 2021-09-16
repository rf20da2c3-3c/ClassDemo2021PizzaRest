using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib.model;

namespace ClassDemo2021PizzaRest.managers
{
    public interface IManagePizzas
    {
        /// <summary>
        /// Get all pizzas
        /// </summary>
        /// <returns>A list of existing Pizzas</returns>
        IEnumerable<Pizza> Get();

        Pizza Get(int id);

        bool Create(Pizza pizza);

        bool Update(int id, Pizza pizza);

        Pizza Delete(int id);

    }
}
