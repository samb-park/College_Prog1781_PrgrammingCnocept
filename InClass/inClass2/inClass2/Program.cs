/*
 * Program ID : inClass2
 * 
 * Purpose : To discuss inClass2
 * 
 * Revision History:
 *	created by S.Park Sept 2020
 *	
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace inClass2
{
	class Program
	{
		static void Main(string[] args)
		{
			//Declear and initialize variables.
			string num1String = Console.ReadLine();
			string num2String = Console.ReadLine();
			string num3String = Console.ReadLine();
			string num4String = Console.ReadLine();
			string num5String = Console.ReadLine();

			double num1Double = double.Parse(num1String);
			double num2Double = double.Parse(num2String);
			double num3Double = double.Parse(num3String);
			double num4Double = double.Parse(num4String);
			double num5Double = double.Parse(num5String);

			int firstFourInt = (int)(num1Double + num2Double + num3Double + num4Double);
			int lastTwoInt = (int)(num4Double + num5Double);

			int resultInt = firstFourInt * lastTwoInt;
			int subtractInt = firstFourInt - (int)num5Double;

			Console.WriteLine("Final Result: " + subtractInt);
		}

	}
}
