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

        public Pizza(string name,int dish,int time)
        {
            Dish = dish;
            Time = time;
            Name = name;
        }  
    }
}
