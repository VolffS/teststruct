using System;
using System.Collections.Generic;
using System.Text;

namespace teststruct.PizzaRest.Workers
{
    class PizzaMaker:Worker
    {
        /// <summary>
        /// Время оставшиеся до конца приготавления пиццы
        /// </summary>
        int time;
        Pizza currentPizza;
        Order currentOrder;
        public PizzaMaker(string name):base(name)
        {
               
        }

        public override void Work()
        {
            
            base.Work();
            if(CurrentState==State.WAIT)
            {
                if (PizzeriaRest.pizzaOrders.Size > 0)
                    CurrentState = State.WORK;
            }
            if (CurrentState == State.WORK)
            {
                if (currentOrder == null)
                {
                    currentOrder = PizzeriaRest.pizzaOrders.delete(0);
                }
                else
                {
                    if (currentPizza == null)
                    {
                        currentPizza = currentOrder.GetPizza();
                        if (currentPizza == null)
                        {
                            currentOrder = null;
                            CurrentState = State.WAIT;
                        }
                        else
                        {
                            time = currentPizza.Time;
                        }
                    }
                    else
                    {
                       if (time == 0)
                        {
                            Console.WriteLine($"Пицца {currentPizza.Name} готова");
                            for (int i = 0; i < currentPizza.Dish; i++)
                            {
                                PizzeriaRest.table.AddDish(new Dish(PizzeriaRest.random.Next(1,12)));
                            }
                            Console.WriteLine($"Повар отнёс {currentPizza.Dish} тарелок");
                            currentPizza = null;
                        } 
                       else
                        {
                            Console.WriteLine($"Пицца {currentPizza.Name} готовиться");
                            time--;
                            Console.WriteLine($"Временни осталось {time}");
                        }
                    }
                }
                
            }
            
        }
    }
}
