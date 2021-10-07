using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib.model;

namespace ClassDemo2021PizzaRest.managers
{
    public class PizzaContext: DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options): base(options)
        {
            
        }

        public DbSet<Pizza> Pizzas { get; set; }
    }
}
