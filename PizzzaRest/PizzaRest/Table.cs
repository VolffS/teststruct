using System;
using System.Collections.Generic;
using System.Text;

namespace teststruct.PizzaRest
{
    public class Table
    {
        const int MAX_STACK_DISH = 3;
        /// <summary>
        /// Максимальное колчество тарелок
        /// </summary>
        const int MAX_SIZE_ARR = 3;
        /// <summary>
        /// Максимальное количество стопок с тарелками
        /// </summary>
        Stack<Dish>[] stacks = new Stack<Dish>[MAX_SIZE_ARR];

        public Table()
        {
            for (int i = 0; i < MAX_SIZE_ARR; i++)
                stacks[i] = new Stack<Dish>();
        }

        public bool AddDish(Dish dish)
        {
            for (int i = 0; i < MAX_SIZE_ARR; i++)
            {
               if (stacks[i].Size()  < MAX_STACK_DISH)
                {
                    stacks[i].Push(dish);
                    return true;
                }

            }
            return false;
        }

        public Dish PopDish()
        {
            for (int i = 0; i < MAX_SIZE_ARR; i++)
            {
                if (stacks[i].Size() != 0) 
                    return stacks[i].Pop();
            }
            return null;
        }

    }
}
