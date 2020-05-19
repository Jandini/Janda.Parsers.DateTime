using System;

namespace Janda.Parsers
{
    internal class DateTimeParser
    {
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

        public DateTime AsCDateTime { get => _buffer.CDateToDateTime(_index); }
        public DateTime AsHFSFileTime { get => _buffer.HFSDateToDateTime(_index); }


        public DateTimeParser CDate(int offset, out DateTime result)
        {
            result = _buffer.CDateToDateTime(_index + offset);
            return this;
        }

        public DateTimeParser HFSDate(int offset, out DateTime result)
        {
            result = _buffer.HFSDateToDateTime(_index + offset);
            return this;
        }

        public DateTimeParser SwapCDate(int offset, out DateTime result)
        {
            result = _buffer.SwapCDateToDateTime(_index + offset);
            return this;
        }
    }
}
