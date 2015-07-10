using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpITFunctionsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //prompt user for input
            Console.WriteLine("What is the decription of the item?");
            string itemDescription = Console.ReadLine();
           
            double itemPrice;
            bool parse;
            do {
                Console.WriteLine("What is the price of the item?");
                parse = Double.TryParse(Console.ReadLine(), out itemPrice);
            } while (!parse);
            firstLevelMgr(itemDescription, itemPrice);

        }

        static bool firstLevelMgr(string description, double price)
        {
            //check i the decription contains entertainment (regardless of case)
            if (description.ToLower().Contains("entertainment"))
            {
                return false;
            }
            if (price > 250)
            {
                return secondLevelMgr(description, price);
            }

            return true;
        }


    }
}
