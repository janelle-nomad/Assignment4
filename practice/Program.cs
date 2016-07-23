using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "grades.txt";
            FileStream custFile, inFile;
            StreamReader reader;
            string nextRecord;
            Boolean done = false;

            if (File.Exists(fileName))
            {
                Console.WriteLine("I'm here");
            }
            else
            {
                Console.WriteLine("I dont exist :(");
            }

            inFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(inFile);
            nextRecord = reader.ReadLine();

            do
            {
                try
                {
                    while (nextRecord != null)
                    {
                        var fields = nextRecord.Split(',');
                        Console.WriteLine(fields[0]);
                        nextRecord = reader.ReadLine();
                    }
                    Console.WriteLine("Complete.........");
                    Console.ReadLine();
                    reader.Close();
                    //inFile.Close();
                    done = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //throw;
                }

                

            } while (!done);

            Console.WriteLine("Finished~~~~~~~~~~~~~~~~~~~~~~`");

        }
    }
}
