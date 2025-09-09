// 1. add, remove, clear
using System;
using System.Collections;

namespace CsOpdrachten
{
    public class MyLinkedList<T> : IMyList<T>
    {
        private class Node
        {
            public Node? Next;
            public required T Value;
        }

        //list starts empty
        private Node? _head = null;
        private Node? _tail = null;
        private int _count = 0; //for quick returning of the length of list

        public T this[int index]   //O(n)
        {
            get 
            {
                if (_head is null)
                    throw new InvalidOperationException("List is empty");

                Node current = _head;
                for (int i = 0; i < index; i++)
                    current = current.Next!;

                return current.Value;
            }
            set 
            {
                if (_head is null)
                    throw new InvalidOperationException("List is empty");

                Node current = _head;
                for (int i = 0; i < index; i++)
                    current = current.Next!;

                current.Value = value;
            }
        }

        public void Clear()  //O(1)
        {
            //resetting to start
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

            if (_head is null && _tail is null)  //if head was empty before, _head stays at the first node added
            {
                _head = newNode;     //head and tail both point to element
                _tail = newNode;

            }
            else
            {
                _tail!.Next = newNode; //the (old) _tail.Next points to the newNode with the element
                _tail = newNode;      //changeing tail does not change the .Next of the old _tail
            }
            _count++; 
        }
            
        public int IndexOf(T element) //O(n)
        {
            if (_head is null)
                throw new InvalidOperationException("List is empty");

            Node? current = _head;

            for (int i = 0; i < Count(); i++)
            {
                if (EqualityComparer<T>.Default.Equals(current!.Value, element))
                    return i;

                current = current.Next;
            }
            //returns -1 if the element isn't in the list
            return -1;
        }

        public bool Contains(T element) //O(n)
        {
            if (_head is null)
                throw new InvalidOperationException("List is empty");

            Node? current = _head;
            //loop through, return if found
            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(current!.Value, element))
                    return true;

                current = current.Next;
            }
            return false;
        }

        public void Insert(int index, T element) //O(n)
        {
            if (_head is null)
                throw new InvalidOperationException("List is empty");

            if (index < 0 || index >= _count)
                throw new InvalidOperationException("Index out of range");

            Node? current = _head;
            Node? previous = null;

            //node with the value we're inserting
            Node newNode = new()
            {
                Value = element
            };

            //if inserting at the first element 
            if (index == 0)
            {
                newNode.Next = current;
                _head = newNode;
                _count++;
                return;
            }
            //everywhere else
            for (int i = 0; i < index; i++)
            {
                previous = current;
                current = current!.Next;
            }
            previous!.Next = newNode;
            newNode.Next = current;
            
            _count++;
        }

        public void Remove(T element) //O(n)
        {
            if (_head is null)
                throw new InvalidOperationException("List is empty!");

            Node? current = _head; //'current' now points to the same node as _head does <- that how reference types work
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
                previous = current;  
                current = current.Next; 
            }
        }

        public void RemoveAt(int index) //O(n)
        {
            if (_head is null)
                throw new InvalidOperationException("List is empty");

            Node? current = _head;
            Node? previous = null;

            if (index == 0) 
            {
                _head = current.Next;
                _count--;
                return;
            }

            for (int i = 0; i < index; i++)
            {
                previous = current;
                current = current!.Next;
            }

            previous!.Next = current!.Next;
            _count--;
        }

        public int Count() => //O(1)
            _count;

        //can use foreach now 
        public IEnumerator<T> GetEnumerator()
        {
            if (_head is null)
                throw new InvalidOperationException("List is empty");

            Node? current = _head;
            while (current is not null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

