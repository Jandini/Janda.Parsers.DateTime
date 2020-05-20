using System;
using System.Buffers.Binary;
using Xunit;

namespace Janda.Parsers.Tests
{
    public class ByteArrayExtenstions_MustReturn
    {
        [Fact]
        public void ReadAsHFSDateToDateTime_AtIndexZero_ReturnsEpoch()
        {
            const int HFS_DATE_SIZE = 4;
            const int INDEX_ZERO = 0;
            var HFS_DATE_EPOCH = new DateTime(1904, 1, 1);

            var buffer = new byte[HFS_DATE_SIZE];

            Assert.Equal(buffer.ReadAsHFSDateAsDateTime(INDEX_ZERO), HFS_DATE_EPOCH);
        }

        [Fact]
        public void ReadAsCDateToDateTimeReturnsEpoch()
        {
            const int C_DATE_SIZE = 4;
            var C_DATE_EPOCH = new DateTime(1970, 1, 1);

            var buffer = new byte[C_DATE_SIZE];

            Assert.Equal(buffer.ReadAsCDateToDateTime(), C_DATE_EPOCH);
        }


        [Fact]
        public void ReadAsCDateToDateTime_AtIndexZero_ReturnsEpoch()
        {
            const int INDEX_ZERO = 0;
            const int C_DATE_SIZE = 4;
            var C_DATE_EPOCH = new DateTime(1970, 1, 1);

            var buffer = new byte[C_DATE_SIZE];

            Assert.Equal(buffer.ReadAsCDateToDateTime(INDEX_ZERO), C_DATE_EPOCH);
        }

        [Fact]
        public void ReadAsBigEndianCDateToDateTime_AtIndexZero_ReturnsEpoch()
        {
            const int INDEX_ZERO = 0;
            const int C_DATE_SIZE = 4;
            var C_DATE_EPOCH = new DateTime(1970, 1, 1);

            var buffer = new byte[C_DATE_SIZE];

            Assert.Equal(buffer.ReadAsBigEndianCDateToDateTime(INDEX_ZERO), C_DATE_EPOCH);
        }


        [Fact]
        public void ReadAsBigEndianCDateToDateTimeReturnsEpoch()
        {
            const int C_DATE_SIZE = 4;
            var C_DATE_EPOCH = new DateTime(1970, 1, 1);

            var buffer = new byte[C_DATE_SIZE];

            Assert.Equal(buffer.ReadAsBigEndianCDateToDateTime(), C_DATE_EPOCH);
        }


        [Fact]
        public void ReadAsBigEndianCDateToDateTime_AtIndexZero_ReturnsExpectedDate()
        {
            const int FIRST_SECOND = 1;
            const int INDEX = 0;
            const int C_DATE_SIZE = 4;
            var FIRST_SECOND_AS_BIG_ENDIAN = new DateTime(1970, 07, 14, 4, 20, 16);

            var buffer = new byte[C_DATE_SIZE];

            BinaryPrimitives.WriteInt32LittleEndian(buffer, FIRST_SECOND);

            Assert.Equal(buffer.ReadAsBigEndianCDateToDateTime(INDEX), FIRST_SECOND_AS_BIG_ENDIAN);
        }


        [Fact]
        public void ReadAsBigEndianCDateToDateTimeReturnsExpectedDate()
        {
            DateTime EXPECTED_DATE_TIME = new DateTime(1980, 08, 21, 19, 45, 00);
            byte[] C_DATE_BUFFER = { 0x14, 0x02, 0xE9, 0x3C };

            Assert.Equal(C_DATE_BUFFER.ReadAsBigEndianCDateToDateTime(), EXPECTED_DATE_TIME);
        }

        [Fact]
        public void ReadAsCDateToDateTimeReturnsExpectedDate()
        {
            DateTime EXPECTED_DATE_TIME = new DateTime(2002, 05, 20, 14, 03, 00);
            byte[] C_DATE_BUFFER = { 0x14, 0x02, 0xE9, 0x3C };

            Assert.Equal(C_DATE_BUFFER.ReadAsCDateToDateTime(), EXPECTED_DATE_TIME);
        }
    }
}
