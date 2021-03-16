using System;
using System.Collections.Generic;
using System.Text;

namespace teststruct.PizzaRest.Workers
{
     public class Dishwasher:Worker
    {
        Dish currentDish;
        int time;
        public  Dishwasher(string name) : base(name)
        {

        }

        public override void Work()
        {
            base.Work();
            if (CurrentState == State.WAIT)
            {
                currentDish = PizzeriaRest.table.PopDish();
                if (currentDish != null)
                {
                    CurrentState = State.WORK;
                    time = currentDish.time;
                }
                
            }
            if (CurrentState == State.WORK)
            {
                if (time != 0)
                {
                    time--;
                    Console.WriteLine("Тарелка моется");
                }
                else
                {
                    currentDish = null;
                    Console.WriteLine("Тарелка помылась");
                    CurrentState = State.WAIT;
                }
            }
        }
    }
}
