using System;
using System.IO;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteFibonacci();
           

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
       
    }
}
