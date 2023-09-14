using Flexibase;

namespace Test
{
    public class ReplacingbyDividersTest
    {
        [Fact]
        public void replace1()
        {
            //arrange
            var arg1 = new int[] { 3, 4 };
            var arg2 = new Dictionary<int, string>
            {
                [3] = "fizz",
                [5] = "buzz",
                [4] = "muzz",
                [7] = "guzz"
            };
            Dictionary<int[], string>? arg3 = null;

            var expected = "fizz-muzz";

            //actual
            var c = StringReplaces.ReplacingbyDividers(arg1, arg2, arg3);

            //assert
            Assert.Equal(expected, c);
        }
        [Fact]
        public void replace2()
        {
            //arrange
            var arg1 = new int[] { 7 };
            var arg2 = new Dictionary<int, string>
            {
                [3] = "fizz",
                [5] = "buzz",
                [4] = "muzz",
                [7] = "guzz"
            };
            Dictionary<int[], string>? arg3 = null;

            var expected = "guzz";

            //actual
            var c = StringReplaces.ReplacingbyDividers(arg1, arg2, arg3);

            //assert
            Assert.Equal(expected, c);
        }
        [Fact]
        public void replace3()
        {
            //arrange
            var arg1 = new int[] { 5, 4 };
            var arg2 = new Dictionary<int, string>
            {
                [3] = "fizz",
                [5] = "buzz",
                [4] = "muzz",
                [7] = "guzz"
            };
            Dictionary<int[], string>? arg3 = null;

            var expected = "buzz-muzz";

            //actual
            var c = StringReplaces.ReplacingbyDividers(arg1, arg2, arg3);

            //assert
            Assert.Equal(expected, c);
        }
        [Fact]
        public void replace4()
        {
            //arrange
            var arg1 = new int[] { 3,5,4,7 };
            var arg2 = new Dictionary<int, string>
            {
                [3] = "3333",
                [5] = "5555",
                [4] = "4444",
                [7] = "7777"
            };
            Dictionary<int[], string>? arg3 = null;

            var expected = "3333-5555-4444-7777";

            //actual
            var c = StringReplaces.ReplacingbyDividers(arg1, arg2, arg3);

            //assert
            Assert.Equal(expected, c);
        }
        [Fact]
        public void replace5()
        {
            //arrange
            var arg1 = new int[] { 3, 5, 4, 7 };
            var arg2 = new Dictionary<int, string>
            {
                [3] = "3333",
                [5] = "5555",
                [4] = "4444",
                [7] = "7777"
            };
            Dictionary<int[], string>? arg3 = new Dictionary<int[], string>
            {
                [new int[] {3,4}] = "9999",
                [new int[] {7}] = "0000"
            };

            var expected = "9999-5555-0000";

            //actual
            var c = StringReplaces.ReplacingbyDividers(arg1, arg2, arg3);

            //assert
            Assert.Equal(expected, c);
        }
        [Fact]
        public void replace6()
        {
            //arrange
            var arg1 = new int[] { 3, 5, 4, 7 };
            var arg2 = new Dictionary<int, string>
            {
                [3] = "3333",
                [5] = "5555",
                [4] = "4444",
                [7] = "7777"
            };
            Dictionary<int[], string>? arg3 = new Dictionary<int[], string>
            {
                [new int[] { 3 }] = "1234",
                [new int[] { 5 }] = "5678",
                [new int[] { 4,7 }] = "0000",
                [new int[] { 7 }] = "9999"

            };

            var expected = "1234-5678-0000";

            //actual
            var c = StringReplaces.ReplacingbyDividers(arg1, arg2, arg3);

            //assert
            Assert.Equal(expected, c);
        }
    }
}