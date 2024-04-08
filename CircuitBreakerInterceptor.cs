using Castle.DynamicProxy;

namespace CircuitBreakDyamicLib
{
    public class CircuitBreakerInterceptor :
        Castle.DynamicProxy.IInterceptor
    {
        private readonly ICircuitBreaker breaker;

        public CircuitBreakerInterceptor(ICircuitBreaker breaker)
        {
            this.breaker = breaker;
        }

        public void Intercept(IInvocation invocation)
        {
            this.breaker.Guard();

            try
            {
                invocation.Proceed();

                this.breaker.Succeed();
            }
            catch (Exception ce)
            {
                this.breaker.Trip(ce);
                throw;
            }
        }
    }
}