namespace TaxesCalculator
{
    using System;

    using Microsoft.Owin.Hosting;

    public static class Program
    {
        public static void Main(string[] args)
        {
            const string BaseUri = "http://localhost:8080";

            Console.WriteLine("Starting web Server...");
            WebApp.Start<Startup>(BaseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit. ", BaseUri);
            Console.ReadLine();
        }
    }
}