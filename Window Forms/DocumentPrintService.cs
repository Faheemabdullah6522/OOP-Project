using System.Diagnostics;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using PDFtoImage;
using SkiaSharp;

namespace Window_Forms
{
    public static class DocumentPrintService
    {
        public static void OpenDocument(string? filePath)
        {
            if (!EnsureFileExists(filePath))
                return;

            Process.Start(new ProcessStartInfo(filePath!) { UseShellExecute = true });
        }

        public static void PrintDocument(string? filePath)
        {
            if (!EnsureFileExists(filePath))
                return;

            string extension = Path.GetExtension(filePath!).ToLowerInvariant();
            if (extension is ".jpg" or ".jpeg" or ".png" or ".bmp")
            {
                PrintImage(filePath!);
                return;
            }

            if (extension == ".pdf")
            {
                PrintPdf(filePath!);
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo(filePath!) { UseShellExecute = true, Verb = "print" });
            }
            catch (Exception ex)
            {
                ToastForm.ShowWarning(
                    $"This document could not be sent directly to the printer.\n\nOpen it and print from the viewer.\n\n{ex.Message}");
                OpenDocument(filePath);
            }
        }

        private static void PrintImage(string filePath)
        {
            using Image image = Image.FromFile(filePath);
            using PrintDocument document = new PrintDocument();

            document.DocumentName = Path.GetFileName(filePath);
            document.PrintPage += (sender, args) =>
            {
                if (args.Graphics == null)
                    return;

                Rectangle bounds = args.MarginBounds;
                float ratio = Math.Min((float)bounds.Width / image.Width, (float)bounds.Height / image.Height);
                int width = (int)(image.Width * ratio);
                int height = (int)(image.Height * ratio);
                int x = bounds.Left + (bounds.Width - width) / 2;
                int y = bounds.Top + (bounds.Height - height) / 2;

                args.Graphics.DrawImage(image, new Rectangle(x, y, width, height));
                args.HasMorePages = false;
            };

            using PrintDialog dialog = new PrintDialog { Document = document, UseEXDialog = true };
            if (dialog.ShowDialog() == DialogResult.OK)
                document.Print();
        }

        private static bool EnsureFileExists(string? filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                return true;

            ToastForm.ShowWarning("The selected file was not found on disk.");
            return false;
        }

        private static void PrintPdf(string filePath)
        {
            List<Bitmap>? pages = null;
            try
            {
                pages = Conversion
               .ToImages(File.ReadAllBytes(filePath), options: new RenderOptions(Dpi: 150))
               .Select(SkToBitmap)
               .ToList();
            }
            catch (Exception ex)
            {
                ToastForm.ShowWarning($"PDF could not be prepared for printing.\n\n{ex.Message}");
                return;
            }

            int index = 0;
            using PrintDocument doc = new() { DocumentName = Path.GetFileName(filePath) };
            doc.PrintPage += (_, e) =>
            {
                if (e.Graphics == null) return;
                Rectangle b = e.MarginBounds;
                float r = Math.Min((float)b.Width / pages[index].Width, (float)b.Height / pages[index].Height);
                int w = (int)(pages[index].Width * r), h = (int)(pages[index].Height * r);
                e.Graphics.DrawImage(pages[index], b.Left + (b.Width - w) / 2, b.Top + (b.Height - h) / 2, w, h);
                e.HasMorePages = ++index < pages.Count;
            };

            using PrintDialog dlg = new() { Document = doc, UseEXDialog = true };
            if (dlg.ShowDialog() == DialogResult.OK)
                doc.Print();

            pages.ForEach(b => b.Dispose());
        }

        private static Bitmap SkToBitmap(SKBitmap sk)
        {
            var bmp = new Bitmap(sk.Width, sk.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                System.Drawing.Imaging.ImageLockMode.WriteOnly, bmp.PixelFormat);
            int bytes = Math.Abs(data.Stride) * bmp.Height;
            byte[] buf = new byte[bytes];
            Marshal.Copy(sk.GetPixels(), buf, 0, bytes);
            Marshal.Copy(buf, 0, data.Scan0, bytes);
            bmp.UnlockBits(data);
            sk.Dispose();
            return bmp;
        }

        private static void DisposeBitmaps(List<Bitmap> bitmaps) => bitmaps.ForEach(b => b.Dispose());
    }
}
