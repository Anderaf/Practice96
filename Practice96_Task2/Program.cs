using System;

namespace Practice96_Task2
{
    internal class Program
    {
        public static event Func<string[], bool, string[]> OnSortingRequested;
        static void Main(string[] args)
        {
            string[] lastNames = new string[5] { "Иванов", "Кузнецова", "Жуков", "Кульдпере", "Аев" };
            OnSortingRequested += SortByAlphabet;

            Console.WriteLine("1 - Сортировка А-Я, 2 - Сортировка Я-А");

            string input = Console.ReadLine();

            try
            {
                switch (input)
                {
                    case "1":
                        lastNames = OnSortingRequested.Invoke(lastNames, false);
                        break;
                    case "2":
                        lastNames = OnSortingRequested.Invoke(lastNames, true);
                        break;
                    default:
                        throw new WrongInputException("Значение: " + input + ", ожидалось 1 или 2");
                }
                foreach (var item in lastNames)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                if (e is WrongInputException)
                {
                    Console.WriteLine("Неверный ввод! - {0}", e.Message);
                }
                else
                {
                    Console.WriteLine("Непредвиденная ошибка! - {0}", e.Message);
                }
            }
        }

        static string[] SortByAlphabet(string[] arr, bool inverse = false)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int y = 0; y < arr.Length - 1; y++)
                {
                    if (NeedToReOrder(arr[y], arr[y + 1], inverse))
                    {
                        string s = arr[y];
                        arr[y] = arr[y + 1];
                        arr[y + 1] = s;
                    }
                }
            }
            return arr;
        }

        static bool NeedToReOrder(string s1, string s2, bool inverse = false)
        {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return inverse;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return !inverse;
            }
            return inverse;
        }
    }
}
