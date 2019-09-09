using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class List<T>
    {
        private int _index;
        private T[] _array;
        private int _capacity = 8;

        public int Count
        {
            get
            {
                return _index;
            }
        }

        public List()
        {
            InitArray();
        }

        private void InitArray()
        {
            _array = new T[_capacity];
        }

        private void ReInitArray()
        {
            T[] tmpArray = _array;
            _array = new T[_capacity];

            if (tmpArray != null)
            {
                for (int i = 0; i < tmpArray.Length; i++)
                {
                    _array[i] = tmpArray[i];
                }
            }
        }

        public T this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public void Add(T value)
        {
            if (_index == _capacity)
            {
                _capacity *= 2;
                ReInitArray();
            }
            _array[_index] = value;
            _index++;
        }

        public void Insert(int index, T value)
        {
            if (index > _index)
            {
                throw new ArgumentException("Unable to insert item at this position!");
            }

            _index++;

            if (_index >= _capacity)
            {
                _capacity *= 2;
                ReInitArray();
            }

            T[] tmpArray = _array;
            InitArray();

            _array[index] = value;

            for (int i = 0, j = 0; i < tmpArray.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }
                _array[i] = tmpArray[j];
                j++;
            }
        }

        public void Remove(T value)
        {
            int index = IndexOf(value);
            if (index >= 0)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (index > _index)
            {
                throw new ArgumentException("Unable to insert item at this position!");
            }

            T[] tmpArray = _array;
            InitArray();

            for (int i = 0, j = 0; i < _index; i++, j++)
            {
                if (j == index)
                {
                    j++;

                }
                _array[i] = tmpArray[j];
            }
            _index--;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            _index = 0;
            _capacity = 8;
            InitArray();           
        }

        public bool Conteins(T value)
        {
            return IndexOf(value) >= 0;
        }

        public T[] ToArray()
        {
            T[] copyArray = new T[_index];

            for (int i = 0; i < _index; i++)
            {
                copyArray[i] = _array[i];
            }
            return copyArray;
        }

        public void Revers()
        {
            for (int i = 0; i < _index / 2; i++)
            {
                T tmp = _array[i];
                _array[i] = _array[_index - i - 1];
                _array[_index - i - 1] = tmp;
            }
        }
    }
}
