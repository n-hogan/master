using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hogan.Utilities.Pdf;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            

            using (var bytes = PdfRenderer.RenderHtmlToPdfStream("<html><p>Test</p></html>"))
            {
                new FileStream(@"D:\file.pdf", FileMode.Create).Write(bytes.ToArray(), 0, (int) bytes.Length);
            }


        }
    }
}
