using System;
using System.Runtime.CompilerServices;

namespace Janda.Parsers
{
    public static class ByteArrayExtenstions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime AsHFSFileTime(this byte[] buffer, int index)
        {            
            return DateTimeParser.HFSDateTimeEpoch.AddSeconds((uint)((buffer[index++] << 24) | (buffer[index++] << 16) | (buffer[index++] << 8) | buffer[index++]));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime AsCDateTime(this byte[] buffer, int index)
        {
            return DateTimeParser.CDateTimeEpoch.AddSeconds(BitConverter.ToUInt32(buffer, index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime AsCDateTimeBE(this byte[] buffer, int index)
        {
            return DateTimeParser.CDateTimeEpoch.AddSeconds((uint)((buffer[index++] << 24) | (buffer[index++] << 16) | (buffer[index++] << 8) | buffer[index++]));
        }
    }      
}
 