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
        PizzeriaDataSet pizzeriaDataSet;
        public PizzaRepo(PizzeriaDataSet pizzeriaDataSet)
        {
            this.pizzeriaDataSet = pizzeriaDataSet;
        }
        public bool IsAvailablePizza { 
            get => pizzeriaDataSet.Pizza_Orders.Count() > 0; 
            set => throw new NotImplementedException(); 
        }

        public Pizza PopPizza()
        {
            throw new NotImplementedException();
        }

        public bool PushPizza()
        {
            throw new NotImplementedException();
        }
    }
}
