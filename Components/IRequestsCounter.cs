namespace minimalApi_test.Components
{
    public interface IRequestsCounter
    {
        public void IncrementRequest();
        public int GetActualCount();
    }
}
