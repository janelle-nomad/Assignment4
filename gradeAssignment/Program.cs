using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradeAssignment
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu();
            
        }

        public static void Menu()
        {
            string pathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            const char DELIM = ',';

            int selection = 0;

            while (selection != 2)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("Press 1 or 2 to continue:");
                Console.WriteLine(" 1. Display Grades    ");
                Console.WriteLine(" 2. Exit              ");
                Console.WriteLine("***************************");

                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    selection = 0;
                }
                switch (selection)
                {
                    case 1:
                        CreateGradeTxt(pathName, DELIM);
                        DisplayGrades(pathName, DELIM);
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a correct input \n");
                        break;
                }
            }
        }

        private static void CreateGradeTxt(string pathName, char DELIM)
        {
            string fileName = "Grades.txt";
            string firstName;
            string lastName;
            string Index;
            string className;
            string classGrade;

            try
            {
                FileStream outFile = new FileStream(pathName + "\\" + fileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);

                for (int i = 0; i < 3; i++)
                {
                    writer.WriteLine(firstName[i] + DELIM + lastName[i] + DELIM + Index[i] + DELIM + className[i] + DELIM + classGrade[i]);
                }
                writer.Close();
                outFile.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0}", error.Message);
            }
        }

        public static void DisplayGrades(string pathName, char DELIM)
        {
            string fileName;
            string[] fields;
            string fileData = "";
            string firstName;
            string lastName;
            string studentIndex;
            string className;
            string classGrade;

            Console.Write("Please enter the file name: ");
            fileName = Console.ReadLine();
            Console.WriteLine();

            try
            {
                FileStream inFile = new FileStream(pathName + "\\" + fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                fileData = reader.ReadLine();

                while (fileData != null)
                {
                    fields = fileData.Split(DELIM);
                    firstName = fields[0];
                    lastName = fields[1];
                    studentIndex = fields[2];
                    className = fields[3];
                    classGrade = fields[4];

                    Console.WriteLine("{0}, {1}: {2} {3}, {4}", firstName, lastName, studentIndex, className, classGrade);
                    fileData = reader.ReadLine();
                }
                Console.WriteLine();
                reader.Close();
                inFile.Close();
            }
            catch (FileNotFoundException)
            {
                Console.Clear();
                Console.WriteLine("File doesn't exist ");
            }
        }
        //try
        //{

        //    string fileName = "grades.txt.txt";
        //    StreamWriter writer;


        //    FileStream streamFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);

        //    // Create an instance of StreamReader to read from a file.
        //    // The using statement also closes the StreamReader.
        //    using (StreamReader sr = new StreamReader(streamFile))
        //    {
        //        string line;

        //        // Read and display lines from the file until 
        //        // the end of the file is reached. 
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            Console.WriteLine(line);
        //        }
        //    }
        //}
        //catch (Exception e)
        //{
        //    // Let the user know what went wrong.
        //    Console.WriteLine("The file could not be read:");
        //    Console.WriteLine(e.Message);

        //}

        //Console.ReadKey();
    }
    }
}
