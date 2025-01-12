using System;
using test_for_pattern_draftting;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Pattern Drafting Program!");

        // Main program loop
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Draft a Basic Block Pattern");
            Console.WriteLine("2. View Saved Drafts");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DraftBasicBlockPattern();
                    break;

                case "2":
                    ViewSavedDrafts();
                    break;

                case "3":
                    running = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void DraftBasicBlockPattern()
    {
        Console.WriteLine("\nEnter the following measurements:");

        Console.Write("Chest (cm): ");
        double chest = GetValidDouble();

        Console.Write("Half Back (cm): ");
        double halfBack = GetValidDouble();

        Console.Write("Back Neck to Waist (cm): ");
        double backNeckToWaist = GetValidDouble();

        Console.Write("Syce Depth (cm): ");
        double syceDepth = GetValidDouble();

        Console.Write("Enter a file name for the draft (e.g., MyDraft.pdf): ");
        string fileName = Console.ReadLine();

        // Create a PatternDrafting instance and generate the pattern
        PatternDrafting drafting = new PatternDrafting(chest, halfBack, backNeckToWaist, syceDepth);
        string filePath = $"{fileName}.pdf";

        try
        {
            drafting.DraftBasicBlockPattern(filePath);
            Console.WriteLine($"Pattern successfully drafted and saved as {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while drafting the pattern: {ex.Message}");
        }
    }

    private static void ViewSavedDrafts()
    {
        Console.WriteLine("\nFeature not implemented yet!");
        // Placeholder for future implementation
        // Could involve listing files in a directory or querying a database
    }

    private static double GetValidDouble()
    {
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double value) && value > 0)
                return value;

            Console.Write("Invalid input. Please enter a valid positive number: ");
        }
    }
}
