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
            Random r = new Random();
            var array = new int[10];

            for (int i = 0; i < array.Length; i++)
                array[i] = r.Next();

            var array2 = new int[10];

            foreach (var integer in array2)
                Assert.Equal(0, integer);

            array.CopyToOtherArray(array2);           //TODO: does not recognize ExtensionMethods whatsoever dunno why =(

            for (int i = 0; i < array.Length; i++)
                Assert.Equal(array[i], array2[i]);      //Will obviously fail right now since the method does not get called =(
        }
    }
}