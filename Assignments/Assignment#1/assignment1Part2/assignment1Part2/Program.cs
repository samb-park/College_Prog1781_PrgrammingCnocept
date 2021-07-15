/*
 * Program ID : Assignments1Part2
 * 
 * Purpose : To do assignments part2
 * 
 * Revision History:
 *		created Sept 2020 by S.Park
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1Part2
{
	class Program
	{
		static void Main(string[] args)
        {
            //declear variables.
            string operationString;
            string num1String;
            string num2String;
            string num3String;
            string num4String;

            double num1Double;
            double num2Double;
            double num3Double;
            double num4Double;
            double resultDouble;



            //initialize variables.
            operationString = "";
            num1String = "";
            num2String = "";
            num3String = "";
            num4String = "";

            num1Double = 0;
            num2Double = 0;
            num3Double = 0;
            num4Double = 0;
            resultDouble = 0;

            try
            {
                Console.Write("Enter operation ( + , - , * , / ) : ");
                operationString = Console.ReadLine();
                Console.Write("Enter number1 : ");
                num1String = Console.ReadLine();
                Console.Write("Enter number2 : ");
                num2String = Console.ReadLine();
                Console.Write("Enter number3 : ");
                num3String = Console.ReadLine();
                Console.Write("Enter number4 : ");
                num4String = Console.ReadLine();

                num1Double = double.Parse(num1String);
                num2Double = double.Parse(num2String);
                num3Double = double.Parse(num3String);
                num4Double = double.Parse(num4String);

                switch (operationString)
                {
                    case "+":
                        //Add all numbers
                        resultDouble = num1Double + num2Double + num3Double + num4Double;
                        Console.WriteLine("Result : " + num1Double + " + " + num2Double + " + " + num3Double + " + " + num4Double + " = " + resultDouble);
                        break;
                    case "-":
                        //First number - third number
                        resultDouble = num1Double - num3Double;
                        Console.WriteLine("Result : " + num1Double + " - " + num3Double + " = " + resultDouble);

                        break;
                    case "*":
                        //first * third
                        resultDouble = num1Double * num3Double;
                        Console.WriteLine("Result : " + num1Double + " * " + num3Double + " = " + resultDouble);
                        break;
                    case "/":
                        // fourth Num / (First Num + Second Num)
                        if ((num1Double + num2Double) == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        else
                        {
                            resultDouble = num4Double / (num1Double + num2Double);
                            Console.WriteLine("Result : " + num4Double + " / (" + num1Double + "+" + num3Double + ") = " + resultDouble);
                        }
                        break;
                    default:
                        // Error handling1 - Check operations
                        throw new Exception("Error handling : operation must be \"+,-,* or / \"");
                }
            }
            catch (FormatException e)
            {
                //Error handling2 - Check if numbers is valid
                Console.WriteLine("Error handling : " + e.Message);
            }
            catch (DivideByZeroException)
            {
                //Error handling3 - Check if numbers is valid
                Console.WriteLine("Error handling : Divided by zero");
            }
            catch (OverflowException e)
            {
                //Error handling4 - Check if varialbe is out of range.
                Console.WriteLine("Error handling : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}




