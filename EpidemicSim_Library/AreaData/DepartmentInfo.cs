using System.Drawing;
using System.Linq;

namespace PSC2013.ES.Library.AreaData
{
    public class DepartmentInfo
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
    }
}