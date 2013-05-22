using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace PSC2013.ES.Library
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Extension method to simplify event raises
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventHandler">EventHandler of the event to raise</param>
        /// <param name="sender">Sender of the event to raise</param>
        /// <param name="e">EventArgs of the event to raise</param>
        internal static void Raise<T>(this EventHandler<T> eventHandler, Object sender, T e) where T : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }

        /// <summary>
        /// Initializes an array of the type T. Calls default constructor for each index
        /// </summary>
        /// <typeparam name="T">Type of the array to initialize</typeparam>
        /// <param name="array">The actual array</param>
        public static void Initialize<T>(this T[] array) where T : new()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new T();
            }
        }

        /// <summary>
        /// Simplifies the copying of one Array to another
        /// </summary>
        /// <param name="array">Source array</param>
        /// <param name="otherArray">Destination array</param>
        internal static void CopyToOtherArray(this Array array, Array otherArray)
        {
            array.CopyTo(otherArray, 0);
        }



        /// <summary>
        /// Flattens the coordinates of the given
        /// point onto a 1D-index.
        /// </summary>
        /// <param name="point">The point to be flattend.</param>
        /// <param name="width">The width of the environmental area.</param>
        /// <returns>The 1D-index corresponding to the point.</returns>
        internal static int Flatten(this Point point, int width)
        {
            return point.X + (point.Y * width);
        }

        /// <summary>
        /// DeFlattens a Position to a Point of an 2D Array
        /// </summary>
        /// <param name="position">The 1-Dimensional Position</param>
        /// <param name="width">The 2D Arrays width</param>
        /// <returns>a Point in the 2D Array</returns>
        internal static Point DeFlatten(this int position, int width)
        {
            return new Point(position % width, (int)position / width);
        }

        /// <summary>
        /// Calculates the absolute distance between
        /// the two points.
        /// Might be inexact because of int-cast.
        /// </summary>
        /// <param name="currentPoint">The current point.</param>
        /// <param name="origin">The other point.</param>
        /// <returns>The hypotenuse.</returns>
        internal static int Distance(this Point currentPoint, Point origin)
        {
            int cathetus1 = Math.Abs(currentPoint.X - origin.X);
            int cathetus2 = Math.Abs(currentPoint.Y - origin.Y);

            return (int)Math.Sqrt(cathetus1 * cathetus1 + cathetus2 * cathetus2);
        }

        /// <summary>
        /// Iterator over the non-null elements
        /// </summary>
        /// <param name="cells"></param>
        /// <returns></returns>
        internal static IEnumerable<T> NotNullIterator<T>(this T[] cells) where T : class
        {
            return cells.Where(item => item != null);
            // ?? // |t| Does this Comment belong HERE? Not where it's used?
            // 10 min with foreach
            // 12 min with parallel.foreach
        }

        /// <summary>
        /// Determines in which range the value is.
        /// Returns -1 if in none.
        /// </summary>
        /// <param name="x">The value itself.</param>
        /// <param name="rangeMaxValues">Array of the Max-Values of each range in an ascending order!</param>
        /// <param name="includingMax">Whether to include the Max-Value itself or not.</param>
        /// <returns>The index of the range (0-based).</returns>
        internal static int InRange(this int x, int[] rangeMaxValues, bool includingMax)
        {
            for (int i = 0; i < rangeMaxValues.Length; ++i)
                if (includingMax ? rangeMaxValues[i] >= x : rangeMaxValues[i] > x)
                    return i;
            return -1;
        }
    }
}