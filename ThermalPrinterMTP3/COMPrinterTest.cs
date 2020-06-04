namespace ThermalPrinterMTP3
{
    public static class COMPrinterTest
    {
        public static void Print()
        {
            var mtp3 = new COMPrinter("COM9");
            mtp3.AppendRowToBuffer("\r\n");
            mtp3.AppendRowToBuffer("THERMAL RECEIPT PRINTER");
            mtp3.AppendRowToBuffer("- Model: MTP-3");
            mtp3.AppendRowToBuffer("- Print Width: 80mm");
            mtp3.AppendRowToBuffer("- Print Speed: 90mm/s");
            mtp3.AppendRowToBuffer("\r\n\r\n\r\n");
            mtp3.SendBufferToPrinter();
        }
    }
}
