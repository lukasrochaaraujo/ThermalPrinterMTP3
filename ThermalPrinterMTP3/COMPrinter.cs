using System.IO.Ports;
using System.Text;

using ThermalPrinterMTP3.Exceptions;

namespace ThermalPrinterMTP3
{
    public class COMPrinter
    {
        public const int COLUMN_LIMIT = 43;
        private string COMPort;
        private int BaundRate;
        private Parity Parity;
        private int DataBits;
        private StopBits StopBits;
        private SerialPort SerialPort;
        private StringBuilder StringBuffer;

        public COMPrinter(string portaCom)
        {
            COMPort = portaCom;
            BaundRate = 9600;
            Parity = Parity.None;
            DataBits = 8;
            StopBits = StopBits.One;
            SerialPort = new SerialPort(COMPort, BaundRate, Parity, DataBits, StopBits);
            SerialPort.Open();
            SerialPort.Encoding = Encoding.GetEncoding(852);
            StringBuffer = new StringBuilder();
        }

        public void AppendRowToBuffer(string text, bool breakLine = true)
        {
            if (text.Length > COLUMN_LIMIT)
                throw new OverflowColumnException($"The maximum column limit is {COLUMN_LIMIT}");

            StringBuffer.Append(text);

            if (breakLine) StringBuffer.Append("\r\n");
        }

        public void SendBufferToPrinter()
        {
            SerialPort.Write(StringBuffer.ToString());
            SerialPort.Close();
        }
    }
}
