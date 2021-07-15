/*
 * Program ID : InClassAssisments3
 * 
 * Purpose: To program overload and method
 * 
 * Revision History:
 *		created in Oct. Connie Kennedy, Kyle Macdougal and Sangbong Park
 *		Team Members are: Connie Kennedy.
 *						  Kyle Macdougal.
 *						  Sangbong Park.
 *		
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassAssisments3
{
	class Program
	{
		//Adding four numbers then multiply by 7
		static int Method(int number1Integer, int number2Integer, int number3Integer, int number4Integer)
		{
			return (number1Integer + number2Integer + number3Integer + number4Integer) * 7;
		}
		//Dividing two numbers
		static int Method(int number1Integer, int number2Integer)
		{
			return (number1Integer / number2Integer);
		}
		//Multiply three number tehn divide by two
		static int Method(int number1Integer, int number2Integer, int number3Integer)
		{
			return (number1Integer * number2Integer * number3Integer) / 2;
		}
		//Join two string
		static string Method(string firstString, string lastString)
		{
			return (firstString + " " + lastString);
		}

		static void Main(string[] args)
		{
			//Declearing variables.
			int number1Integer;
			int number2Integer;
			int number3Integer;
			int number4Integer;

			string firstString;
			string lastString;

			////initialize variables
			number1Integer = 0;
			number2Integer = 0;
			number3Integer = 0;
			number4Integer = 0;

			Console.Write("Enter a number1: ");
			number1Integer = int.Parse(Console.ReadLine());
			Console.Write("Enter a number2: ");
			number2Integer = int.Parse(Console.ReadLine());
			Console.Write("Enter a number3: ");
			number3Integer = int.Parse(Console.ReadLine());
			Console.Write("Enter a number4: ");
			number4Integer = int.Parse(Console.ReadLine());

			Console.Write("Enter your fist name: ");
			firstString = (Console.ReadLine());
			Console.Write("Enter your last name: ");
			lastString = (Console.ReadLine());

			Console.WriteLine("Result of question1 :" + Method(number1Integer, number2Integer, number3Integer, number4Integer));
			Console.WriteLine("Result of question2 :" + Method(number1Integer, number2Integer));
			Console.WriteLine("Result of question3 :" + Method(number1Integer, number2Integer, number3Integer));
			Console.WriteLine("Result of question4 :" + Method(firstString, lastString));

			Console.ReadLine();
		}
	}
}
