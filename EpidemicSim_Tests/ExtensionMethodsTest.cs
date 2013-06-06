using PSC2013.ES.Library;
using System;
using System.Collections.Generic;
using Xunit;

namespace PSC2013.ES.Tests
{
    public class ExtensionMethodsTest
    {
        [Fact]
        public void InitializeTest()
        {
            var array = new List<object>[5];

            foreach (var value in array)
                Assert.Null(value);

            array.Initialize<List<object>>();

            foreach (var value in array)
                Assert.NotNull(value);
        }

        [Fact]
        public void CopyToOtherArrayTest()
        {
            var array = new int[10];

            for (int i = 0; i < array.Length; i++)
                array[i] = RANDOM.Next();

            var array2 = new int[10];

            foreach (var integer in array2)
                Assert.Equal(0, integer);

            array.CopyToOtherArray(array2);

            for (int i = 0; i < array.Length; i++)
                Assert.Equal(array[i], array2[i]);
        }

        [Fact]
        public void DeepCopyTest()
        {
            var dict_int = new Dictionary<int, int>();

            for (int i = 0; i < 25; i++)
            {
                dict_int.Add(RANDOM.Next(), RANDOM.Next());
            }

            var copy_int = dict_int.DeepCopy<int, int>();

            foreach (var pair in dict_int)
            {
                Assert.Contains<KeyValuePair<int, int>>(pair, copy_int);
            }

            var dict_float = new Dictionary<float, float>();

            for (int i = 0; i < 25; i++)
            {
                dict_float.Add(RANDOM.Next(), RANDOM.Next());
            }

            var copy_float = dict_float.DeepCopy<float, float>();

            foreach (var pair in dict_float)
            {
                Assert.Contains<KeyValuePair<float, float>>(pair, copy_float);
            }
        }
    }
}