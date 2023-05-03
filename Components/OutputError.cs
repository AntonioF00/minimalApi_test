using System;

namespace minimalApi_test.Components
{
	public class OutputError : IOutputError
	{
        public OutputError() { }

        public List<object> getError(string a, string b)
        {
            return new List<object>(){ new Dictionary<string, object>() {

                  ["ErrorCode"] = a,
                  ["ErrorMessage"] = b

            } };
        }
    }
}

