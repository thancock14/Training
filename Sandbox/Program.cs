using System;
using System.IO;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteFibonacci();
            ReadFibonacci();
           

        }
        static void WriteFibonacci()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\fibonacci.txt";
            double next = 0;
            double first = 0;
            double second = 1;
            using (StreamWriter sw = new StreamWriter(path))
            {
                    for (int y = 1; y < 101; y++)
                    {
                        next = first + second;
                        int z = (y % 10);
                        bool ck = (z == 0) ? true : false;
                        if (ck)
                        {
                            sw.WriteLine(next + ",");
                        }
                        else
                        {
                            sw.Write(next + ",");
                        }
                        first = second;
                        second = next;
                    }
            }
        }
        
        /*This function writes fibonacci numbers from fibonacci.txt file to console 
        1 line at a time waiting for user to press enter for next line*/
        static void ReadFibonacci()
        {
            String line;
            ConsoleKeyInfo k;

            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\fibonacci.txt";
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    //Wait for user to press 'Enter'.
                    do
                    {
                        Console.WriteLine("Press Enter for next line of Fibonacci.");
                        k = Console.ReadKey();
                        Console.WriteLine();
                    } while (k.Key != ConsoleKey.Enter);


                    line = sr.ReadLine();
                }

                Console.WriteLine("You have reached the end of the file. Press any key to exit.");
                Console.ReadKey();
                sr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
