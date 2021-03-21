using System;
using System.Collections.Generic;
using System.Text;

namespace teststruct.PizzaRest
{
    public class Pizza
    {
        public int Dish { get; set; }
        public int Time { get; set; }
        public string Name { get; set; }
        public int IdOrder { get; set; }
        /// <summary>
        /// Номер пицы из этого заказа
        /// </summary>
        public int NumbPizza { get; set; }
        /// <summary>
        /// Сколько должно быть пиц в этом заказе
        /// </summary>
        public int QountPizza { get; set; }
        public int IdPizza { get; set; }
        public Pizza(string name,int dish,int time)
        {
            Dish = dish;
            Time = time;
            Name = name;
        }  
    }
}
