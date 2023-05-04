namespace minimalApi_test.Components
{
    public interface IRequestsCounter
    {
        /// <summary>
        /// Metodo per incrementare il numero di richieste
        /// </summary>
        public void IncrementRequest();
        /// <summary>
        /// Metodo per ottenere il numero di richieste
        /// </summary>
        /// <returns>integer pari al numero di richieste</returns>
        public int GetActualCount();
    }
}
