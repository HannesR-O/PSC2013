using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PSC2013.ES.Tests
{
    public class ExampleTest
    {
        [Fact]
        public void ExampleTestMethod()
        {
            // Simple asserts
            Assert.Equal(4, 2 + 2);
            Assert.True(42 < 1337);

            // Testing wether a given Exception is thrown. The delegate just gets the Method to call.
            Assert.Throws(typeof(IndexOutOfRangeException), new Assert.ThrowsDelegate(MethodThatThrowsOutOfRange));

            // Testing wether no exception gets thrown. The delegate gets constructed through a delegate.
            Assert.DoesNotThrow(new Assert.ThrowsDelegate(() => MethodWithoutException()));
        }

        private void MethodThatThrowsOutOfRange()
        {
            int[] i = new int[2];
            int tmp = i[2];                   // Throws IndexOutOfRangeException
        }

        private void MethodWithoutException()
        {
            int[] i = new int[2];
            int tmp = i[1];                   // Does not throw IndexOutOfRangeException
        }
    }
}