using System;
namespace minimalApi_test.Enum
{
	public class Enum
	{
        public enum Citys
        {
            Fano,
            Bellocchi,
            Calcinelli,
            Pesaro,
            Urbino,
            Ancona
        }

        public static T RandomEnumValue<T>()
        {
            Random _rnd = new Random();
            var v = Citys.GetValues(typeof(T));
            return (T)v.GetValue(_rnd.Next(v.Length));
        }
    }
}

