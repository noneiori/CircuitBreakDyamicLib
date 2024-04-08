using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitBreakDyamicLib
{
    public class CircuitBreaker : ICircuitBreaker
    {
        private ICircuitState state;

        public CircuitBreaker(TimeSpan timeout)
        {
            this.state = new ClosedCircuitState(timeout);
        }

        public ICircuitState State
        {
            get { return this.state; }
        }

        #region ICircuitBreaker Members

        public void Guard()
        {
            this.state = this.state.NextState();
            this.state.Guard();
            Console.WriteLine("Guard");
            this.state = this.state.NextState();
        }

        public void Trip(Exception e)
        {
            this.state = this.state.NextState();
            this.state.Trip(e);
            Console.WriteLine("Trip");
            this.state = this.state.NextState();
        }

        public void Succeed()
        {
            this.state = this.state.NextState();
            this.state.Succeed();
            Console.WriteLine("Succeed");
            this.state = this.state.NextState();
        }

        #endregion
    }
}
