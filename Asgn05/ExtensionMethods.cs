using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asgn05
{
   public static class ExtensionMethods
    {

        /*
         * Using deferred execution, ensures that this method is only called when needed. 
         * And also it saves performance by saving the state it is in through the yield return.
         * If this method would not be using deferred execution it would either have a .ToList() or create a new list in the extension method itself.
         * In which the values would be saved to the list or added to a new list.
         * When it comes time to display the results, it would require iterating throuh the new list. So in essence there would be 2 iterations. 
         * Whereas if use deferred execution-you would only have to iterate through the list once.
         * As the yield return saves state and allows the method to pick up where it left off.  
         * This is true for both MaxOverPrevious and LocalMaxima extension methods
         */ 
        public static IEnumerable<int> MaxOverPrevious(this IEnumerable<int> list)  
        {   

            int max = list.First();
            foreach (var num in list)
            {
                if (num >= max)
                {
                    max = num;
                    yield return num;
                }
                
            }
        }

        public static IEnumerable<int> MaxOverPrevious(this IEnumerable<int> list, Func<int, int> Transformer)
        {
            var newList = new int[list.Count()];
            for (int i = 0; i < list.Count(); i++)
            {
                newList[i] = Transformer(list.ElementAt(i));
            }
           
            var max = newList.First();
            
            foreach (var num in list)
            {
               
                if (num >= max)
                {
                    max = num;
                    yield return num;
                }

            }
            
        }
        public static IEnumerable<int> LocalMaxima(this IEnumerable<int> list)
        {
            var iter = list.GetEnumerator();

            iter.MoveNext();
            var prev = list.First();
            iter.MoveNext();
            var next = iter.Current;
            foreach (var num in list)
            {

                if (num >= prev && num >= next)
                {
                    prev = num;
                    if (!iter.MoveNext()) next = prev;
                    else next = iter.Current;
                    yield return num;
                }
                else
                {
                    prev = num;
                    if (!iter.MoveNext()) next = prev;
                    else next = iter.Current;
                }
            }
        }
        public static IEnumerable<int> LocalMaxima(this IEnumerable<int> list, Func<int, int> Transformer)
        {
            var newList = new int[list.Count()];
            for (int i = 0; i < list.Count(); i++)
            {
                newList[i] = Transformer(list.ElementAt(i));
            }
            var iter = newList.GetEnumerator();

            iter.MoveNext();
            var prev = newList.First();
            iter.MoveNext();
            var next = iter.Current;
            foreach (var num in newList)
            {

                if (num >= prev && num.CompareTo(next)>0)
                {
                    prev = num;
                    if (!iter.MoveNext()) next = prev;
                    else next = iter.Current;
                    yield return num;
                }
                else
                {
                    prev = num;
                    if (!iter.MoveNext()) next = prev;
                    else next = iter.Current;
                }
            }
        }
        /*
         * The foreach loop goes through each value in the list.
         * And then tests if the condition is met. 
         * If the condition is met, then return true even if didn't finish going through the whole list.
         * So this is similar to how deferred execution works. 
         * This goes for both extension methods AtLeastK and AtLeastHalf. 
         * Where both return if certain condition is met, even if didn't finish iterating through list. 
         */

        public static bool AtLeastK(this IEnumerable<int>list,int val,Func<int,bool>Function)
        {
            int counter = 0; 
            foreach (var num in list)
            {
                if (Function(num)) counter++;
                if (counter == val) return true;

            }

           return false;
            
        }
        public static bool AtLeastK(this IEnumerable<int> list, int val, Func<int, int> Transformer, Func<int, bool> Function)
        {
            int counter = 0;
            foreach (var num in list)
            {
                var newNum = Transformer(num);
                if (Function(newNum)) counter++;
                if (counter == val) return true;

            }
            return false;
        }

        //in the AtLeastHalf method I am keeping track of how many times the Function returns true.
        //if it is at least half then the method will end and will return true,
        public static bool AtLeastHalf(this IEnumerable<int> list,Func<int,bool>Function)
        {
            int counter = 0;
            var half = list.Count() / 2;
            foreach (var num in list)
            {
                if (Function(num)) counter++;
                if (counter >= half) return true;
            }

           return false;
        }
        public static bool AtLeastHalf(this IEnumerable<int> list, Func<int, int> Transformer, Func<int, bool> Function)
        {
            int counter = 0;
            var half = list.Count() / 2;
            foreach (var num in list)
            {
                var newNum = Transformer(num);
                if (Function(newNum)) counter++;
                if (counter >= half) return true;
            }

            return false;
        }
    }
}
