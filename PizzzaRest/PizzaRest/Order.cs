using System;
using System.Collections.Generic;
using System.Text;

namespace teststruct.PizzaRest
{
    public class Order
    {
        Lst<Pizza> pizzas = new Lst<Pizza>();
         public void AddPizza(Pizza pizza)
        {
            pizzas.insertToEnd(pizza);
        }
        public Pizza GetPizza()
        {
            if (pizzas.Size != 0)
                return pizzas.delete(0);
            return null;
        }
    }
}
