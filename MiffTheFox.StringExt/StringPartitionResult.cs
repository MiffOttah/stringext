using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiffTheFox
{
    public struct StringPartitionResult
    {
        public string Head;
        public string Tail;

        public void Deconstruct(out string head, out string tail)
        {
            head = Head;
            tail = Tail;
        }

        public override string ToString()
        {
            return $"({Head}, {Tail})";
        }

        public override bool Equals(object obj)
        {
            if (obj is StringPartitionResult that)
            {
                return this.Head == that.Head && this.Tail == that.Tail;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + ((Head is null) ? 0 : Head.GetHashCode());
                hash = hash * 23 + ((Tail is null) ? 0 : Tail.GetHashCode());
                return hash;
            }
        }
    }
}
