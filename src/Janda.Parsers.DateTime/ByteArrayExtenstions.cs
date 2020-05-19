using System;
using System.Runtime.CompilerServices;

namespace Janda.Parsers
{
    public static class ByteArrayExtenstions
    {
        private static readonly DateTime _cdateEpoch = new DateTime(621355968000000000, DateTimeKind.Utc);
        private static readonly DateTime _hfsdateEpoch = new DateTime(600527520000000000, DateTimeKind.Utc);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime HFSDateToDateTime(this byte[] buffer, int index)
        {
            // Janda.Parsers.Exceptions
            // buffer.Require<DateTimeDataParserException>(index, 4);
            
            return _hfsdateEpoch.AddSeconds((uint)((buffer[index++] << 24) | (buffer[index++] << 16) | (buffer[index++] << 8) | buffer[index++]));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime CDateToDateTime(this byte[] buffer, int index)
        {
            return _cdateEpoch.AddSeconds(BitConverter.ToUInt32(buffer, index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime SwapCDateToDateTime(this byte[] buffer, int index)
        {
            return _cdateEpoch.AddSeconds((uint)((buffer[index++] << 24) | (buffer[index++] << 16) | (buffer[index++] << 8) | buffer[index++]));
        }
    }      
}
 