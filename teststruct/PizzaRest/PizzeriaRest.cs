using System;
using System.Collections.Generic;
using System.Text;
using teststruct.PizzaRest.Workers;

namespace teststruct.PizzaRest
{
    class PizzeriaRest
    {
        Lst<Worker> listWorkers = new Lst<Worker>();

        public Random random = new Random();
        public readonly Lst<Order> pizzaOrders = new Lst<Order>();
        public Table table = new Table();

        public void AddWorker(Worker worker)
        {
            listWorkers.insertToEnd(worker);
            worker.PizzeriaRest = this;
        }

        public void DeliteWorkers(Worker worker)
        {
            if (listWorkers.Find(worker) >= 0)
            {
                listWorkers.delete(listWorkers.Find(worker));
                worker.PizzeriaRest = null;
            }
        }

        public void Work()
        {
            for (int i = 0; i < listWorkers.Size; i++)
            {
                listWorkers.Element(i).Work();
            }
        }

    }
}
