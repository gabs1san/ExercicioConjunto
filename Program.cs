using System;
using System.Collections.Generic;
using System.IO;
using ExercicioConjunto.Entities;

namespace ExercicioConjuto
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<LogRecord> set = new HashSet<LogRecord>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string lineRaw = sr.ReadLine();
                        string[] line = lineRaw.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                        if (line.Length == 2 && DateTime.TryParse(line[1], out DateTime instant))
                        {
                            string name = line[0];
                            set.Add(new LogRecord { Username = name, Instant = instant });
                            Console.WriteLine(lineRaw); 
                        }
                    }
                }

                Console.WriteLine("\nTotal users: " + set.Count);
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro ao ler o arquivo: " + e.Message);
            }
        }
    }
}
