using System;
using System.Collections.Generic;
using System.Text;

namespace teststruct
{
    class Stack<T>
    {
        Lst<T> list;

        public Stack()
        {
            list = new Lst<T>();
        }

        public void Push(T push)
        {
            list.insertToStart(push);
        }
        public T Pop()
        {
           return list.delete(0);
        }
        public T Peek()
        {
            return list.Element(0);
        }
        public int Size()
        {
            return list.Size;
        }
    }
}
