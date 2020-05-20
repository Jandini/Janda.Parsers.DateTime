using System;
using Xunit;

namespace Janda.Parsers.Tests
{
    public class ByteArrayExtenstions_MustThrow
    {            
        [Fact]
        public void ReadAsBigEndianCDateToDateTime_WhenBufferIsEmpty_ThrowsIndexOutOfRangeException()
        {
            const int EMPTY_ARRAY_SIZE = 0;
            var buffer = new byte[EMPTY_ARRAY_SIZE];
            Assert.Throws<ArgumentOutOfRangeException>(()=>buffer.ReadAsBigEndianCDateToDateTime());
        }


        [Fact]
        public void ReadAsBigEndianCDateToDateTime_WhenBufferIsTooShort_ThrowsIndexOutOfRangeException()
        {
            const int C_DATE_SIZE = 4;
            var buffer = new byte[C_DATE_SIZE - 1];
            Assert.Throws<ArgumentOutOfRangeException>(() => buffer.ReadAsBigEndianCDateToDateTime());
        }


        [Fact]
        public void ReadAsBigEndianCDateToDateTime_WhenIndexIsNegative_ThrowsIndexOutOfRangeException()
        {
            const int C_DATE_SIZE = 4;
            const int NEGATIVE_INDEX = -1;
            var buffer = new byte[C_DATE_SIZE];
            Assert.Throws<ArgumentOutOfRangeException>(() => buffer.ReadAsBigEndianCDateToDateTime(NEGATIVE_INDEX));
        }


        [Fact]
        public void ReadAsBigEndianCDateToDateTime_WhenIndexIsOutsideOfRange_ThrowsIndexOutOfRangeException()
        {
            const int C_DATE_SIZE = 4;
            const int OUTSIDE_OF_RANGE_INDEX = C_DATE_SIZE + 1;
            var buffer = new byte[C_DATE_SIZE];
            Assert.Throws<ArgumentOutOfRangeException>(() => buffer.ReadAsBigEndianCDateToDateTime(OUTSIDE_OF_RANGE_INDEX));
        }
    }
}
