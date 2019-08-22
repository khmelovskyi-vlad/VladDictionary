using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            VladDictionary<int> hash = new VladDictionary<int>();
            while (true)
            {
                Console.WriteLine("Write number");
                var findNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Write key");
                var key = Convert.ToInt32(Console.ReadLine());
                if (hash.Contains(findNum, key))
                {
                    hash.Remove(findNum, key);
                }
                else
                {
                    hash.Add(findNum, key);
                }
            }
        }
    }
}
