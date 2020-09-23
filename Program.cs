using System;
using System.IO;
using System.Security.Cryptography;
namespace Pak_Compare
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Usage for PakCompare is this in cmd:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("PakCompare somepakname.pak someotherpakname.pak");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.Title = ".PAK File Compare | Made by Kye#5000";
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Comparing " + args[0] + " with " + args[1]);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            string file1 = SHA256CheckSum(args[0]);
            Console.WriteLine("Sha256 for " + args[0] + " is " + file1);
            string file2 = SHA256CheckSum(args[1]);
            Console.WriteLine("Sha256 for " + args[1] + " is " + file2);
            if (file1 == file2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Files are identical!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Files are unique!");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }

       static string SHA256CheckSum(string filePath)
        {
            using (SHA256 SHA256 = SHA256Managed.Create())
            {
                using (FileStream fileStream = File.OpenRead(filePath))
                    return Convert.ToBase64String(SHA256.ComputeHash(fileStream));
            }
        }
    }
}
