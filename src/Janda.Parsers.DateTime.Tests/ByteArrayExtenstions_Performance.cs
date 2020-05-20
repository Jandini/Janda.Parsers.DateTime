using Xunit;

namespace Janda.Parsers.Tests
{
    public class ByteArrayExtenstions_Performance
    {
        [Fact]
        public void ReadAsBigEndianCDateToDateTime_BinaryPrimitives()
        {
            var buffer = new byte[4];
            
            for (int i = 0; i < 10000000; i++)
                buffer.ReadAsBigEndianCDateToDateTime(0);
        }
    }
}
