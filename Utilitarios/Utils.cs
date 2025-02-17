using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Utilitarios {
    internal class Utils {

        static NumberFormatInfo formatandoValores = new NumberFormatInfo();

        public static string doubleToString(double valor) {

            formatandoValores.CurrencySymbol = "R$";
            formatandoValores.CurrencyDecimalSeparator = ",";
            formatandoValores.CurrencyGroupSeparator = ".";

            return valor.ToString("C2", formatandoValores);
        }
        
    }
}
