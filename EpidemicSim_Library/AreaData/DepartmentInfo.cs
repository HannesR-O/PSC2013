using System;
using System.Drawing;
using System.Linq;

namespace PSC2013.ES.Library.AreaData
{
    public class DepartmentInfo : IFormattable
    {
        /// <summary>
        /// The name of the department.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Array of all points being a
        /// geographical part of this department.
        /// </summary>
        public Point[] Coordinates { get; set; }

        /// <summary>
        /// The poulation of this Department.
        /// [0-3] Males, [4-7] Females
        /// </summary>
        public int[] Population { get; private set; }

        public DepartmentInfo()
        {
            Population = new int[8];
        }

        /// <summary>
        /// Return the sum of all people in this department.
        /// </summary>
        public int GetTotal()
        {
            return Population.Sum();
        }

        public string ToString(string format)
        {
            return ToString(format, System.Globalization.CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
                format = "N";
            if (formatProvider == null)
                formatProvider = System.Globalization.CultureInfo.CurrentCulture;

            string result = "";

            foreach (char c in format)
            {
                switch (c)
                {
                    case 'N':
                        result += Name;
                        break;
                    case 'T':
                        result += GetTotal().ToString(formatProvider);
                        break;
                    case 'A':
                        result += Coordinates.Count().ToString(formatProvider);
                        break;
                    default:
                        result += c;
                        break;
                }
            }

            return result;
        }
    }
}