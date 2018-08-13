using System;
using System.IO;
using System.Linq;

namespace Sandbox
{
    class Program
    {
        public static void Main(string[] args)
        {
            //WriteFibonacci();
            //ReadFibonacci();
            ReadToFile();

        }

        static void WriteFibonacci()
        {
            //Get path of desktop and create/overwrite text file
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\fibonacci.txt";
            double next = 0;
            double first = 0;
            double second = 1;

            //Write first 100 fibonacci numbers to the text file, 10 numbers per row, separated by ','.
            using (StreamWriter sw = new StreamWriter(path))
            {
                    for (int y = 1; y <= 100; y++)
                    {
                        next = first + second;
                        sw.Write(next + ",");
                        
                        //shifting numbers back
                        first = second;
                        second = next;

                        //starting next line after 10 numbers
                        if (y % 10 == 0)
                        {
                            sw.WriteLine();
                        }
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

        //This function writes the fibonacci numbers to a file of the user's choice.
        static void ReadToFile()
        {
            ConsoleKeyInfo Answer1;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string FileName;
            string fullpath;

            //Wait for answer of Y
            Console.WriteLine("Would you like to write the Fibonacci to a file of your choice? Y/N");
            Answer1 = Console.ReadKey();
            if (Answer1.Key != ConsoleKey.Y)
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Are you sure?");
                    Answer1 = Console.ReadKey();
                } while (Answer1.Key != ConsoleKey.Y);
            }
            //Get name of existing file to write fibonacci to
            do
            {
                Console.WriteLine();
                Console.WriteLine("What is the name of an existing file on the desktop you would like to write the Fibonacci code to?/nPlease include file extension. (i.e File.txt)");
                FileName = Convert.ToString(Console.ReadLine());
                fullpath = path + "//"+FileName;
            } while (!File.Exists(fullpath));

            //fullpath = path + "//Test.txt";
            string Fibpath = path + "\\fibonacci.txt";
            var Linestoread = from line in File.ReadLines(Fibpath)
                               select line;

            File.AppendAllLines(fullpath, Linestoread);
            
        }
    }
}
