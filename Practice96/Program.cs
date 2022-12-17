using System;
using System.IO;

namespace Practice96
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exceptions = new Exception[5] { new AssetNotFoundException("Wrong ID"), new DivideByZeroException("\"height\" divided by 0"), new IndexOutOfRangeException("Array's size is 5"), new ArgumentException("System.String instead of System.Int"), new FileNotFoundException(@"Folder\info.txt") };
            try
            {
                var random = new Random();
                throw exceptions[random.Next(0, exceptions.Length)];
            }
            catch (Exception e)
            {
                if (e is AssetNotFoundException)
                {
                    Console.WriteLine("Ассет не найден");
                    Console.WriteLine(e.Message);
                }
                else if (e is DivideByZeroException)
                {
                    Console.WriteLine("На ноль делить нельзя");
                    Console.WriteLine(e.Message);
                }
                else if (e is IndexOutOfRangeException)
                {
                    Console.WriteLine("Индекс не может выходить за границы массива или коллекции");
                    Console.WriteLine(e.Message);
                }
                else if (e is ArgumentException)
                {
                    Console.WriteLine("Неподходящий аргумент");
                    Console.WriteLine(e.Message);
                }
                else if (e is FileNotFoundException)
                {
                    Console.WriteLine("Файл не найден");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
