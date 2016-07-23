using System;
using System.IO;

/*
 * Janelle Heron 
 * 300839820
 * Date Created July 12 2016
 * Date Modified July 22 2016
 * <summary>
 * The purpose of this program is to allow the user to demonstrate File I/O and event handling
 * </summary> 
 * Version 2: Fixed aweful spelling mistakes, also corrected text file path
 */
namespace gradeA_5
{
    class Program
    {
        /**
       * Driver Class 
       * @static
       * @method Main
       * @returns {void}
       */
        static void Main(string[] args)
        {
            ShowUserMenu();
        }
        static void ShowUserMenu() //Menu Method
        {
            bool loopResume = true; //loop resume ~ allows the loop to process
            while (loopResume == true)
            {
                Console.WriteLine("______________________________________");
                Console.WriteLine("Choose one of the following options: ");
                Console.WriteLine("1. Display Grades");
                Console.WriteLine("2. Exit");
                Console.WriteLine("______________________________________");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice) //Switch statement ~ allows the user to select a pre-programmed key, to choose their option
                {
                    case 1:
                        Readtextfile();
                        break;
                    case 2:
                        loopResume = false;
                        break;
                }
            }
        }
        /**
         * <summary>
         * This method shows the menu from which, the user makes their selection
         * </summary>
         * 
         * @static
         * @method Readtextfile ~ Displays content to console window
         * 
         * @returns {void}
         */
        static void Readtextfile() //File reader method
        {
            FileStream inFile;
            StreamReader reader;
            try // Exception handling, in case the file isn't found
            {
                Console.WriteLine("What is the name of the file?");
                string file = "..//..//"; //This path is AWESOME! ~ as the program will literally search for the text file 
                                          // As long as it is in the program directory, the program will find it.
                file += Console.ReadLine();
                file += ".txt";
                inFile = new FileStream(file, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(inFile);
                string recordString = reader.ReadLine();
                string[] Fields = new string[5];
                int counter = 0;
                while (recordString != null)
                {
                    Fields[counter++] = recordString;

                    recordString = reader.ReadLine();
                }
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Fields[i]);

                }
                //added error handling
                reader.Close(); //closes the reader, can cause havock if the reader.close() isn't 
                inFile.Close(); //closes the connection between the variable and the file it's connected to
            }
            catch (Exception)
            {
                Console.WriteLine("Error: That file doesn't exist!"); //error message
            }
        }
    }
}
