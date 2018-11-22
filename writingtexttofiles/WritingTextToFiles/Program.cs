using System;
using System.IO;

namespace WritingTextToFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            for (int j = 0; j < 1000; j++)
            {
                FileStream fileStream = new FileStream($"textFile{j}.txt", FileMode.OpenOrCreate,
                    FileAccess.ReadWrite);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                for (int i = 0; i < 1000; i++)
                {
                    streamWriter.WriteLine(rnd.Next(999999999));
                }

                streamWriter.Close();
            }
        }
    }
}