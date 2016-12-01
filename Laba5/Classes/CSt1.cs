using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5.Classes
{
    [Serializable]
    public class CSt<T>
    {
        public T data;
        public CSt<T> next;

        public CSt(CSt<T> s)
        {
            data = s.data;
            next = s.next;
        }

        public CSt(T _data)
        {
            data = _data;
            next = null;
        }

        public CSt<T> push(T _data)
        {
            CSt<T> d = new CSt<T>(_data);
            d.next = this;
            return d;
        }

        public T pop()
        {
            T L = data;
            if (next != null)
            {
                data = next.data;
                next = next.next;
            }
            if (next == null)
                data = default(T);
            return L;
        }
    }
}
