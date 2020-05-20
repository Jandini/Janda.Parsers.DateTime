using System;
using System.Runtime.CompilerServices;

namespace Janda.Parsers
{
    public static class ByteArrayExtenstions
    {
        private static readonly DateTime _cdateEpoch = new DateTime(621355968000000000, DateTimeKind.Utc);
        private static readonly DateTime _hfsdateEpoch = new DateTime(600527520000000000, DateTimeKind.Utc);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ReadAsHFSDateAsDateTime(this byte[] buffer, int index)
        {
            return _hfsdateEpoch.AddSeconds((uint)((buffer[index++] << 24) | (buffer[index++] << 16) | (buffer[index++] << 8) | buffer[index++]));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ReadAsCDateToDateTime(this byte[] buffer, int index)
        {
            return _cdateEpoch.AddSeconds(BitConverter.ToUInt32(buffer, index));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ReadAsCDateToDateTime(this byte[] buffer)
        {
            return _cdateEpoch.AddSeconds(BitConverter.ToUInt32(buffer));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ReadAsBigEndianCDateToDateTime(this byte[] buffer, int index)
        {
            return _cdateEpoch.AddSeconds((uint)((buffer[index++] << 24) | (buffer[index++] << 16) | (buffer[index++] << 8) | buffer[index++]));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ReadAsBigEndianCDateToDateTime(this byte[] buffer)
        {
            return _cdateEpoch.AddSeconds((uint)((buffer[0] << 24) | (buffer[1] << 16) | (buffer[2] << 8) | buffer[3]));
        }
    }
}
