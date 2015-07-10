using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpITFunctionsLab
{
    class Program
    {

        //enum jobLevel { Employee, FirstLevelManager, SecondLevelManager, Director, CEO };

        static void Main(string[] args)
        {

            bool parse;
            int empLevel;

            //define levels
            string[] jobLevel = {"Employee", "FirstLevelManager", "SecondLevelManager", "Director", "CEO"};

            //prompt user for their level
           
            for (int i = 0; i <5; i++)
            {
                Console.WriteLine(i + ": " + jobLevel[i]);
            }
            
            do
            {
                Console.WriteLine("Please enter your rank within HappyFace, Inc.:");
                parse = Int32.TryParse(Console.ReadLine(), out empLevel);
            } while (!parse || empLevel < 0 || empLevel > 5);

            
            //prompt user for input
            Console.WriteLine("What is the decription of the item?");
            string itemDescription = Console.ReadLine();
           
            double itemPrice;
            
            do {
                Console.WriteLine("What is the price of the item?");
                parse = Double.TryParse(Console.ReadLine(), out itemPrice);
            } while (!parse);

            bool approved = false;
            switch (empLevel)
            {
                case 0:
                    approved = firstLevelMgr(itemDescription, itemPrice);
                    break;
                case 1:
                    approved = secondLevelMgr(itemDescription, itemPrice);
                    break;
                case 2:
                    approved = director(itemDescription, itemPrice);
                    break;
                case 3:
                    approved = ceo(itemDescription, itemPrice);
                    break;
                case 4:
                    approved = true;
                    break;
                default:
                    Console.WriteLine("I am confused.");
                    break;
            }

            if (approved)
            {
                Console.WriteLine("Your request is approved!");
            }
            else
            {
                Console.WriteLine("Sorry, your request is denied!");
            }

            Console.WriteLine();    //whitespace
            Console.WriteLine("Press return to exit.");
            Console.Read();

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
            Console.WriteLine("Approved by the first level manager.");
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
            Console.WriteLine("Approved by the second level manager.");
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
            Console.WriteLine("Approved by the director.");
            return true;
        }

        static bool ceo(string description, double price)
        {
            //our CEO loves us and wants us to be happy!
            Console.WriteLine("Approved by the CEO.");
            return true;
        }

    }
}
