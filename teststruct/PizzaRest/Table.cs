using System;
using System.Collections.Generic;
using System.Text;

namespace teststruct.PizzaRest
{
    class Table
    {
        const int MAX_STACK_SIZE = 3;
        const int MAX_SIZE_ARR = 3;
        Stack<Dish>[] stacks = new Stack<Dish>[M];
        public bool AddDish(Dish dish)
        {
            for (int i = 0; i < 3; i++)
            {
                if (stacks[i] == null)
                {
                    stacks[i] = new Stack<Dish>();
                    stacks[i].Push(dish);
                    return true;
                }
                else if (stacks[i].Size()  < MAX_STACK_SIZE)
                {
                    stacks[i].Push(dish);
                    return true;
                }

            }
            return false;
        }

        public Dish PopDish()
        {
            for (int i = 0; i < 3; i++)
            {

            }
            stacks
        }
    }
}
