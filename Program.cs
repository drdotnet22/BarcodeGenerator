using BarcodeGenerator;
using BarcodeStandard;
using SkiaSharp;
using System.Drawing;
using System.Drawing.Imaging;

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
            using (var stream = File.OpenWrite(@"C:\Users\Jeff\Downloads\barcode.png"))
            {
                data.SaveTo(stream);
            }
        }
    }
}
