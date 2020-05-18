using System.Runtime.CompilerServices;

namespace Janda.Parsers
{
    public static class ByteArrayParserExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeParser ParseAt(this byte[] buffer, int index)
        {
            return new DateTimeParser(buffer, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeParser Parse(this byte[] buffer)
        {
            return new DateTimeParser(buffer);
        }
    }
}
 