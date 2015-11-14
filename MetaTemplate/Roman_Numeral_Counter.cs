#region Using directives

using System;

#endregion

namespace SobekCM.METS_Editor
{
    class Roman_Numeral_Counter
    {
        public static int Roman_To_Decimal(string Roman)
        {
            string romanCaps = Roman.ToUpper().Trim();
            switch (romanCaps)
            {
                case "I":
                    return 1;
                case "II":
                    return 2;
                case "III":
                    return 3;
                case "IIII":
                case "IV":
                    return 4;
                case "V":
                    return 5;
                case "VI":
                    return 6;
                case "VII":
                    return 7;
                case "VIII":
                    return 8;
                case "IX":
                    return 9;
                case "X":
                    return 10;
                default:
                    return -1;
            }
        }

        public static string Decimal_To_Roman(int Decimal, bool UpperCase)
        {
            if ((Decimal > 100) || ( Decimal < 1 ))
                return String.Empty;
            string units_roman = String.Empty;
            string tens_place = String.Empty;
            int units_place = (Decimal % 10) % 10;
            switch (units_place)
            {
                case 1:
                    units_roman = "i";
                    break;
                case 2:
                    units_roman = "ii";
                    break;
                case 3:
                    units_roman = "iii";
                    break;
                case 4:
                    units_roman = "iv";
                    break;
                case 5:
                    units_roman = "v";
                    break;
                case 6:
                    units_roman = "vi";
                    break;
                case 7:
                    units_roman = "vii";
                    break;
                case 8:
                    units_roman = "viii";
                    break;
                case 9:
                    units_roman = "ix";
                    break;
            }

            if (Decimal >= 10)
            {
                int remainder = (Decimal - units_place) / 10;
                switch (remainder)
                {
                    case 1:
                        tens_place = "x";
                        break;
                    case 2:
                        tens_place = "xx";
                        break;
                    case 3:
                        tens_place = "xxx";
                        break;
                    case 4:
                        tens_place = "xl";
                        break;
                    case 5:
                        tens_place = "l";
                        break;
                    case 6:
                        tens_place = "lx";
                        break;
                    case 7:
                        tens_place = "lxx";
                        break;
                    case 8:
                        tens_place = "lxxx";
                        break;
                    case 9:
                        tens_place = "xc";
                        break;
                    case 10:
                        tens_place = "c";
                        break;
                }
            }

            string result = tens_place + units_roman;
            if (UpperCase)
            {
                return result.ToUpper();
            }
            else
            {
                return result;
            }
        }
    }
}
