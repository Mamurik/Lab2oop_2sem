using System.IO;
using System.Windows.Controls;
using Libr;

namespace Tests
{
    [TestClass]
    public class LastNBytesStreamDecoratorTests
    {

        [TestMethod]
        [DataRow("D:\\Labs\\4sem\\ÎÎÏèÏ\\2\\lab2.txt",5)]
        public void CheckFileStreamDecorator(string filePath, int n)
        {
            using (var _fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var _decoratorFileStream = new FileStreamDecorator(_fileStream, n);
                byte[] buffer = { 118, 119, 120, 121, 122 };

                int bytesRead = _decoratorFileStream.Read(buffer, 0, buffer.Length);
                byte[] lastNBytes = _decoratorFileStream.GetLastNBytes();
                CollectionAssert.AreEqual(buffer, lastNBytes);
            }
        }

        [TestMethod]
        [DataRow("D:\\Labs\\4sem\\ÎÎÏèÏ\\2\\lab2.txt", 5)]
        public void CheckMemoryStreamDecorator(string filePath, int n)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    fileStream.CopyTo(memoryStream);
                }
                memoryStream.Seek(0, SeekOrigin.Begin);
                var _decoratorMemoryStream = new MemoryStreamDecorator(memoryStream, n);
                byte[] buffer = { 118, 119, 120, 121, 122 };

                int bytesRead = _decoratorMemoryStream.Read(buffer, 0, buffer.Length);
                byte[] lastNBytes = _decoratorMemoryStream.GetLastNBytes();

                CollectionAssert.AreEqual(buffer, lastNBytes);
            }
        }

        [TestMethod]
        [DataRow("D:\\Labs\\4sem\\ÎÎÏèÏ\\2\\lab2.txt", 5)]
        public void CheckBufferedStreamDecorator(string filePath, int n)
        {
            using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (var bufferStream = new BufferedStream(fileStream))
                {
                    var _decoratorBufferedStream = new BufferedStreamDecorator(bufferStream, n);
                    byte[] buffer = { 118, 119, 120, 121, 122 };

                    int bytesRead = _decoratorBufferedStream.Read(buffer, 0, buffer.Length);
                    byte[] lastNBytes = _decoratorBufferedStream.GetLastNBytes();

                    CollectionAssert.AreEqual(buffer, lastNBytes);
                }
            }
        }
    }
}