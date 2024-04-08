using KingAOP;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CircuitBreakDyamicLib
{
    public class WcfProductRepository : IRepository,IDynamicMetaObjectProvider
    {
        public WcfProductRepository() 
        {

        }

        [CountTransaction]
        public int Count()
        {
            return 10;
        }

        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new AspectWeaver(parameter, this);
        }
    }
}
