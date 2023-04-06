using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pair pair1 = new FazzyNumber(10, 1);
            Pair pair2 = new FazzyNumber(20, 2);
            Console.WriteLine($"pair1 = {pair1}");
            Console.WriteLine($"pair2 = {pair2}");
            Console.WriteLine($"pair1 + pair2 = {pair1.Add(pair2)}");
            Console.WriteLine($"pair1 - pair2 = {pair1.Subtract(pair2)}");
            Console.WriteLine($"pair1 * pair2 = {pair1.Multiply(pair2)}");
            Console.WriteLine($"pair1 / pair2 = {pair1.Divide(pair2)}");
            Pair pair3 = new Fraction(2, 3);
            Pair pair4 = new Fraction(-1, 4);
            Console.WriteLine($"pair3 = {pair3}");
            Console.WriteLine($"pair4 = {pair4}");
            Console.WriteLine($"pair3 + pair4 = {pair3.Add(pair4)}");
            Console.WriteLine($"pair3 - pair4 = {pair3.Subtract(pair4)}");
            Console.WriteLine($"pair3 * pair4 = {pair3.Multiply(pair4)}");
            Console.WriteLine($"pair3 / pair4 = {pair3.Divide(pair4)}");
            Console.ReadKey();
        }

    }

}
