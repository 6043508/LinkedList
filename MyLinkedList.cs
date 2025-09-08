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
                if (_head is null)
                    throw new NullReferenceException("Add something first idk");

                Node current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next!;
                }
                return current.Value;
            }
            set 
            {
                if (_head is null)
                    throw new NullReferenceException("Add something first idk");

                Node current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next!;
                }
                current.Value = value;
            }
        }

        public void Clear()
        {
            //not pointing to any nodes... so... it's empty right?
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void Add(T element) //O(1)
        {

            //maakt de nieuwe node aan
            Node newNode = new()
            {
                Value = element
            };

            if (_head is null && _tail is null)  //_head stays at the first node added
            {
                _head = newNode;     //head and tail both point to element
                _tail = newNode;

            }
            else
            {
                _tail!.Next = newNode; //the (old) _tail.Next points to the newNode with the element
                _tail = newNode;      //changeing tail does not change the .Next of the old _tail
            }
            _count++; //for quick returning of the length 
        }
            

        public int IndexOf(T element) => //O()
            throw new NotImplementedException();


        public bool Contains(T element) => //O()
            throw new NotImplementedException();

        public void Insert(int index, T element) => //O()
            throw new NotImplementedException();

        public void Remove(T element)
        {
            if (_head is null)
                throw new InvalidOperationException("List is empty!");

            Node? current = _head; //'current' copied the reference of the Node _head is pointing to, so now it's also pointing at that
            Node? previous = null;

            while(current is not null)
            { 
                if (EqualityComparer<T>.Default.Equals(current.Value, element)) //compares the current to T element
                {
                    if (previous is null)   //checks if current is the first item the list
                    {
                        _head = current.Next;  //_head points to the same reference as current.Next 
                        _count--;
                        return;
                    }
                    else
                    {
                        previous.Next = current.Next; //previous.Next points to the Node current.Next is pointing to, skipping over current
                        _count--;
                        return; 
                    }
                }
                previous = current; //  e.g. current is 3, previous copied the reference of current, and also points at the same 3
                current = current.Next; //current points to current.Next, lets say 4 idk. so current = 3, next = 4
            }
        }

        public void RemoveAt(int index) =>
            throw new NotImplementedException();

        public int Count() => //O(1)
            _count;

    }
}
