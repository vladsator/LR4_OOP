using System;
using System.Collections.Generic;

namespace LR_3_code_Cch
{


    [Serializable]
    internal class MyList<T>
    {
        private T[] _items;
        private int _size;
        private const int DefaultSize = 1;
        private static readonly T[] EmptyArray = new T[0];

        public MyList()
        {
            _items = new T[DefaultSize];
        }

        public MyList(int length)
        {
            _items = new T[length];
        }

        public MyList(IEnumerable<T> collection)
        {
            var c = collection as ICollection<T>;
            if (c != null)
            {
                int count = c.Count;
                if (count == 0)
                {
                    _items = EmptyArray;
                }
                else
                {
                    _items = new T[count];
                    c.CopyTo(_items, 0);
                    _size = count;
                }
            }
            else
            {
                _size = 0;
                _items = EmptyArray;

                using (IEnumerator<T> en = collection.GetEnumerator())
                {
                    while (en.MoveNext())
                    {
                        Add(en.Current);
                    }
                }
            }
        }

        public void Add(T item)
        {
            if (_size == _items.Length)
            {
                var newItems = new T[_size * 2];
                Array.Copy(_items, 0, newItems, 0, _size);
                _items = newItems;
            }
            _items[_size++] = item;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = default(T);
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }

        public void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_items, 0, _size);
                _size = 0;
                Clearing(this, new ClearEventArgs("List has been cleared!!!"));
            }
        }

        public event EventHandler<ClearEventArgs> Clearing;
    }
}
