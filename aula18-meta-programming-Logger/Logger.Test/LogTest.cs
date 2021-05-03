using System;
using Xunit;
using Logger;
using System.Text;

namespace Logger.Test
{
    public class LogTest
    {
        class BufferPrinter : IPrinter
        {
            public readonly StringBuilder buffer = new StringBuilder();
            public void Print(string output)
            {
                buffer.Append(output);
            }
        }

        [Fact]
        public void TestLogPoint()
        {
            Point p = new Point(7, 9);
            BufferPrinter printer = new BufferPrinter();
            Log log = new Log(printer);
            log.Info(p);
            Assert.Equal(
                "Point{GetModule:11,4017542509914, x:7}", 
                printer.buffer.ToString());
        }
    }
}
