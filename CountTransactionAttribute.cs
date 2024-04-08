using Castle.Components.DictionaryAdapter.Xml;
using KingAOP.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitBreakDyamicLib
{
    public class CountTransactionAttribute : KingAOP.Aspects.OnMethodBoundaryAspect
    {
        string state = "0";
        public override void OnEntry(MethodExecutionArgs args)
        {
            this.state = "1";
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            this.state = "2";
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            this.state = "3";
        }

    }
}
