using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TunniToo
{
    class Program
    {
        static void Main(string[] args)
        {
            //string reversedInput = String.Join(", ", AskForInputUntilZeroAndReverseArrayList().ToArray());
            //Console.WriteLine(reversedInput);
            //Console.ReadKey();

            //string reversedInputLinked = String.Join(", ", AskForInputUntilZeroAndReverseLinkedList().ToArray());
            //Console.WriteLine(reversedInputLinked);
            //Console.ReadKey();

            //ReadFromFileAndCreateNewReversedFile();

            ReadFromFileAndPrintOccurrances();
            Console.ReadKey();
        }

        /// <summary>
        /// Küsi kasutajalt arve, kuni ta sisestab nulli. Salvesta ArrayListi. Väljasta need arvud tagurpidises järjekorras. 
        /// </summary>
        /// <returns>Input numbers in reverse order</returns>
        static ArrayList AskForInputUntilZeroAndReverseArrayList()
        {
            string userInput = "";
            ArrayList inputList = new ArrayList();
            while (userInput != "0")
            {
                Console.Write("Sisesta arv: ");
                userInput = Console.ReadLine().Trim();
                if (userInput != "0")
                {
                    inputList.Add(userInput);
                }
            }

            ArrayList integerList = CreateReverseIntegerArrayList(inputList);
            return integerList;
        }

        private static ArrayList CreateReverseIntegerArrayList(ArrayList stringList)
        {
            ArrayList integerList = new ArrayList();
            foreach (string userInput in stringList)
            {
                if (int.TryParse(userInput, out int intResult))
                {
                    integerList.Add(intResult);
                }
            }

            integerList.Reverse();
            return integerList;
        }

        /// <summary>
        /// Proovi eelmine ülesanne lahendada LinkedListi abil. Omadus Last annab loetelu viimase elemendi, RemoveLast() kustutab viimase. 
        /// </summary>
        /// <returns></returns>
        static LinkedList<int> AskForInputUntilZeroAndReverseLinkedList()
        {
            string userInput = "";
            LinkedList<string> inputList = new LinkedList<string>();
            while (userInput != "0")
            {
                Console.Write("Sisesta arv: ");
                userInput = Console.ReadLine().Trim();
                if (userInput != "0")
                {
                    inputList.AddLast(userInput);
                }
            }

            LinkedList<int> integerList = CreateReversedIntegerLinkedList(inputList);
            return integerList;
        }

        private static LinkedList<int> CreateReversedIntegerLinkedList(LinkedList<string> inputList)
        {
            LinkedList<int> integerList = new LinkedList<int>();
            foreach (var userInput in inputList)
            {
                if (int.TryParse(userInput, out int intResult))
                {
                    integerList.AddFirst(intResult);
                }
            }

            return integerList;
        }

        /// <summary>
        /// Loe tekstifailist arvud, väljasta nad sorteerituna teise tekstifaili.
        /// </summary>
        /// <param name="fileLocation"></param>
        /// <returns></returns>
        private static void ReadFromFileAndCreateNewReversedFile()
        {
            ArrayList inputStringList = new ArrayList();
            FileStream fileStream = new FileStream("textFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                inputStringList.Add(line);
                line = streamReader.ReadLine();
            }

            WriteToFile(inputStringList, "textFileResult.txt");
        }

        private static void WriteToFile(ArrayList inputList, string fileLocation)
        {
            ArrayList outputList = CreateReverseIntegerArrayList(inputList);
            FileStream fileStream = new FileStream(fileLocation, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            foreach (var outputInt in outputList)
            {
                streamWriter.WriteLine(outputInt);
            }

            streamWriter.Close();
        }

        /// <summary>
        /// Loe tekstifailist arvud. Teise tekstifaili väljasta, mitu korda iga arv esines.
        /// </summary>
        private static void ReadFromFileAndPrintOccurrances()
        {
            List<string> inputStringList = new List<string>();
            FileStream fileStream = new FileStream("textFileOccurrence.txt", FileMode.Open,
                FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                inputStringList.Add(line);
                line = streamReader.ReadLine();
            }

            var g = inputStringList.GroupBy(i => i);

            foreach (var grp in g)
            {
                Console.WriteLine($"{grp.Key}, Count: {grp.Count()}");
            }
        }
    }
}