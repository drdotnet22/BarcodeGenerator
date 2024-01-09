using BarcodeGenerator;
using BarcodeStandard;
using SkiaSharp;
using System.Drawing;
using System.Drawing.Imaging;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Text;

namespace BarcodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string barcodeData = "ST1050124";
            var b = new Barcode();
            b.IncludeLabel = true;
            SkiaSharp.SKImage img = b.Encode(BarcodeStandard.Type.Code128, barcodeData);
            var data = img.Encode(SKEncodedImageFormat.Png, 100);
            FileStream stream = new FileStream("barcode.png", FileMode.Open, FileAccess.ReadWrite);
            data.SaveTo(stream);

            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            document.PageSettings.Size = PdfPageSize.A6;
            //Add a page to the document.
            PdfPage page = document.Pages.Add();
            page.Rotation = PdfPageRotateAngle.RotateAngle90;
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;
            //Set the standard font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            //Draw the text.
            graphics.DrawString("Hot Bread & Butter Pickles", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

            PdfBitmap pdfImage = new PdfBitmap(stream);
            graphics.DrawImage(pdfImage, 0, 30);
            //Save the document.
            using (FileStream outputFileStream = new FileStream(Path.GetFullPath("Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                document.Save(outputFileStream);
            }

            //Close the document.
            document.Close(true);
        }
    }
}
