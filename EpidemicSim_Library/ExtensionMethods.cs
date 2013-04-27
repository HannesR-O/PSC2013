using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static void Raise<T>(this EventHandler<T> eventHandler, Object sender, T e) where T : EventArgs
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
        /// Generates an 2-Dimensional array out
        /// of the given PopulationCells with only
        /// the sum of (living) humans in them.
        /// </summary>
        /// <param name="array">The array of PopulationCells to be converted.</param>
        /// <param name="width">The width of the matrix.</param>
        /// <param name="height">The height of the matrix.</param>
        /// <returns></returns>
        public static int[,] To2DIntArray(this PopulationData.PopulationCell[] array, int width, int height)
        {
            int[,] matrix = new int[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    matrix[x, y] = array[x + (y * width)].Humans.Count(p => !p.IsDead());
            return matrix;
        }

        /// <summary>
        /// Generates an 2-Dimensional array out
        /// of the given PopulationCells with only
        /// the sum of (living) humans in them.
        /// </summary>
        /// <param name="array">The array of PopulationCells to be converted.</param>
        /// <param name="width">The width of the matrix.</param>
        /// <returns>2D-Matrix of the PopulationCell-Array.</returns>
        public static int[,] To2DIntArray(this PopulationData.PopulationCell[] array, int width)
        {
            int height = array.Length / width;
            return array.To2DIntArray(width, height);
        }

        /// <summary>
        /// Flattens the coordinates of the given
        /// point onto a 1D-index.
        /// </summary>
        /// <param name="point">The point to be flattend.</param>
        /// <param name="width">The width of the environmental area.</param>
        /// <returns>The 1D-index corresponding to the point.</returns>
        public static int Flatten(this Point point, int width)
        {
            return point.X + (point.Y * width);
        }

        /// <summary>
        /// Calculates the absolute distance between
        /// the two points.
        /// Might be inexact because of int-cast.
        /// </summary>
        /// <param name="currentPoint">The current point.</param>
        /// <param name="origin">The other point.</param>
        /// <returns>The hypotenuse.</returns>
        public static int Distance(this Point currentPoint, Point origin)
        {
            int cathetus1 = Math.Abs(currentPoint.X - origin.X);
            int cathetus2 = Math.Abs(currentPoint.Y - origin.Y);

            return (int)Math.Sqrt(cathetus1 * cathetus1 + cathetus2 * cathetus2);
        }
    }
}