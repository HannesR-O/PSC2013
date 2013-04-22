using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Converts a given base64 string to its int32 value
        /// </summary>
        /// <param name="base64">The string to parse</param>
        /// <returns>The resulting int32 value</returns>
        public static int GetIntFromBase64(string base64)
        {
            return BitConverter.ToInt32(Convert.FromBase64String(base64), 0);
        }

        /// <summary>
        /// Gets the base64 representation of the int32
        /// </summary>
        /// <param name="value">The int32 value to get represented in base64</param>
        /// <returns>The string representing the int32 value in base64</returns>
        public static string ToBase64(this int value)
        {
            return Convert.ToBase64String(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Converts a given base64 string to its int16 value
        /// </summary>
        /// <param name="base64">The string to parse</param>
        /// <returns>The resulting int16 value</returns>
        public static short GetShortFromBase64(string base64)
        {
            return BitConverter.ToInt16(Convert.FromBase64String(base64), 0);
        }

        /// <summary>
        /// Gets the base64 representation of the int16
        /// </summary>
        /// <param name="value">The int16 value to get represented in base64</param>
        /// <returns>The string representing the int16 value in base64</returns>
        public static string ToBase64(this short value)
        {
            return Convert.ToBase64String(BitConverter.GetBytes(value));
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
        /// <returns></returns>
        public static int[,] To2DIntArray(this PopulationData.PopulationCell[] array, int width)
        {
            int height = array.Length / width;
            return array.To2DIntArray(width, height);
        }
    }
}