using System;

namespace minimalApi_test.Components
{
    //classe che permette la gestione di eventuali errori,
    //inoltre qualora si presentassero errori, rende disponibile
    //una response alla API che ha generato l'errore stesso.
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

