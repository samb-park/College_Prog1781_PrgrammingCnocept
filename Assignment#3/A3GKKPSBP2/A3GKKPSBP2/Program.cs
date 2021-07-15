/*
 * Program Id : A3GKKPSBP2
 *
 * Purpose : Assignment3 Part2 for error handling
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

namespace A3GKKPSBP2
{
	class Program
    {
        public static string InputOperation()
        {
            //Declear and Initialzie varialbes
            bool keepGoingBoolean = true;
            string reValueString = "";

            do
            {
                try
                {
                    Console.Write("Enter ther opration ( 1. \"+\", 2. \"-\", 3. \"/\", 4. \"*\" ) : ");
                    reValueString = Console.ReadLine();

                    switch (reValueString)
                    {
                        case "+":
                        case "1":
                            reValueString = "+";
                            keepGoingBoolean = false;
                            break;
                        case "-":
                        case "2":
                            reValueString = "-";
                            keepGoingBoolean = false;
                            break;
                        case "/":
                        case "3":
                            reValueString = "/";
                            keepGoingBoolean = false;
                            break;
                        case "*":
                        case "4":
                            reValueString = "*";
                            keepGoingBoolean = false;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Error handling : You must enter the operations ( 1. \"+\", 2. \"-\", 3. \"/\", 4. \"*\" )");

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error handling : " + e.Message);
                }
            }
            while (keepGoingBoolean);

            return reValueString;
        }

        public static int InputNumbers(int orderInteger)
        {
            //Declear and Initialzie varialbes
            bool keepGoingBoolean = true;
            int reValueString = 0;

            do
            {
                try
                {
                    Console.Write("Enter number" + orderInteger + " : ");
                    reValueString = int.Parse(Console.ReadLine());
                    keepGoingBoolean = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error handling : It must be only use number");

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error handling : " + e.Message);
                }
            }
            while (keepGoingBoolean);
            return reValueString;
        }

        public static void CalculateNumbers(string operationString, int num1Integer, int num2Integer, int num3Integer, int num4Integer)
        {
            //Declear and Initialzie varialbes
            bool keepGoingBoolean = true;
            int reValueString = 0;

            do
            {
                try
                {
                    switch (operationString)
                    {
                        case "+":
                            //Add all numbers
                            reValueString = num1Integer + num2Integer + num3Integer + num4Integer;
                            Console.WriteLine("Result : " + num1Integer + " + " + num2Integer + " + " + num3Integer + " + " + num4Integer + " = " + reValueString);
                            break;
                        case "-":
                            //First number - third number
                            reValueString = num1Integer - num3Integer;
                            Console.WriteLine("Result : " + num1Integer + " - " + num3Integer + " = " + reValueString);

                            break;
                        case "*":
                            //first * third
                            reValueString = num1Integer * num3Integer;
                            Console.WriteLine("Result : " + num1Integer + " * " + num3Integer + " = " + reValueString);
                            break;
                        case "/":
                            // fourth Num / (First Num + Second Num)
                            reValueString = num4Integer / (num1Integer + num2Integer);
                            Console.WriteLine("Result : " + num4Integer + " / (" + num1Integer + "+" + num3Integer + ") = " + reValueString);
                            break;
                        default:
                            // Error handling1 - Check operations
                            throw new Exception("Error handling : Unexpected error");
                    }
                    keepGoingBoolean = false;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error handling : It must be within rage of integer");

                    operationString = InputOperation();
                    num1Integer = InputNumbers(1);
                    num2Integer = InputNumbers(2);
                    num3Integer = InputNumbers(3);
                    num4Integer = InputNumbers(4);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error handling : " + e.Message);
                    operationString = InputOperation();
                    num1Integer = InputNumbers(1);
                    num2Integer = InputNumbers(2);
                    num3Integer = InputNumbers(3);
                    num4Integer = InputNumbers(4);
                }
            }
            while (keepGoingBoolean);

        }

        public static void Main(string[] args)
        {
            //Declear variables
            string operationString;
            int firstInputInteger;
            int secondInputInteger;
            int thirdInputInteger;
            int fourthInputInteger;

            //Inittialize variables
            operationString = "";
            firstInputInteger = 0;
            secondInputInteger = 0;
            thirdInputInteger = 0;
            fourthInputInteger = 0;


            //Input operation
            operationString = InputOperation();
            //Input first number
            firstInputInteger = InputNumbers(1);
            //Input second number
            secondInputInteger = InputNumbers(2);
            //Input third number
            thirdInputInteger = InputNumbers(3);
            //Input fourth number
            fourthInputInteger = InputNumbers(4);


            CalculateNumbers(operationString, firstInputInteger, secondInputInteger, thirdInputInteger, fourthInputInteger);

            Console.ReadLine();

        }
    }
}
