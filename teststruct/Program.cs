using System;
using System.Threading;
using teststruct.PizzaRest;
using teststruct.PizzaRest.Workers;

namespace teststruct
{
    class Arr
    {
        private int[] _arr = null;
        public int Size { get; private set; }

        public Arr(int size)
        {
            Size = size;
            _arr = new int[size];
        }

        /// <summary>
        /// Вставка по индексу
        /// </summary>
        /// <param name="ind"></param>
        /// <param name="elem"></param>
        /// <returns></returns>
        public bool insert(int ind, int elem)
        {
            if(ind > Size)
            {
                return false;
            }

            _arr[ind] = elem;

            return true;
        }

        /// <summary>
        /// Вставка в конец массива
        /// </summary>
        /// <param name="ind"></param>
        /// <param name="elem"></param>
        /// <returns></returns>
        public void insert(int elem)
        {
            for (int i=0;i<Size;i++)
            {
                if (_arr[i] == 0) 
                {
                    _arr[i] = elem;
                    return;
                }

            }
            int[] temp = _arr;
            //_arr = new int[Size*2];
            _arr = new int[++Size];

            for (int i = 0; i < Size-1; i++) 
            {
                _arr[i] = temp[i];
            }
            _arr[Size-1] = elem;
            //Size *= 2; 
        }
    }

    class Node<T>
    {
        /// <summary>
        /// указатель на след узел
        /// </summary>
        public Node<T> pointer;
        public T data;

        public Node(T data)
        {
            this.data = data;
        }
    }

    /// <summary>
    /// лист
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Lst<T>
    {
        public int Size { get; private set; }
        /// <summary>
        /// Начало списка
        /// </summary>
        Node<T> start;

        /// <summary>
        /// Конец списка
        /// </summary>
        Node<T> end;

        public Lst()
        {
            Size = 0;
            this.start = null;
            this.end = null;
        }

        public void insertToEnd(T elem)
        {
            if (Size == 0)
            {
                start = new Node<T>(elem);
                end = start;
            }
            else 
            {
                Node<T> temp = new Node<T>(elem);
                end.pointer = temp;
                end = temp;
            }
            Size++;
        }
        public int Find(T element)
        {
            Node<T> current = start;
            T temp;
            for (int i = 0; i < Size; i++)
            {
                temp = current.data;
                if (temp.Equals(element)) return i;
                current = current.pointer;

            }
            return -1;
          }

        public T Element(int index)
        {
            Node<T> currentNode = start;
            int c = 0;
            if (c == index)
            {
                return (currentNode.data );
            }
            while (c < index)
            {
                currentNode = currentNode.pointer;
                c++;

            }
            return currentNode.data;
        }

        public T delete(int index)
        {
            Node<T> currentNode = start;
            int c = 0;
            T temp;
            if (c == index)
            {
                temp =currentNode.data;
                start = currentNode.pointer;
                Size--;
                return(temp);
            }
            while (c < index-1)
            {
                currentNode = currentNode.pointer;
                c++;
             
            }
            temp = currentNode.pointer.data;
            currentNode.pointer = currentNode.pointer.pointer;

            if (Size - 1 == index)
                end = currentNode;

            Size--;
            return (temp);
        }

        public void update(int index, T newElement)
        {
            Node<T> currentNode = start;
            int c = 0;
            while (c < index )
            {
                currentNode = currentNode.pointer;
                c++;
            }
            currentNode.data = newElement;
        }
        public void insertToStart(T elem)
        {
            if (Size == 0)
            {
                start = new Node<T>(elem);
                end = start;
            }
            else
            {
                Node<T> temp = new Node<T>(elem);
                temp.pointer = start;
                start = temp;
            }
            Size++;
        }
    }

    class Program
    {
         
        static void Main(string[] args)
        {
            Random rand = new Random();
            Arr arr = new Arr(5);
            arr.insert(1, 2);
            DateTime time = DateTime.Now;
            Lst<int> l = new Lst<int>();
            
            for (int i = 0; i < 5; i++)
            {
                l.insertToStart(i);
                arr.insert(i);
            }
            l.update(4,55);


            Console.WriteLine("TIme :" + (DateTime.Now - time));
            Queue<int> stak = new Queue<int>();
            Table table = new Table();

            

            Worker pizzaMaker = new PizzaMaker("Gleb");
            Worker disshwasher = new Dishwasher("OLEG");
            PizzeriaRest pizzeriaRest = new PizzeriaRest();
            pizzeriaRest.AddWorker(pizzaMaker);
            pizzeriaRest.AddWorker(disshwasher);
            var ord1 = new Order();
            ord1.AddPizza(new Pizza("Вкусная",3,15));
            ord1.AddPizza(new Pizza("Нажористая",5,18));
            pizzeriaRest.pizzaOrders.insertToStart(ord1);
            Order ord2 = new Order();
            ord2.AddPizza(new Pizza("Вкусная", 3, 15));
            ord2.AddPizza(new Pizza("Вкусная", 3, 15));
            ord2.AddPizza(new Pizza("Вкусная", 3, 15));
            ord2.AddPizza(new Pizza("Вкусная", 3, 15));
            pizzeriaRest.pizzaOrders.insertToStart(ord2);
            while (true)
            {
                pizzeriaRest.Work();
                Thread.Sleep(1000);
                Console.Clear();
            }
   
        }
    }
}
