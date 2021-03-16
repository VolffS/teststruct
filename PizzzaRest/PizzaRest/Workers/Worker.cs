using System;
using System.Collections.Generic;
using System.Text;

namespace teststruct.PizzaRest.Workers
{
    /// <summary>
    /// Возможные состояния 
    /// </summary>
    public enum State
    {
        /// <summary>
        /// работае
        /// </summary>
        WORK,
        /// <summary>
        /// ждёт
        /// </summary>
        WAIT
    }
    public abstract class Worker
    {
        public String Name { get; private set; }
        public State CurrentState { get; set; }

        public Worker(string name)
        {
            Name = name;
            CurrentState = State.WAIT;
        }

        public virtual void Work()
        {
            Console.WriteLine($"Начал работу {Name}");
        }

        public PizzeriaRest PizzeriaRest { get; set; }
    }
}
