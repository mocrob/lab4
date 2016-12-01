using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5.Classes
{
    public class CStack<T>
    {
        private T[] _array; //массив для хранения данных типа T
        private const int defaultCapacity = 10; //вместимость по умолчанию, потом можно расширить
        private int size; //размер

        public CStack()
        { //конструктор
            this.size = 0;
            this._array = new T[defaultCapacity];
        }

        public bool isEmpty() //проверка на пустоту
        {
            return this.size == 0;
        }

        public virtual int Count //параметр для вывода размера 
        {
            get
            {
                return this.size;
            }
        }

        public T Pop() //метод взятия с вершины
        {
            if (this.size == 0)
            { //вброс ошибки при взятии с пустого стека (Overflow)
                throw new InvalidOperationException();
            }
            return this._array[--this.size];
        }

        public void Push(T newElement)
        {
            if (this.size == this._array.Length)
            { 
                T[] newArray = new T[2 * this._array.Length];
                Array.Copy(this._array, 0, newArray, 0, this.size);
                this._array = newArray; 
            }
            this._array[this.size++] = newElement; //вставляем элемент
        }

        public T Peek()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException();
            }
            return this._array[this.size - 1];
        }
    }
}
