using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsOpdrachten
{
    public class MyLinkedList<T> : IMyList<T>
    {
        private List<T> _list = [];

        public T this[int index]   //O(n)
        { 
            get => _list[index]; 
            set => _list[index] = value; 
        }

        public void Clear() => //O(1)
            _list.Clear(); 

        public void Add(T element) => //O(n)
            _list.Add(element); 

        public int IndexOf(T element) => //O(n)
            _list.IndexOf(element); 

        public bool Contains(T element) => //O(n)
            _list.Contains(element);

        public void Insert(int index, T element) => //O(n)
            _list.Insert(index, element);
        
        public void Remove(T element) => //O(n)
            _list.Remove(element);

        public void RemoveAt(int index) =>
            _list.RemoveAt(index);

        public int Count() => //O(1)
            _list.Count;

    }
}
