using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libr
{
    // Класс FileStreamDecorator
    public class FileStreamDecorator : LastNBytesStreamDecorator
    {
        public FileStreamDecorator(Stream stream, int n) : base(stream, n) { }
    }
}
