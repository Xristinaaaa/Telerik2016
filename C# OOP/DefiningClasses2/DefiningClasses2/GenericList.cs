using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses2
{
    public class GenericList<T> where T : IComparable<T>
    {
        private const int size = 5;
        private int count;
        private int capacity;

        private T[] elements;

        public GenericList()
        {
            this.Count = count;
            this.Capacity = size;
            this.elements = new T[size];
        }
        public int Count { get; set; }
        public int Capacity { get; set; }

        public void Add(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.Autogrow();
            }
            this.elements[this.count] = element;
            this.Count++;
        }
        public void Autogrow()
        {
            var old = this.elements;
            this.Capacity *= 2;
            this.elements = new T[Capacity];
            Array.Copy(old, this.elements, this.Count);
        }
        public void Remove(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }

            for (int i = index; i < this.Count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
            this.Count--;
        }
        public void Insert(int index, T newElement)
        {
            if (index >= this.Capacity || index < 0)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }

            var temp = new GenericList<T>();

            for (int i = index; i < this.Count; i++)
            {
                temp.Add(this.elements[i]);
            }

            this.elements[index] = newElement;

            for (int i = 0, j = index + 1; i <= temp.Count; i++, j++)
            {
                this.elements[j] = temp.elements[i];
            }
            this.Count++;
        }
        public void Clear()
        {
            this.Count = 0;
        }

        public override string ToString()
        {
            string output = string.Empty;

            for (int i = 0; i < this.Count; i++)
            {
                output += this.elements[i];
                if (i<this.Count-1)
                {
                    output += ", ";
                }
            }
            return output;
        }
        public T Min()
        {
            T min = this.elements[0];
            foreach (var item in this.elements)
            {
                if (min.CompareTo(item)>0)
                {
                    min = item;
                }
            }
            return min;
        }
        public T Max()
        {
            T max = this.elements[0];
            foreach (var item in this.elements)
            {
                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }
            }
            return max;
        }
    }
}
