using System;

namespace FixingVol2
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int num1;
                int num2;
                byte result;

                num1 = 10;//30
                num2 = 5;//60
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }

        }
    }
}
