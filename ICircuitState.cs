using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitBreakDyamicLib
{
    public interface ICircuitState
    {
        void Guard();

        ICircuitState NextState();

        void Succeed();

        void Trip(Exception e);
    }
}
