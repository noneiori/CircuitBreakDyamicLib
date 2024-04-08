namespace CircuitBreakDyamicLib
{
    public interface ICircuitBreaker
    {
        void Guard();
        void Succeed();
        void Trip(Exception ce);
    }
}