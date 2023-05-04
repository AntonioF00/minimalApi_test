using System;
namespace minimalApi_test.Components
{
	public interface IOutputError
	{
		/// <summary>
		/// Metodo per ottenere gli errori sulla base dei valori in ingresso
		/// </summary>
		/// <param name="errorCode">Codice errore</param>
		/// <param name="errorMessage">Messaggio interpretabile dall'utente</param>
		/// <returns>List<object></returns>
		public List<object> getError(string errorCode,string errorMessage);
	}
}

