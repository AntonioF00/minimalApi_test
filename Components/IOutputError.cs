using System;
namespace minimalApi_test.Components
{
	public interface IOutputError
	{
		public List<object> getError(string errorCode,string errorMessage);
	}
}

