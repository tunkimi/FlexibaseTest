using Flexibase;

namespace Test
{
    public class CollectReplacesTest
    {
        [Fact]
        public void test1()
        {
            //arrange
            var arg1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var arg2 = new Dictionary<int, string>
            {
                [3] = "fizz",
                [5] = "buzz"
            };
            Dictionary<int[], string>? arg3 = null;

            var expected = new List<object>() { 1, 2, "fizz", 4, "buzz", "fizz", 7, 8, "fizz", "buzz", 11, "fizz", 13, 14, "fizz-buzz" };

            //actual
            var c = StringReplaces.CollectReplaces(arg1, arg2, arg3);

            //assert
            Assert.Equal(expected, c);
        }
        [Fact]
        public void test2()
        {
            //arrange
            var arg1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
            var arg2 = new Dictionary<int, string>
            {
                [3] = "fizz",
                [5] = "buzz",
                [4] = "muzz",
                [7] = "guzz"
            };
            Dictionary<int[], string>? arg3 = null;

            var expected = new List<object>() { 1, 2, "fizz", "muzz", "buzz", "fizz", "guzz", "muzz", "fizz", "buzz", 11, "fizz-muzz", 13, "guzz", "fizz-buzz", "fizz-buzz-muzz", "fizz-buzz-guzz", "fizz-buzz-muzz-guzz" };

            //actual
            var c = StringReplaces.CollectReplaces(arg1, arg2, arg3);

            //assert
            Assert.Equal(expected, c);
        }
        [Fact]
        public void test3()
        {
            //arrange
            var arg1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
            var arg2 = new Dictionary<int, string>
            {
                [3] = "fizz",
                [5] = "buzz",
                [4] = "muzz",
                [7] = "guzz"
            };
            Dictionary<int[], string>? arg3 = new Dictionary<int[], string>
            {
                [new int[] { 3, 5 }] = "good-boy",
                [new int[] { 3 }] = "dog",
                [new int[] { 5 }] = "cat"
            };

            var expected = new List<object>() { 1, 2, "dog", "muzz", "cat", "dog", "guzz", "muzz", "dog", "cat", 11, "fizz-muzz", 13, "guzz", "good-boy", "good-boy-muzz", "good-boy-guzz", "good-boy-muzz-guzz" };

            //actual
            var c = StringReplaces.CollectReplaces(arg1, arg2, arg3);

            //assert
            Assert.Equal(expected, c);
        }
        [Fact]
        public void test4()
        {
            //arrange
            var arg1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
            var arg2 = new Dictionary<int, string>
            {
                [3] = "fizz",
                [5] = "buzz",
                [4] = "muzz",
                [7] = "guzz"
            };
            Dictionary<int[], string>? arg3 = new Dictionary<int[], string>
            {
                [new int[] { 3, 5 }] = "good-boy",
                [new int[] { 3 }] = "dog",
                [new int[] { 5 }] = "cat"
            };

            var expected = new List<object>() { 1, 2, "dog", "muzz", "cat", "dog", "guzz", "muzz", "dog", "cat", 11, "dog-muzz", 13, "guzz", "good-boy", "good-boy-muzz", "good-boy-guzz", "good-boy-muzz-guzz" };

            //actual
            var c = StringReplaces.CollectReplaces(arg1, arg2, arg3);

            //assert
            Assert.Equal(expected, c);
        }
    }
}
