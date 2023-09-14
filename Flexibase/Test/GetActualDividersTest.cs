using Flexibase;

namespace Test
{
    public class GetActualDividersTest
    {
        [Fact]
        public void getDivs1()
        {
            //arrange
            int a1 = 21;
            var b1 = new int[] { 3, 7, 8 };
            var expected1 = new int[] { 3, 7 };

            //actual
            var c1 = StringReplaces.GetActualDividers(a1, b1).divs;

            //assert
            Assert.Equal(expected1, c1);
        }
        [Fact]
        public void getDivs2()
        {
            //arrange
            int a2 = 12;
            var b2 = new int[] { 3, 7, 8, 6, 4 };
            var expected2 = new int[] { 3, 6, 4 };

            //actual
            var c2 = StringReplaces.GetActualDividers(a2, b2).divs;

            //assert
            Assert.Equal(expected2, c2);
        }
    }
}