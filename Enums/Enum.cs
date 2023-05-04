using System;
namespace minimalApi_test.Enums
{
	public class Enum
	{
        //enumeratore contenente un set di città
        public enum Citys
        {
            Fano,
            Bellocchi,
            Calcinelli,
            Pesaro,
            Urbino,
            Ancona
        }

        /// <summary>
        /// Metodo per ottenere in modo randomico una città
        /// dall'enumeratore della classe
        /// </summary>
        /// <typeparam name="T">parametro generico T</typeparam>
        /// <returns>indice dell'enumeratore a cui fa riferimento la città scelta in modo
        /// generico</returns>
        public static T RandomEnumValue<T>()
        {
            Random _rnd = new Random();
            var v = Citys.GetValues(typeof(T));
            return (T)v.GetValue(_rnd.Next(v.Length));
        }
    }
}

