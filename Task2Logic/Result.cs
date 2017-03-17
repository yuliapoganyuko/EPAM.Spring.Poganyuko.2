using System;

namespace Task2Logic
{
    /// <summary>
    /// Class-container for results of greatest common divisor counting. Includes elapsed time besides greatest common divisor.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Greatest common divisor 
        /// </summary>
        public int Gcd { get; set; }

        /// <summary>
        /// Elapsed time
        /// </summary>
        public TimeSpan Time { get; set; }

        public Result(int gcd, TimeSpan time)
        {
            Gcd = gcd;
            Time = time;
        }
    }
}
