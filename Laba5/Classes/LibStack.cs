
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5.Classes
{
    class LibStack
    {
        public Library library;
        public LibStack next;

        public LibStack(Library lib)
        {
            library = lib;
            next = null;
        }

        public LibStack push(Library lib)
        {
            LibStack l = new LibStack(lib);
            l.next = this;
            return l;
        }

        public Library pop()
        {
            Library L = library;
            if (next != null)
            {
                library = next.library;
                next = next.next;
            }
            return L;
        }
    }
}
