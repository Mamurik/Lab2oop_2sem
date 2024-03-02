using System.IO; // Импорт пространства имен System.IO, которое содержит классы для работы с потоками данных

namespace Libr
{
    public abstract class LastNBytesStreamDecorator : Stream // Определение абстрактного класса LastNBytesStreamDecorator, расширяющего класс Stream
    {
        protected readonly Stream _stream; // Защищенное поле _stream типа Stream, используется для хранения внутреннего потока
        private readonly int _n; // Приватное поле _n типа int, используется для хранения значения n (последние N байт) 
        private byte[] _buffer; // Приватное поле _buffer типа byte[], используется для хранения буфера
        private DateTime _lastReadTime; // Приватное поле _lastReadTime типа DateTime, используется для хранения времени последнего чтения

        public override bool CanRead => throw new NotImplementedException(); // Реализация свойства CanRead

        public override bool CanSeek => throw new NotImplementedException(); // Реализация свойства CanSeek

        public override bool CanWrite => throw new NotImplementedException(); // Реализация свойства CanWrite

        public override long Length => throw new NotImplementedException(); // Реализация свойства Length

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } // Реализация свойства Position

        public LastNBytesStreamDecorator(Stream stream, int n) // Конструктор класса LastNBytesStreamDecorator
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream)); 
            _n = n;
            _buffer = new byte[_n]; // Создание нового массива байтов размером _n и присваивание его полю _buffer
        }

        public override int Read(byte[] buffer, int offset, int count) // Переопределение метода Read, который читает данные из потока в указанный буфер
        {
            int bytesRead = _stream.Read(buffer, offset, count); // Чтение данных из внутреннего потока и сохранение количества прочитанных байтов в bytesRead
            if (bytesRead > 0) 
            {
                _lastReadTime = DateTime.Now; // Присваивание текущего времени полю _lastReadTime
            }
            return bytesRead; 
        }


        public override long Seek(long offset, SeekOrigin origin) // Переопределение метода Seek, который устанавливает позицию внутреннего потока
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value) // Переопределение метода SetLength, который устанавливает длину внутреннего потока
        {
            throw new NotImplementedException(); 
        }

        public override void Write(byte[] buffer, int offset, int count) // Переопределение метода Write, который записывает данные в поток
        {
            throw new NotImplementedException(); 
        }

        public override void Flush() // Переопределение метода Flush, который сбрасывает данные из буфера в поток
        {
            throw new NotImplementedException();
        }
    }

}
