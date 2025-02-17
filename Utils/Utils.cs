using System;
using System.Globalization;

namespace Utils
{
    public class Utils
    {
        
        static void Main(string[] args)
        {
            NumberFormatInfo formatandoValores = new NumberFormatInfo();
        }

        public static string doubleToString(double valor)
        {
            NumberFormatInfo formatandoValores = new NumberFormatInfo();
            formatandoValores.CurrencySymbol = "R$";
            formatandoValores.CurrencyDecimalSeparator = ",";
            formatandoValores.CurrencyGroupSeparator = ".";

            return valor.ToString("C2", formatandoValores);
        }
    }
}

