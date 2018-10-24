using System;
using System.Collections.Generic;
using System.Text;

namespace Prax24._10
{
    class Isikukood
    {
        public string IsikukoodiNumber { get; }

        public Isikukood(string isikukoodiNumber)
        {
            IsikukoodiNumber = isikukoodiNumber.Trim();
        }

        public bool KontrolliIsikokoodi()
        {
            var isNumeric = long.TryParse(IsikukoodiNumber, out var a);
            if (!isNumeric || IsikukoodiNumber.Length != 11)
            {
                return false;
            }

            return true;
        }

        public string KysiSynnikuupaeva(DateTime dateTime)
        {
            return dateTime.ToString("yyMMdd");
        }
    }
}