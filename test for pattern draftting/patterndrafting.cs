using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;

public class PatternDrafting
{
    // Properties for measurements
    public double Chest { get; set; }
    public double HalfBack { get; set; }
    public double BackNeckToWaist { get; set; }
    public double SyceDepth { get; set; }

    // Constructor to initialize measurements
    public PatternDrafting(double chest, double halfBack, double backNeckToWaist, double syceDepth)
    {
        Chest = chest;
        HalfBack = halfBack;
        BackNeckToWaist = backNeckToWaist;
        SyceDepth = syceDepth;
    }

    // Method to draft a basic block pattern and save it as a PDF
    public void DraftBasicBlockPattern(string filePath)
    {
        // Calculate key points
        double point0X = 50, point0Y = 50; // Starting point
        double point1X = point0X, point1Y = point0Y + BackNeckToWaist + 1;
        double point2X = point0X, point2Y = point0Y + 80; // Example finished length
        double point3X = point0X, point3Y = point0Y + SyceDepth + 1;

        // Create a new PDF document
        PdfDocument document = new PdfDocument();
        document.Info.Title = "Pattern Draft";

        // Add a page to the document
        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);

        // Draw points and lines
        XPen pen = new XPen(XColors.Black, 1);

        // Mark and label the points
        DrawPoint(gfx, point0X, point0Y, "0");
        DrawPoint(gfx, point1X, point1Y, "1");
        DrawPoint(gfx, point2X, point2Y, "2");
        DrawPoint(gfx, point3X, point3Y, "3");

        // Draw lines connecting points
        gfx.DrawLine(pen, point0X, point0Y, point1X, point1Y);
        gfx.DrawLine(pen, point0X, point0Y, point3X, point3Y);

        // Save the PDF
        document.Save(filePath);
    }

    // Helper method to draw and label points
    private void DrawPoint(XGraphics gfx, double x, double y, string label)
    {
        // Draw a small circle to mark the point
        gfx.DrawEllipse(XPens.Black, XBrushes.Black, x - 2, y - 2, 4, 4);

        // Label the point
        XFont font = new XFont("Arial", 10);
        gfx.DrawString(label, font, XBrushes.Black, new XPoint(x + 5, y - 5));
    }
}
