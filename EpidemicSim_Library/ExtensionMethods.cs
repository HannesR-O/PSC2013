﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO.Compression;
using System.IO;

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
        /// Simplifies the copying of one Array to another
        /// </summary>
        /// <param name="array">Source array</param>
        /// <param name="otherArray">Destination array</param>
        public static void CopyToOtherArray(this Array array, Array otherArray)
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
        public static int Flatten(this Point point, int width)
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
        }

        /// <summary>
        /// Determines in which range the value is.
        /// Returns -1 if in none.
        /// </summary>
        /// <param name="x">The value itself.</param>
        /// <param name="rangeMaxValues">Array of the Max-Values of each range in an ascending order!</param>
        /// <param name="includingMax">Whether to include the Max-Value itself or not.</param>
        /// <returns>The index of the range (0-based).</returns>
        public static int InRange(this int x, int[] rangeMaxValues, bool includingMax)
        {
            for (int i = 0; i < rangeMaxValues.Length; ++i)
                if (includingMax ? rangeMaxValues[i] >= x : rangeMaxValues[i] > x)
                    return i;
            return -1;
        }

        /// <summary>
        /// Creates a deep copy of the given Dictionary only containing structs as keys AND values.
        /// </summary>
        /// <typeparam name="T1">Key's type</typeparam>
        /// <typeparam name="T2">Value's type</typeparam>
        /// <param name="dict">Dictionary to create a deep copy of</param>
        /// <returns>The deep copy of the Dictionary</returns>
        public static Dictionary<T1, T2> DeepCopy<T1, T2>(this Dictionary<T1, T2> dict) 
            where T1 : struct 
            where T2 : struct
        {
            var copy = new Dictionary<T1, T2>();

            foreach (var pair in dict)
            {
                copy.Add(pair.Key, pair.Value);
            }

            return copy;
        }

        /// <summary>
        /// Clears a ZipArchive through deleting all its entries.
        /// </summary>
        /// <param name="archive">The ZipArchive to clear</param>
        public static void ClearArchive(this ZipArchive archive)
        {
            if (archive.Mode != ZipArchiveMode.Update)
                throw new IOException("In order to clear a ZipArchive its mode must be set to ZipArchiveMode.Update!");

            for (int i = 0; i < archive.Entries.Count; i++)
            {
                var entry = archive.Entries[i];
                /* It seems this is needed as pointed out here: 
                 *  http://social.msdn.microsoft.com/Forums/en-US/winappswithcsharp/thread/bc055e3f-0b3e-4ef2-961b-27ecc99555bd/ */
                if (entry != null)
                    entry.Delete();
            }
        }

        /// <summary>
        /// Converts a Zipentry to a Stream
        /// </summary>
        /// <param name="entry">The ArchiveEntry</param>
        /// <returns>A byte[] with its contents</returns>
        public static byte[] ToByteArray(this ZipArchiveEntry entry)
        {
            using (Stream stream = entry.Open())
            {
                var memStream = new MemoryStream();
                stream.CopyTo(memStream);
                return memStream.ToArray();
            }
        }
    }
}