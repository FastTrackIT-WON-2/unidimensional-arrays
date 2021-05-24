using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArrayUtilities.Tests
{
    public class ArrayHelperTests
    {
        [Fact]
        public void Min_When_ArrayIsNull_Expect_ReturnsIntMinValue()
        {
            // Arrange (prepare data for tests)
            int[] array = null;

            // Act (do the actual stuff)
            int min = ArrayHelper.Min(array);

            // Assert (verify that it worked as expected)
            Assert.Equal(int.MinValue, min);
        }

        [Fact]
        public void Min_When_ArrayIsEmpty_Expect_ReturnsIntMinValue()
        {
            // Arrange (prepare data for tests)
            int[] array = new int[0];

            // Act (do the actual stuff)
            int min = ArrayHelper.Min(array);

            // Assert (verify that it worked as expected)
            Assert.Equal(int.MinValue, min);
        }

        [Fact]
        public void Min_When_ArrayContainsASingleElement_Expect_ReturnsTheSingleElement()
        {
            // Arrange (prepare data for tests)
            int[] array = new int[] { 100 };

            // Act (do the actual stuff)
            int min = ArrayHelper.Min(array);

            // Assert (verify that it worked as expected)
            Assert.Equal(array[0], min);
        }

        [Fact]
        public void Min_When_ArrayContainsMultipleElements_Expect_ReturnsTheMinValue()
        {
            // Arrange (prepare data for tests)
            int[] array = new int[] { 100, 200, -500, 300, 0, 1, 2 };

            // Act (do the actual stuff)
            int min = ArrayHelper.Min(array);

            // Assert (verify that it worked as expected)
            Assert.Equal(-500, min);
        }

        [Fact]
        public void Max_When_ArrayIsNull_Expect_ReturnsIntMinValue()
        {
            // Arrange (prepare data for tests)
            int[] array = null;

            // Act (do the actual stuff)
            int max = ArrayHelper.Max(array);

            // Assert (verify that it worked as expected)
            Assert.Equal(int.MaxValue, max);
        }

        [Fact]
        public void Max_When_ArrayIsEmpty_Expect_ReturnsIntMinValue()
        {
            // Arrange (prepare data for tests)
            int[] array = new int[0];

            // Act (do the actual stuff)
            int max = ArrayHelper.Max(array);

            // Assert (verify that it worked as expected)
            Assert.Equal(int.MaxValue, max);
        }

        [Fact]
        public void Max_When_ArrayContainsASingleElement_Expect_ReturnsTheSingleElement()
        {
            // Arrange (prepare data for tests)
            int[] array = new int[] { 100 };

            // Act (do the actual stuff)
            int max = ArrayHelper.Max(array);

            // Assert (verify that it worked as expected)
            Assert.Equal(array[0], max);
        }

        [Fact]
        public void Max_When_ArrayContainsMultipleElements_Expect_ReturnsTheMinValue()
        {
            // Arrange (prepare data for tests)
            int[] array = new int[] { 100, 200, -500, 300, 0, 1, 2 };

            // Act (do the actual stuff)
            int max = ArrayHelper.Max(array);

            // Assert (verify that it worked as expected)
            Assert.Equal(300, max);
        }

    }
}
