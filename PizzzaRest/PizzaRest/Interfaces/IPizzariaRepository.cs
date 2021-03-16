using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teststruct.PizzaRest;

namespace PizzzaRest.PizzaRest.Interfaces
{
    public interface IPizzariaRepository
    {
        bool IsAvailablePizza { get; set; }

        Pizza PopPizza();
        bool PushPizza();
    }
}
