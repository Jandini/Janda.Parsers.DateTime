using System;
using Xunit;

namespace Janda.Parsers.Tests
{
    public class ByteArrayExtenstions_Must
    {
        [Fact]
        public void AsHFSFileTime_ReturnEpoch()
        {
            var buffer = new byte[4];
            Assert.Equal(buffer.AsHFSFileTime(0), new DateTime(1904, 1, 1));
        }

        [Fact]
        public void AsCDateTime_ReturnEpoch()
        {
            var buffer = new byte[4];
            Assert.Equal(buffer.AsCDateTime(0), new DateTime(1970, 1, 1));
        }

        [Fact]
        public void AsCDateTimeBE_ReturnEpoch()
        {
            var buffer = new byte[4];
            Assert.Equal(buffer.AsCDateTime(0), new DateTime(1970, 1, 1));
        }
    }
}
