using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Text;

namespace Janda.Parsers
{
    public static class ByteArrayExtenstions
    {
        private static readonly DateTime _cdateEpoch = new DateTime(621355968000000000, DateTimeKind.Utc);
        private static readonly DateTime _hfsdateEpoch = new DateTime(600527520000000000, DateTimeKind.Utc);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ReadAsHFSDateToDateTime(this byte[] buffer, int index)
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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime? ReadAsCStringAsIntAsCDateToDateTime(this byte[] buffer, int index, int count, Encoding encoding)
        {
            string text = null;

            for (int i = index, max = index + count; i < max; i++)
            {
                if (buffer[i] != 0) continue;

                text = encoding.GetString(
                    buffer,
                    index,
                    i - index);

                break;
            }

            return text != null && int.TryParse(text, out var value)
                ? (DateTime?)_cdateEpoch.AddSeconds(value)
                : null;
        }


    }
}
