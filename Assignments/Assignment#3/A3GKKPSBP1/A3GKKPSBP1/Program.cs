/*
 * Program Id : A3GKKPSBP1
 *
 * Purpose : Assignment3 Part1 for "for, while, do while loop"
 * 
 * Revision History:
 * created Oct 2020 by  Kantor, Gurpreet 
 *                      Park, Sangbong 
 *                      Pham, Kevin 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3GKKPSBP1
{
	class Program
	{
        public static void CaculationOptioinOne()
        {
            //declear variables.
            int inputNumInteger;
            int i;
            int resultValueInteger;

            //initialize variables.
            inputNumInteger = 0;
            i = 0;
            resultValueInteger = 0;

            //Ask starting number
            Console.Write("Enter starting number : ");
            try
            {
                inputNumInteger = int.Parse(Console.ReadLine());

                for (i = inputNumInteger; i <= 20 + inputNumInteger; i++)
                {
                    //Even X 7
                    if ((resultValueInteger %= 2) == 0)
                    {
                        resultValueInteger = i * 7;
                    }
                    // Odd X 8
                    else
                    {
                        resultValueInteger = i * 8;
                    }

                    Console.WriteLine("Raw : " + i + " Result : " + resultValueInteger);
                }
            }
            catch (Exception e)              //Exception handling for unexpected situation.
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Error Message : " + e.Message);
                Console.WriteLine("Please enter number only ");
                Console.WriteLine("--------------------------------");

            }

        }

        public static void CaculationOptioinTwo()
        {
            //declear variables.
            string inputValueString;
            double inputNumbleDouble;

            //initialize variables.
            inputValueString = "";
            inputNumbleDouble = 0;

            while (true)
            {
                try
                {
                    Console.Write("Enter the Number or \"END\"(Exit) : ");

                    inputValueString = Console.ReadLine();

                    if (inputValueString == "END" || inputValueString == "end" || inputValueString == "End")
                    {
                        break;
                    }

                    inputNumbleDouble = double.Parse(inputValueString);

                }
                catch (Exception e)              //Exception handling for unexpected situation.
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Please enter number only (Except \" \" )");
                    Console.WriteLine("--------------------------------");
                    continue;
                }

                Console.WriteLine("Result : " + inputNumbleDouble + " / " + 3 + " = " + inputNumbleDouble / 3);

            }
        }
        static void Main(string[] args)
		{
            //declear variables.
            int optionInteger;

            //initialize variables.
            optionInteger = 0;


            //Infinity loop if optionInteger is not 3.
            do
            {
                try
                {
                    optionInteger = 0;
                    Console.WriteLine("1. Option:1");
                    Console.WriteLine("2. Option:2");
                    Console.WriteLine("3. Option:3(Exit)");
                    Console.Write("Enter one option : ");

                    optionInteger = int.Parse(Console.ReadLine());

                    //throw exception handling input is not valid.
                    if (optionInteger > 3 || optionInteger < 1)
                    {
                        throw new Exception("Error Handling : Input value is more than 3 or less than 1");
                    }

                }
                catch (OverflowException e)      //Exception handling for unexpected situation.
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Please enter correct number");
                    Console.WriteLine("--------------------------------\n");
                }
                catch (FormatException e)        //Exception handling for unexpected situation.
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Please enter number only");
                    Console.WriteLine("--------------------------------\n");
                }
                catch (Exception e)              //Exception handling for unexpected situation.
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Please enter less than 4");
                    Console.WriteLine("--------------------------------\n");
                }
                finally
                {
                    switch (optionInteger)
                    {
                        case 1:
                            CaculationOptioinOne();
                            break;
                        case 2:
                            CaculationOptioinTwo();
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            while (optionInteger != 3);

            Console.ReadLine();
        }
	}
}
