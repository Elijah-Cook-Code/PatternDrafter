using System;
using System.Diagnostics; // To open the PDF file automatically
using PdfSharp.Drawing;
using PdfSharp.Pdf;

class PatternDraftingProgram
{
    static void Main()
    {
        try
        {
            // Input measurements
            double chest = 100; // cm
            double halfBack = 20; // cm
            double backNeckToWaist = 44.2; // cm
            double syceDepth = 24.4; // cm

            // Calculate points
            double point0X = 50, point0Y = 50; // Starting point
            double point1X = point0X, point1Y = point0Y + backNeckToWaist + 1;
            double point2X = point0X, point2Y = point0Y + 80; // Example finished length
            double point3X = point0X, point3Y = point0Y + syceDepth + 1;

            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Pattern Draft";

            // Add a page to the document
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Draw points and lines based on the instructions
            XPen pen = new XPen(XColors.Black, 1);

            // Mark and label the points
            DrawPoint(gfx, point0X, point0Y, "0");
            DrawPoint(gfx, point1X, point1Y, "1");
            DrawPoint(gfx, point2X, point2Y, "2");
            DrawPoint(gfx, point3X, point3Y, "3");

            // Draw lines connecting points
            gfx.DrawLine(pen, point0X, point0Y, point1X, point1Y);
            gfx.DrawLine(pen, point0X, point0Y, point3X, point3Y);

            // Save the PDF to the Desktop
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = System.IO.Path.Combine(desktopPath, "PatternDraft.pdf");
            document.Save(filename);
            Console.WriteLine($"PDF saved as {filename}");

            // Open the PDF file automatically
            Process.Start(new ProcessStartInfo
            {
                FileName = filename,
                UseShellExecute = true // Use the default PDF viewer to open the file
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void DrawPoint(XGraphics gfx, double x, double y, string label)
    {
        // Draw a small circle to mark the point
        gfx.DrawEllipse(XPens.Black, XBrushes.Black, x - 2, y - 2, 4, 4);

        // Label the point
        XFont font = new XFont("Arial", 10);
        gfx.DrawString(label, font, XBrushes.Black, new XPoint(x + 5, y - 5));
    }
}
