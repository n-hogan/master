using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace Hogan.Utilities.Pdf
{
    public sealed class PdfRenderer
    {
        public static MemoryStream RenderHtmlToPdfStream(string html)
        {
            var memoryStream = new MemoryStream();

            var reader = new StringReader(html);

            using (var document = new Document(PageSize.A4, 30, 30, 30, 30))
            {
                using (var worker = new HTMLWorker(document))
                {
                    using (var writer = PdfWriter.GetInstance(document, memoryStream))
                    {
                        writer.CloseStream = false;

                        document.Open();
                        worker.StartDocument();

                        worker.Parse(reader);

                        worker.EndDocument();
                        worker.Close();
                        document.Close();
                    }
                }
            }
            memoryStream.Seek(0, 0);
            return memoryStream;
        }
    }
}
