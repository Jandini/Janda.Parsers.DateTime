using System;
using System.Buffers.Binary;
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
            return _hfsdateEpoch.AddSeconds(BinaryPrimitives.ReadUInt32LittleEndian(buffer.AsSpan().Slice(index)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ReadAsCDateToDateTime(this byte[] buffer, int index)
        {
            return _cdateEpoch.AddSeconds(BinaryPrimitives.ReadUInt32LittleEndian(buffer.AsSpan().Slice(index)));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ReadAsCDateToDateTime(this byte[] buffer)
        {
            return _cdateEpoch.AddSeconds(BinaryPrimitives.ReadUInt32LittleEndian(buffer));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ReadAsBigEndianCDateToDateTime(this byte[] buffer, int index)
        {
            return _cdateEpoch.AddSeconds(BinaryPrimitives.ReadUInt32BigEndian(buffer.AsSpan().Slice(index)));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ReadAsBigEndianCDateToDateTime(this byte[] buffer)
        {
            return _cdateEpoch.AddSeconds(BinaryPrimitives.ReadUInt32BigEndian(buffer));            
        }
    }
}
