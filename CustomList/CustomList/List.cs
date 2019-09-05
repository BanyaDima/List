using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class List
    {
        private int _index;
        private object[] _array;
        private int _capacity = 8;

        public List()
        {
            InitArray();
        }

        private void InitArray()
        {
            _array = new object[_capacity];
        }

        private void ReInitArray()
        {
            object[] tmpArray = _array;
            _array = new object[_capacity];

            if (tmpArray != null)
            {
                for (int i = 0; i < tmpArray.Length; i++)
                {
                    _array[i] = tmpArray[i];
                }
            }
        }

        public object this[int key]
        {
            get
            {
                return _array[key];
            }
        }

        public void Add(object value)
        {
            if (_index == _capacity)
            {
                _capacity *= 2;
                ReInitArray();
            }
            _array[_index] = value;
            _index++;
        }

        public void Insert(int index, object value)
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

            object[] tmpArray = _array;
            _array[index] = value;

            for (int i = index + 1; i < _index; i++)
            {
                _array[i] = tmpArray[i - 1];
            }
        }

        public void Remove(object value)
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

            for (int i = 0; i < _array.Length; i++)
            {
                if (i == index)
                {
                    _array[i] = null;
                }
            }

            object[] tmpArray = _array;

            for (int i = 0; i < _array.Length; i++)
            {
                if (tmpArray[i] == null)
                {
                    continue;
                }

                _array[i] = tmpArray[i];                
            }

            _index--;
        }

        public int IndexOf(object value)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (value == _array[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            InitArray();
        }

        public bool Conteins(object value)
        {
            return IndexOf(value) >= 0;
        }

        public object[] ToArray()
        {
            object[] copyArray = new object[_array.Length];

            for (int i = 0; i < _array.Length; i++)
            {
                copyArray[i] = _array[i];
            }
            return copyArray;
        }

        public void Revers()
        {
            for (int i = 0; i < _array.Length / 2; i++)
            {
                object tmp = _array[i];
                _array[i] = _array[_array.Length - i - 1];
                _array[_array.Length - i - 1] = tmp;
            }
        }









    }
}
