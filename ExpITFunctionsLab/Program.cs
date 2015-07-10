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
            //check if the decription contains entertainment (regardless of case)
            if (description.ToLower().Contains("entertainment"))
            {
                return false;
            }
            //cannot approve if over $250
            if (price > 250)
            {
                return secondLevelMgr(description, price);
            }

            //otherwise approve!  we are liberal managers
            return true;
        }

        static bool secondLevelMgr(string description, double price)
        {
            //check if the decription contains towncar(s) (regardless of case)
            if (description.ToLower().Contains("towncar"))
            {
                return false;
            }
            //cannot approve if over 500, kick it up a level!
            if (price > 500)
            {
               return director(description, price);
            }

            //otherwise approve!  we are liberal managers
            return true;
        }

        static bool director(string description, double price)
        {
            //check if the decription contains hardawre (regardless of case)
            //currently assuming that the keyword hardware will be explicitly contained in the decription
            if (description.ToLower().Contains("hardware") && price > 5000)
            {
                return false;
            }
            //cannot approve if over 1000, kick it up a level!
            if (price > 1000)
            {
                return ceo(description, price);
            }

            //otherwise approve!  we are liberal managers
            return true;
        }

        static bool ceo(string description, double price)
        {
            //our CEO loves us and wants us to be happy!
            return true;
        }

    }
}
