﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// The ages in this population.
        /// </summary>
        public int[] Ages { get; private set; }

        public DepartmentInfo()
        {
            Ages = new int[8];
        }

        /// <summary>
        /// Return the sum of all people in this department.
        /// </summary>
        public int GetTotal()
        {
            return Ages.Sum();
        }
    }
}