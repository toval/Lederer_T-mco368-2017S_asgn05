using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgn05
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var vals =  new int[]{5,9,4,7,15,16,10,11,14,19,18};

            /*
             * TESTING EXTENSION METHODS!
            */
            Console.WriteLine("TESTING EXTENSION METHODS");
            var result1= vals.MaxOverPrevious();

            Console.WriteLine("\nMaxOverPrevious Extension method");
            display(result1);

            var result2 = vals.LocalMaxima();
            

            Console.WriteLine("\nLocalMaxima Extension method");
            display(result2);
            int tempK = 3;
            var result3 = vals.AtLeastK(tempK, i=>i >=16 && i< 20);
            Console.WriteLine("\nAtLeastK Extension method");
            Console.WriteLine(result3 + " ");

            var result4 = vals.AtLeastHalf(i=>i >= 16 && i < 20);
            Console.WriteLine("\nAtLeastHalf Extension method");
            Console.WriteLine(result4 ? " At least half passed" : "At least half did NOT pass ");

            /*
             * TESTING OVERLOADED EXTENSION METHODS!
             */
            Console.WriteLine("\nTESTING OVERLOADED EXTENSION METHODS");
            var result5 = vals.MaxOverPrevious(i=>i/2+7 );

            Console.WriteLine("\nMaxOverPrevious Overloaded Extension method");
            display(result5);

            var result6 = vals.LocalMaxima(i=>i*2);
           
            Console.WriteLine("\nLocalMaxima Overloaded Extension method");
            display(result6);
            
            int tempK1 = 3;
            var result7 = vals.AtLeastK(tempK1,i=>i+10/3,i => i >= 16 && i < 20);
            Console.WriteLine("\nAtLeastK Overloaded Extension method");
            Console.WriteLine(result7 + " ");

            
            var result8 = vals.AtLeastHalf(i=>i*i,i => i >= 16 && i < 20);
            Console.WriteLine("\nAtLeastHalf Overloaded Extension method");
            Console.WriteLine(result8 ? " At least half passed" : "At least half did NOT pass ");
            
            Console.ReadKey();

        }
        static void display(IEnumerable<int> results)
        {
            foreach (var variable in results)
            {
                Console.Write(variable + " ");
            }
            Console.WriteLine();
        }
    }
}
