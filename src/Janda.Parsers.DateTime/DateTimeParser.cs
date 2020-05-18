using System;

namespace Janda.Parsers
{
    public class DateTimeParser
    {
        public static DateTime CDateTimeEpoch = new DateTime(621355968000000000, DateTimeKind.Utc);
        public static DateTime HFSDateTimeEpoch = new DateTime(600527520000000000, DateTimeKind.Utc);

        private readonly byte[] _buffer;
        private readonly int _index;

        public DateTimeParser(byte[] buffer, int index)
        {
            _buffer = buffer;
            _index = index;
        }

        public DateTimeParser(byte[] buffer)
        {
            _buffer = buffer;
            _index = 0;
        }

        public DateTime AsCDateTime { get => _buffer.AsCDateTime(_index); }
        public DateTime AsHFSFileTime { get => _buffer.AsHFSFileTime(_index); }

        public DateTimeParser FromCDateTime(int offset, out DateTime result)
        {
            result = _buffer.AsCDateTime(_index + offset);
            return this;
        }

        public DateTimeParser FromAsHFSFileTime(int offset, out DateTime result)
        {
            result = _buffer.AsHFSFileTime(_index + offset);
            return this;
        }

        public DateTimeParser FromCDateTimeBigEndian(int offset, out DateTime result)
        {
            result = _buffer.AsCDateTimeBE(_index + offset);
            return this;
        }
    }
}
