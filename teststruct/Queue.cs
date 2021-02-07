using System;
using System.Collections.Generic;
using System.Text;

namespace teststruct
{
    class Queue<T>
    {
            Lst<T> list;

            public Queue()
            {
                list = new Lst<T>();
            }

            public void Push(T push)
            {
                list.insertToEnd(push);
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
