using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1Logic;

namespace Task1Console
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
            Console.WriteLine("Enter the number:");
            int number = GetInt(true);
            Console.WriteLine("Enter the power:");
            int power = GetInt(false);
            Console.WriteLine("Enter the epsilon:");
            double eps = GetDouble(true);
            Console.WriteLine(
                $"Root using Newton's algorithm: {NewtonRoot.Root(number, power, eps)}; Math.Pow: {Math.Pow(number, 1.0 / power)}");
        }

        /// <summary>
        /// Gets the double value.
        /// </summary>
        /// <param name="isPositiveNumber">Boolean flag showing if the double value should be positive</param>
        /// <returns>The double value</returns>
        private static double GetDouble(bool isPositiveNumber)
        {
            double number;
            while (!Double.TryParse(Console.ReadLine(), out number) || (isPositiveNumber && number <= 0))
            {
                Console.WriteLine("Check your input");
            }
            return number;
        }

        /// <summary>
        /// Gets the integer value.
        /// </summary>
        /// <param name="isPositiveNumber">Boolean flag showing if the integer value should be positive</param>
        /// <returns>The integer value.</returns>
        private static int GetInt(bool isPositiveNumber)
        {
            int number;
            while (!Int32.TryParse(Console.ReadLine(), out number) || (isPositiveNumber && number <= 0))
            {
                Console.WriteLine("Check your input");
            }
            return number;
        }

        #endregion
        }
    }
