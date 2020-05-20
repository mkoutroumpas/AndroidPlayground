using System;

namespace PlaygroundTest
{
    public class Helpers
    {
        /// <summary>
        /// Use this method to emulate tasks with a heavy calculation load. 
        /// </summary>
        public static void Heavy_Task()
        {
            double count = 0;

            while (true)
            {
                Math.Exp(Math.Sqrt(count));

                count++;
            }
        }
    }
}