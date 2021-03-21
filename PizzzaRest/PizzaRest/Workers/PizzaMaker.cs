using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace teststruct.PizzaRest.Workers
{
    public class PizzaMaker:Worker
    {
        
        /// <summary>
        /// Время оставшиеся до конца приготавления пиццы
        /// </summary>
        int time;
        Pizza currentPizza;

        public delegate void PizzaEventhandler(PizzaMaker maker, Pizza pizza);
        public delegate void PizzaEventhandlerWait();

        public event PizzaEventhandler StartCook;
        public event PizzaEventhandler OnCook;
        public event PizzaEventhandler EndCook;
        public event PizzaEventhandlerWait WaitCook;


        //Order currentOrder;
        public PizzaMaker(string name):base(name)
        {
               
        }

        public override void Work()
        {
            
            base.Work();
            if(CurrentState==State.WAIT)
            {
                if (PizzeriaRest.pizzariaRepository.IsAvailablePizza == true)
                {
                    currentPizza = PizzeriaRest.pizzariaRepository.PopPizza();
                    time = currentPizza.Time;
                    CurrentState = State.WORK;
                    StartCook.Invoke(this, currentPizza);                    
                }
                else
                {
                    WaitCook.Invoke();
                }
            }
            if (CurrentState == State.WORK)
            {
                if (time == 0)
                {
                    EndCook.Invoke(this, currentPizza);
                    PizzeriaRest.pizzariaRepository.PushPizza(currentPizza);
                    for (int i = 0; i < currentPizza.Dish; i++)
                    {
                        PizzeriaRest.table.AddDish(new Dish(PizzeriaRest.random.Next(1, 12)));
                    }
                    
                    //Console.WriteLine($"Повар отнёс {currentPizza.Dish} тарелок");
                    CurrentState = State.WAIT;
                }
                else
                {
                    OnCook.Invoke(this, currentPizza);
                    
                    time--;
                    //Console.WriteLine($"Временни осталось {time}");
                } 
            }
            
        }
    }
}
