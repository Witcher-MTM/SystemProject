using System;
using System.Diagnostics;
using System.IO;

namespace SystemProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = String.Empty;
            string choice = String.Empty;

            if (args?.Length > 0)
                Console.WriteLine("Test-Console");
            foreach (var item in args)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Enter file path: ");
            path = Console.ReadLine();
            
            FileInfo info = new FileInfo(path);
            do
            {
                if (path.Contains("\""))
                {
                    path = path.Replace("\"", " ");
                }
                if (info.Exists)
                {
                    try
                    {

                        Console.WriteLine($"Your path - {path}\n");
                        Console.WriteLine($"Full name - {info.FullName}\nName - {info.Name}\nDirectory - {info.Directory}\nDirectory name - {info.DirectoryName}\n" +
                            $"Attributes - {info.Attributes}\nCreation time - {info.CreationTime}\nIs read only? - {info.IsReadOnly}\nExtension - {info.Extension}" +
                            $"\nLast access time - {info.LastAccessTime}\n");

                        Console.WriteLine("If you need to open enter - \"Open\" if not, stay emtpy");
                        choice = Console.ReadLine();
                        if (choice.ToLower() == "open")
                        {
                            try
                            {
                                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(3000);
                            Environment.Exit(0);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Isnt exist!");
                }

            } while (choice.ToLower() != "open");


        }
    }
}
