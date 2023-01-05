using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    public struct ListDescription 
    {
        List<Description> list;

        public ListDescription(List<Description> l)
        {
            if (l == null)
            {
                throw new ArgumentNullException("Argument ne sme biti null.");
            }
            list = l;
        }

        public List<Description> List { get => list; set => list=value; }
    }
}
