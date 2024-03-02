using System.IO; // ������ ������������ ���� System.IO, ������� �������� ������ ��� ������ � �������� ������

namespace Libr
{
    public abstract class LastNBytesStreamDecorator : Stream // ����������� ������������ ������ LastNBytesStreamDecorator, ������������ ����� Stream
    {
        protected readonly Stream _stream; // ���������� ���� _stream ���� Stream, ������������ ��� �������� ����������� ������
        private readonly int _n; // ��������� ���� _n ���� int, ������������ ��� �������� �������� n (��������� N ����) 
        private byte[] _buffer; // ��������� ���� _buffer ���� byte[], ������������ ��� �������� ������
        private DateTime _lastReadTime; // ��������� ���� _lastReadTime ���� DateTime, ������������ ��� �������� ������� ���������� ������

        public override bool CanRead => throw new NotImplementedException(); // ���������� �������� CanRead

        public override bool CanSeek => throw new NotImplementedException(); // ���������� �������� CanSeek

        public override bool CanWrite => throw new NotImplementedException(); // ���������� �������� CanWrite

        public override long Length => throw new NotImplementedException(); // ���������� �������� Length

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } // ���������� �������� Position

        public LastNBytesStreamDecorator(Stream stream, int n) // ����������� ������ LastNBytesStreamDecorator
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream)); 
            _n = n;
            _buffer = new byte[_n]; // �������� ������ ������� ������ �������� _n � ������������ ��� ���� _buffer
        }

        public override int Read(byte[] buffer, int offset, int count) // ��������������� ������ Read, ������� ������ ������ �� ������ � ��������� �����
        {
            int bytesRead = _stream.Read(buffer, offset, count); // ������ ������ �� ����������� ������ � ���������� ���������� ����������� ������ � bytesRead
            if (bytesRead > 0) 
            {
                _lastReadTime = DateTime.Now; // ������������ �������� ������� ���� _lastReadTime
            }
            return bytesRead; 
        }


        public override long Seek(long offset, SeekOrigin origin) // ��������������� ������ Seek, ������� ������������� ������� ����������� ������
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value) // ��������������� ������ SetLength, ������� ������������� ����� ����������� ������
        {
            throw new NotImplementedException(); 
        }

        public override void Write(byte[] buffer, int offset, int count) // ��������������� ������ Write, ������� ���������� ������ � �����
        {
            throw new NotImplementedException(); 
        }

        public override void Flush() // ��������������� ������ Flush, ������� ���������� ������ �� ������ � �����
        {
            throw new NotImplementedException();
        }
    }

}
