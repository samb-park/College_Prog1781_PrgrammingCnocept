
/*
 * Name : Sangbong Park
 * Student ID : spark2765
 * Student No : 8692765
 * 
 * Program Id: SangbongPark.cs
 *
 * Purpose: To adjust string.
 * 
 * Revision History:
 *        created Dec 2020 by Sangbong Park
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangbongPark
{
	class Program
	{
		static void Main(string[] args)
		{
			//Initialize and declare variables
			string inputString = "";
			string resultString = "";
			bool retryBoolean = true;
			string optionString = "";
			string[] storedDataArray;
			string temporaryString = "";
			bool askQuitboolen = true;
			string askQuitString = "";

			while (askQuitboolen)
			{
				while (retryBoolean)
				{
					//Request the string from the user  		
					try
					{

						//Get input
						Console.Write("Please enter any string : ");
						inputString = Console.ReadLine();

						if (inputString.Trim().Length == 0)
						{
							//If nothing entered, Display “Error Message” and repeat.
							throw new FormatException();
						}
						Console.WriteLine();

						//Display user input
						Console.WriteLine("Entered string : " + inputString);
						Console.WriteLine();

						//Ask whether user input is correct
						Console.Write("Please confirm entered string- Yes (y or Y) or No (Any string) : ");
						optionString = Console.ReadLine().Trim().ToUpper();

						//If Yes then continue, If No then reapeat from user input.
						if (optionString == "Y")
						{
							retryBoolean = false;
						}
						else if (optionString == "N")
						{
							retryBoolean = true;
						}
						Console.WriteLine();

					}
					catch (FormatException)
					{
						Console.WriteLine("ERROR : please enter any string.\n");
					}
					catch (Exception)
					{
						Console.WriteLine("ERROR : Unexpected error\n");
					}
				}
				Console.WriteLine();
				//Call the class method (StringOperations) from your main program passing the example string (from b), store the result to a variable of your choice.
				resultString = Utility.StringOperations(inputString);

				//Display the returned modified string on the screen.
				Console.WriteLine("2.a Returned Modified Result : " + resultString);

				//Copy the returned entry, from the value returned (in step  2a above), to a string array using the “,” found in the string as the delimiter.
				storedDataArray = resultString.Split(',');

				//Use a for loop to display the entries in the array that are not digits (i.e.numbers between 0 & 9).

				Console.Write("\n2.c Final Result : ");
				for (int i = 0; i < storedDataArray.Length; i++)
				{
					temporaryString = storedDataArray[i];
					for (int j = 0; j < temporaryString.Length; j++)
					{
						//Check if there is a digit in the string.
						if (char.IsDigit(temporaryString[j]))
						{

						}
						else
						{
							Console.Write(temporaryString[j]);
						}
					}
				}
				Console.WriteLine();
				Console.Write("\nIf you want to exit, please enter \"end\" : ");
				//Ask user to repeat with another string or end the program.
				askQuitString = Console.ReadLine().Trim().ToUpper();
				if(askQuitString == "END")
				{
					askQuitboolen = false;
				}
			}
			
			Console.WriteLine("\n");

			Console.WriteLine("Thank you have a great day.");
			Console.ReadLine();



		}
	}
}
