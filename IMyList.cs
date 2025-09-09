using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsOpdrachten
{
    public interface IMyList<T> : IEnumerable<T>
    {
        public void Clear();
        public void Add(T element);
        public int IndexOf(T element);
        public bool Contains(T element);
        public void Insert(int index, T element);
        public void Remove(T element);
        public void RemoveAt(int index);
        public T this[int index] { get; set; }
        public int Count();
    }
}
