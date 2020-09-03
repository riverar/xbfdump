using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace xbfdump
{
    class Program
    {
        // Last tested against \Windows Kits\10\bin\10.0.19041.0\XamlCompiler\x64\genxbf.dll

        [DllImport("genxbf.dll", PreserveSig = true)]
        public static extern int Dump(IStream inputStream, IStream outputStream, int unused, out int xbfReaderResult);

        static void Main(string[] args)
        {
            using (var input = new XbfInputStream(args[0]))
            {
                using(var output = new XbfOutputStream(args[1]))
                {
                    Console.WriteLine($"hr={Dump(input, output, 0, out int xbfReaderResult)}, xrr={xbfReaderResult}"); 
                }
            }
        }
    }
}
