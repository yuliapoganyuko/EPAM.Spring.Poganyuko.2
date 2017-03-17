using System;
using System.CodeDom;
using Task2Logic;

namespace Task2Console
{
    class Program
    {

        #region Public methods

        public static void Main(string[] args)
        {
            Run();
            Console.ReadKey();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Runs the work with user
        /// </summary>
        private static void Run()
        {
            int[] array = GetUserInput();
            if (array.Length == 2)
            {
                Result resultOfEuclidiusAlgoritmm = Gcd.GetGcd(array[0], array[1]);
                Result resultOfBinaryAlgoritmm = Gcd.GetBinaryGcd(array[0], array[1]);
                Console.WriteLine($"Euclidius algoritmm: {resultOfEuclidiusAlgoritmm.Gcd.ToString()}; elapsed time: {resultOfEuclidiusAlgoritmm.Time.TotalMilliseconds.ToString()}");
                Console.WriteLine($"Binary algoritmm: {resultOfBinaryAlgoritmm.Gcd.ToString()}; elapsed time: {resultOfBinaryAlgoritmm.Time.TotalMilliseconds.ToString()}");
            }
            else
            {
                int a = array[0], b = array[1];
                int[] newArray = new int[array.Length - 2];
                for (int i = 0; i < newArray.Length; i++)
                    newArray[i] = array[i + 2];
                Result resultOfEuclidiusAlgoritmm = Gcd.GetGcd(a, b, newArray);
                Result resultOfBinaryAlgoritmm = Gcd.GetBinaryGcd(a, b, newArray);
                Console.WriteLine($"Euclidius algoritmm: {resultOfEuclidiusAlgoritmm.Gcd.ToString()}; elapsed time: {resultOfEuclidiusAlgoritmm.Time.TotalMilliseconds.ToString()}");
                Console.WriteLine($"Binary algoritmm: {resultOfBinaryAlgoritmm.Gcd.ToString()}; elapsed time: {resultOfBinaryAlgoritmm.Time.TotalMilliseconds.ToString()}");
            }
        }

        /// <summary>
        /// Methog gets integers.
        /// </summary>
        /// <returns>The array consisting of integers</returns>
        private static int[] GetUserInput()
        {
            int count;
            do
            {
                Console.WriteLine("Enter the number of elements:");
                count = GetInt();
            } while (count < 2);


            int[] array = new int[count];

            Console.WriteLine("Enter elements:");
            for (int index = 0; index < count; index++)
            {
                array[index] = GetInt();
            }
            return array;
        }

        /// <summary>
        /// Gets the integer value.
        /// </summary>
        /// <returns>The integer value</returns>
        private static int GetInt()
        {
            int number;
            while (!Int32.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Check your input");
            }
            return number;
        }

        #endregion
    }
}
