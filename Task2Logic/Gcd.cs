using System;
using System.Diagnostics;

namespace Task2Logic
{
    /// <summary>
    /// Provides functionality for getting a greatest common divisor.
    /// </summary>
    public static class Gcd
    {
        #region Public methods

        /// <summary>
        /// Counts a greatest common divisor for the pair of numbers using Euclid's algorithm.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>The object of Result class consisting of fields with greatest common divisor and elapsed time</returns>
        public static Result GetGcd(int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException();

            Stopwatch timer = StartTimer();
            int gcd = GetEuclidGcd(Math.Abs(a), Math.Abs(b));
            TimeSpan time = StopTimer(timer);
            return new Result(gcd, time);
        }

        /// <summary>
        /// Counts a greatest common divisor for 3 and more numbers using Euclid's algorithm.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="array">Other numbers</param>
        /// <returns>The object of Result class consisting of fields with greatest common divisor and elapsed time</returns>
        public static Result GetGcd(int a, int b, params int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                GetGcd(a, b);
            int i = 0;
            while (i < array.Length && array[i] == 0)
                i++;
            if (i == array.Length)
                throw new ArgumentException();
            Stopwatch timer = StartTimer();
            int gcd = GetEuclidGcd(a, b, array);
            TimeSpan time = StopTimer(timer);
            return new Result(gcd, time);
        }

        /// <summary>
        /// Counts a greatest common divisor for the pair of numbers using binary algorithm.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>The object of Result class consisting of fields with greatest common divisor and elapsed time</returns>
        public static Result GetBinaryGcd(int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException();
            Stopwatch timer = StartTimer();
            int gcd = GetGcdByBinaryAlgorithm(Math.Abs(a), Math.Abs(b));
            TimeSpan time = StopTimer(timer);
            return new Result(gcd, time);
        }

        /// <summary>
        /// Counts a greatest common divisor for 3 and more numbers using binary algorithm.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="array">Other numbers</param>
        /// <returns>The object of Result class consisting of fields with greatest common divisor and elapsed time</returns>
        public static Result GetBinaryGcd(int a, int b, params int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                GetGcd(a, b);
            int i = 0;
            while (i < array.Length && array[i] == 0)
                i++;
            if (i == array.Length)
                throw new ArgumentException();
            Stopwatch timer = StartTimer();
            int gcd = GetGcdByBinaryAlgorithm(a, b, array);
            TimeSpan time = StopTimer(timer);
            return new Result(gcd, time);
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Counts a greatest common divisor for the pair of numbers using Euclid's algorithm.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common divisor</returns>
        private static int GetEuclidGcd(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }
            return a;
        }

        /// <summary>
        /// Counts a greatest common divisor for 3 and more numbers using Euclid's algorithm.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="array">Other numbers</param>
        /// <returns>Greatest common divisor</returns>
        private static int GetEuclidGcd(int a, int b, params int[] array)
        {
            a = GetEuclidGcd(Math.Abs(a), Math.Abs(b));
            for (int i = 0; i < array.Length; i++)
            {
                a = GetEuclidGcd(a, Math.Abs(array[i]));
            }
            return a;
        }

        /// <summary>
        /// Counts a greatest common divisor for the pair of numbers using binary algorithm.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common divisor</returns>
        private static int GetGcdByBinaryAlgorithm(int a, int b)
        {
            if (a == b)
                return a;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                    return GetGcdByBinaryAlgorithm(a >> 1, b);
                return GetGcdByBinaryAlgorithm(a >> 1, b >> 1) << 1;
            }
            if ((~b & 1) != 0)
                return GetGcdByBinaryAlgorithm(a, b >> 1);
            if (a > b)
                return GetGcdByBinaryAlgorithm((a - b) >> 1, b);
            return GetGcdByBinaryAlgorithm((b - a) >> 1, a);
        }

        /// <summary>
        /// Counts a greatest common divisor for 3 and more numbers using binary algorithm.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="array">Other numbers</param>
        /// <returns>Greatest common divisor</returns>
        private static int GetGcdByBinaryAlgorithm(int a, int b, params int[] array)
        {
            a = GetGcdByBinaryAlgorithm(Math.Abs(a), Math.Abs(b));
            for (int i = 0; i < array.Length; i++)
            {
                a = GetGcdByBinaryAlgorithm(Math.Abs(a), Math.Abs(array[i]));
            }
            return a;
        }

        /// <summary>
        /// Starts time measuring.
        /// </summary>
        /// <returns>Started Stopwatch object</returns>
        private static Stopwatch StartTimer()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            return timer;
        }

        /// <summary>
        /// Stops time measuring.
        /// </summary>
        /// <param name="timer">Started Stopwatch object</param>
        /// <returns>Elapsed time</returns>
        private static TimeSpan StopTimer(Stopwatch timer)
        {
            timer.Stop();
            return timer.Elapsed;
        }

        #endregion

    }
    }
