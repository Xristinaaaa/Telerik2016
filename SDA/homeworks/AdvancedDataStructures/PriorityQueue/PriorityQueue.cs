using System;
using System.Collections;
using System.Collections.Generic;

namespace PriorityQueuee
{
    public class PriorityQueue<TPriority, TValue> : ICollection<KeyValuePair<TPriority, TValue>>
    {
        private List<KeyValuePair<TPriority, TValue>> baseHeap;
        private IComparer<TPriority> comparer;
        public PriorityQueue(IComparer<TPriority> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException();
            }

            this.baseHeap = new List<KeyValuePair<TPriority, TValue>>();
            this.comparer = comparer;
        }
        private void Insert(TPriority priority, TValue value)
        {
            KeyValuePair<TPriority, TValue> val = new KeyValuePair<TPriority, TValue>(priority, value);
            baseHeap.Add(val);
            HeapifyFromEndToBeginning(baseHeap.Count - 1);
        }
        public void Enqueue(TPriority priority, TValue value)
        {
            Insert(priority, value);
        }
        
        public KeyValuePair<TPriority, TValue> Dequeue()
        {
            if (!IsEmpty)
            {
                KeyValuePair<TPriority, TValue> result = baseHeap[0];
                DeleteRoot();
                return result;
            }
            else
            {
                throw new InvalidOperationException("Priority queue is empty");
            }
        }
        public TValue DequeueValue()
        {
            return Dequeue().Value;
        }
        public KeyValuePair<TPriority, TValue> Peek()
        {
            if (!IsEmpty)
            {
                return baseHeap[0];
            }
            else
            {
                throw new InvalidOperationException("Priority queue is empty");
            }
        }
        public TValue PeekValue()
        {
            return Peek().Value;
        }
        
        public bool IsEmpty
        {
            get
            {
                return baseHeap.Count == 0;
            }
        }
        private void ExchangeElements(int pos1, int pos2)
        {
            KeyValuePair<TPriority, TValue> val = baseHeap[pos1];
            baseHeap[pos1] = baseHeap[pos2];
            baseHeap[pos2] = val;
        }

        private int HeapifyFromEndToBeginning(int pos)
        {
            if (pos >= baseHeap.Count) return -1;

            while (pos > 0)
            {
                int parentPos = (pos - 1) / 2;
                if (comparer.Compare(baseHeap[parentPos].Key, baseHeap[pos].Key) > 0)
                {
                    ExchangeElements(parentPos, pos);
                    pos = parentPos;
                }
                else break;
            }
            return pos;
        }


        private void DeleteRoot()
        {
            if (baseHeap.Count <= 1)
            {
                baseHeap.Clear();
                return;
            }

            baseHeap[0] = baseHeap[baseHeap.Count - 1];
            baseHeap.RemoveAt(baseHeap.Count - 1);
            
            HeapifyFromBeginningToEnd(0);
        }

        private void HeapifyFromBeginningToEnd(int pos)
        {
            if (pos >= baseHeap.Count) return;

            while (true)
            {
                int smallest = pos;
                int left = 2 * pos + 1;
                int right = 2 * pos + 2;
                if (left < baseHeap.Count && comparer.Compare(baseHeap[smallest].Key, baseHeap[left].Key) > 0)
                {
                    smallest = left;
                }
                if (right < baseHeap.Count && comparer.Compare(baseHeap[smallest].Key, baseHeap[right].Key) > 0)
                {
                    smallest = right;
                }

                if (smallest != pos)
                {
                    ExchangeElements(smallest, pos);
                    pos = smallest;
                }
                else
                {
                    break;
                }
            }
        }
        
        public void Add(KeyValuePair<TPriority, TValue> item)
        {
            Enqueue(item.Key, item.Value);
        }
        public void Clear()
        {
            baseHeap.Clear();
        }
        public bool Contains(KeyValuePair<TPriority, TValue> item)
        {
            return baseHeap.Contains(item);
        }
        
        public int Count
        {
            get
            {
                return baseHeap.Count;
            }
        }
        public void CopyTo(KeyValuePair<TPriority, TValue>[] array, int arrayIndex)
        {
            baseHeap.CopyTo(array, arrayIndex);
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(KeyValuePair<TPriority, TValue> item)
        {
            int elementIdx = baseHeap.IndexOf(item);
            if (elementIdx < 0)
            {
                return false;
            }

            baseHeap[elementIdx] = baseHeap[baseHeap.Count - 1];
            baseHeap.RemoveAt(baseHeap.Count - 1);

            int newPos = HeapifyFromEndToBeginning(elementIdx);
            if (newPos == elementIdx)
            {
                HeapifyFromBeginningToEnd(elementIdx);
            }

            return true;
        }
        public IEnumerator<KeyValuePair<TPriority, TValue>> GetEnumerator()
        {
            return baseHeap.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
