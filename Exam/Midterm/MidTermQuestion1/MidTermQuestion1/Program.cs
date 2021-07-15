/*
 * Program Id : MidTermQuestion1
 *
 * Purpose : To test midterm question 1
 * 
 * Revision History:
 * created Nevember 2020 by Sangbong Park
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermQuestion1
{
	class Program
	{
		static void Main(string[] args)
		{
			//Declear variables
			string firstNameString;
			string lastNameString;

			string firstNumberString;
			string secondNumberString;
			double firstNumberDouble;
			double secondNumberDouble;

			string optionString;
			

			bool retryOptionBoolean;
			bool repeatProcessBoolean;
			string repeatString;

			double resultDouble;

			//Initialize variables
			firstNameString = "";
			lastNameString = "";

			firstNumberString = "";
			secondNumberString = "";
			firstNumberDouble = 0;
			secondNumberDouble = 0;

			optionString = "";

			resultDouble = 0;
			retryOptionBoolean = true;
			repeatProcessBoolean = true;
			repeatString = "";


			do
			{
				try
				{
					Console.Write("Please enter your first name : ");
					firstNameString = Console.ReadLine();
					retryOptionBoolean = false;
				}
				catch (Exception)
				{
					Console.WriteLine("Error : you entered invalid first name.(" + firstNameString + ") please enter proper first name");
				}
			}
			while (retryOptionBoolean == true);
			retryOptionBoolean = true;
			do
			{
				try
				{
					Console.Write("Please enter your last name : ");
					lastNameString = Console.ReadLine();
					retryOptionBoolean = false;
				}
				catch (Exception)
				{
					Console.WriteLine("Error : you entered invalid last name.(" + lastNameString + ") please enter proper first name");
				}
			}
			while (retryOptionBoolean == true);

			retryOptionBoolean = true;
			
			while(repeatProcessBoolean == true)
			{

				retryOptionBoolean = true;
				//choose first number
				do
				{
					try
					{
						Console.Write("Please enter the first number less than 500 : ");
						firstNumberString = Console.ReadLine();
						firstNumberDouble = double.Parse(firstNumberString);

						if (firstNumberDouble > 500)
						{
							throw new OverflowException();
						}

						retryOptionBoolean = false;
					}
					catch (FormatException)
					{
						Console.WriteLine("Error : Please re-enter the correct number. You entered invalid input ( User Input : \"" + firstNumberString + " \" )");
					}
					catch (OverflowException)
					{
						Console.WriteLine("Error : Please re-enter the correct number. You entered the number which is the out range\"( " + firstNumberString + " )\"");
					}
					catch (Exception)
					{
						Console.WriteLine("Error : Please re-enter the correct number. You entered unexpected input \"( " + firstNumberString + " )\"");
					}
				}
				while (retryOptionBoolean == true);

				retryOptionBoolean = true;

				//Choose second number
				do
				{
					try
					{
						Console.Write("Please enter the second number less than 500 : ");
						secondNumberString = Console.ReadLine();
						secondNumberDouble = int.Parse(secondNumberString);

						if (secondNumberDouble > 500)
						{
							throw new OverflowException();
						}

						retryOptionBoolean = false;
					}
					catch (FormatException)
					{
						Console.WriteLine("Error : Please re-enter the correct number. You entered invalid input ( User Input : \"" + secondNumberString + " \" )");
					}
					catch (OverflowException)
					{
						Console.WriteLine("Error : Please re-enter the correct number. You entered the number which is the out range\"( " + secondNumberString + " )\"");
					}
					catch (Exception)
					{
						Console.WriteLine("Error : Please re-enter the correct number. You entered unexpected input \"( " + secondNumberString + " )\"");
					}
				}
				while (retryOptionBoolean == true);

				retryOptionBoolean = true;
				Console.WriteLine();

				// Choose operation
				do
				{
					try
					{
						Console.WriteLine("1. add both numbers");
						Console.WriteLine("2. multyply both numbers");
						Console.WriteLine("3. divide the second number by the first");
						Console.WriteLine("4. subtract the first number from the second");
						Console.Write("Please choose the one option ( 1 ~ 4 or + , - , * , / ) : ");
										
						optionString = Console.ReadLine();

						if( optionString == "1" || optionString == "+")
						{
							resultDouble = firstNumberDouble + secondNumberDouble;
						}
						else if (optionString == "2" || optionString == "*")
						{
							resultDouble = firstNumberDouble * secondNumberDouble;
						}
						else if (optionString == "3" || optionString == "/")
						{
							if (firstNumberDouble == 0)
							{
								throw new DivideByZeroException();
							}
							resultDouble = secondNumberDouble / firstNumberDouble;
						}
						else if (optionString == "4" || optionString == "-")
						{
							resultDouble = secondNumberDouble - firstNumberDouble;
						}
						else
						{
							throw new Exception();
						}

						retryOptionBoolean = false;
					}
					catch (DivideByZeroException)
					{
						Console.WriteLine("Error : First number is zero. please re-enter other operation. user input for first number is " + firstNumberDouble);
					}
					catch (Exception)
					{
						Console.WriteLine("Error : Please re-enter the from 1 to 4 or operation. You entered invalid input \"( " + optionString + " )\"");
					}
				
				}
				while (retryOptionBoolean == true);

				if(resultDouble > 50)
				{
					resultDouble = resultDouble / 2 - 4;
				}
				else if(resultDouble < 50 && resultDouble > 10){
					resultDouble = resultDouble / 7 + 2;
				}
				// Result
				Console.WriteLine("Hello " + firstNameString + " " + lastNameString + ". Your answer is " + resultDouble);

				// Choose repeat
				Console.WriteLine();
				Console.WriteLine("1. Exit (enter \"END\")");
				Console.WriteLine("2. Repeat (enter)");
				Console.WriteLine("Please enter \"END\" or any key : ");
				repeatString =  Console.ReadLine();
				switch (repeatString)
				{
					case "END":
					case "End":
					case "end":
						repeatProcessBoolean = false;
						break;
					default:
						break;

				}

			}
			Console.WriteLine("Thank you. Have a great day");
			Console.ReadLine();
		}
	}
}
