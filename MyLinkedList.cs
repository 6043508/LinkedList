using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsOpdrachten
{
    public class MyLinkedList<T> : IMyList<T>
    {
        private class Node
        {
            public Node? Next;
            public required T Value;
        }

        private Node? _head = null;
        private Node? _tail = null;
        private int _count = 0;

        public T this[int index]   //O(n)
        {
            get 
            {
                Node? current = _head!;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next!;
                }
                return current.Value;
            }
            set 
            {
                Node current = _head!;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next!;
                }
                current.Value = value;
            }
        }

        public void Clear() => //O(1)
            throw new NotImplementedException();

        public void Add(T element) //O(1)
        {

            //maakt de nieuwe node aan
            Node newNode = new()
            {
                Value = element
            };

            if (_head == null && _tail == null)  //_head stays at the first node added
            {
                _head = newNode;     //head and tail both point to element
                _tail = newNode;

            }
            else
            {
                _tail.Next = newNode; //points to the new element, kinda creates it ig
                _tail = newNode;      //sets _tail to new element which is now last in list
            }
                _count++;
        }
            

        public int IndexOf(T element) => //O()
            throw new NotImplementedException();


        public bool Contains(T element) => //O()
            throw new NotImplementedException();

        public void Insert(int index, T element) => //O()
            throw new NotImplementedException();

        public void Remove(T element)
        {
            Node? current = _head!;
            Node? previous = null;

            if (current == null) throw new NullReferenceException();

            for (int i = 0; i < _count; i++)
            {
                previous = current;
                if (EqualityComparer<T>.Default.Equals(current!.Value, element))
                {
                    if (current == _head)
                    {
                        current = current.Next;
                        _count--;
                        return;
                    }

                    previous!.Next = current.Next; //precious.Next (oftewel current) wordt niet meer naar gewezen.. ->removed
                    _count--;
                    return;
                }
                current = current.Next;
            }
        }

        public void RemoveAt(int index) =>
            throw new NotImplementedException();

        public int Count() => //O(1)
            _count;

    }
}
