namespace minimalApi_test.Components
{
    public class RequestsCounter : IRequestsCounter
    {
        private int _numOfRequests;

        public RequestsCounter()
        {
            _numOfRequests = 0;
        }

        public int GetActualCount()
        {
            return _numOfRequests;
        }

        public void IncrementRequest()
        {
            _numOfRequests += 1;
        }
    }
}
