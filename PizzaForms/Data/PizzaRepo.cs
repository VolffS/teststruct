using PizzzaRest.PizzaRest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teststruct.PizzaRest;

namespace PizzaForms.Data
{
    
    public class PizzaRepo : IPizzariaRepository
    {
        public delegate void UpdateTable();
        public event UpdateTable BeginUpdate;
        int CountPizza = 0;
        List<Pizza> pizzas=new List<Pizza>();
        PizzeriaDataSet pizzeriaDataSet;
        public PizzaRepo(PizzeriaDataSet pizzeriaDataSet)
        {
            this.pizzeriaDataSet = pizzeriaDataSet;
        }
        public bool IsAvailablePizza { 
            get => pizzeriaDataSet.Pizza_Orders.Where(x => x.State == "Не готово").Count() > 0; 
            set => throw new NotImplementedException(); 
        }

        public Pizza PopPizza()
        {               
            if ( pizzas.Count == 0)
            {
                var pizza_Orders = from Tb1 in pizzeriaDataSet.Pizza_Orders
                                   join Tb2 in pizzeriaDataSet.Pizza on Tb1.Pizza equals Tb2.Id_Pizza
                                   where Tb1.State == "Не готово"
                                   select new Pizza(Tb2.Name, 12, 12)
                                   {
                                       IdOrder = Tb1.Id_Order,
                                       QountPizza = Tb1.Quantity,
                                       IdPizza = Tb1.Pizza
                                   };
                foreach (var item in pizza_Orders)
                {
                    int i = item.QountPizza;
                    for (int q = 0; q < i; q++)
                    {
                        item.NumbPizza = q+1;
                        pizzas.Add(item);
                    }
                }
                var temp = pizzas[0];
                pizzas.RemoveAt(0);
                return temp;
            }
            else
            {
                var pizz = pizzeriaDataSet.Pizza_Orders.Where(x => x.Id_Order == pizzas[0].IdOrder);
                foreach (var line in pizz)
                {
                    if (line.Pizza == pizzas[0].IdPizza && line.Quantity == pizzas[0].NumbPizza)
                    {
                        line.State = "Ожидание";
                        BeginUpdate.Invoke();

                    }
                }
                var temp = pizzas[0];
                pizzas.RemoveAt(0);
                return temp;
            }






            //int temp;
            //var pizza_order = pizzeriaDataSet.Pizza_Orders.Where(x => x.State == "Не готово").First();
            //if (pizza_order.Quantity == CountPizza+1)
            //{
            //    pizza_order.State = "Ожидание";
            //    BeginUpdate.Invoke();
            //    temp = CountPizza;
            //    CountPizza = 0;
            //}
            //else
            //{
            //    CountPizza++;
            //    temp = CountPizza;
            //}
            //var pizza = pizzeriaDataSet.Pizza.First(x => x.Id_Pizza == pizza_order.Pizza);
            //return new Pizza(pizza.Name, 12, 12)
            //{
            //    IdOrder = pizza_order.Id_Order,
            //    NumbPizza = temp,
            //    IfPizza = pizza_order.Pizza
            //};
        }

        public bool PushPizza(Pizza pizza)
        {
            var pizz = pizzeriaDataSet.Pizza_Orders.Where(x => x.Id_Order == pizza.IdOrder);
            foreach (var line in pizz)
            {
                if (line.Pizza==pizza.IdPizza && line.Quantity == pizza.NumbPizza)
                {
                    line.State = "Готово";
                    BeginUpdate.Invoke();

                }
            }
            return true;
                       

        }
    }
}
