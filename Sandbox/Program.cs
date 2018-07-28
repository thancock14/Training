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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\fibonacci.txt";
            double z = 0;
            double a = 0;
            double b = 1;
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        z = a + b;
                        sw.Write(z + ",");
                        a = b;
                        b = z;
                    }
                    z = a + b;
                    sw.WriteLine(z+",");
                    a = b;
                    b = z;
                }
            }
        }
    }
}
