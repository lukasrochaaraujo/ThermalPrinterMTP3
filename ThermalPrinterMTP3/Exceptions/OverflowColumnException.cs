using System;

namespace ThermalPrinterMTP3.Exceptions
{
    public class OverflowColumnException : Exception
    {
        public OverflowColumnException(string message) : base(message) { }
    }
}
