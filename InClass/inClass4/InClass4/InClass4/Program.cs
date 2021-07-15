/*
 * Program ID : InClass4
 * 
 * Purpose : Pratice Arrays
 * 
 * Revision History:
 * created Oct 2020 by Sangbong Park
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass4
{
	class Program
	{
		static void Main(string[] args)
		{
			//Declare variables

			string[] groceryNames = new string[7];
			int[] groceryQuantities = new int[7];


			for(int i = 0; i<groceryNames.Length; i++)
			{
				Console.Write("Please Enter the an Item : ");
				groceryNames[i] = Console.ReadLine();
			}

			for (int i = 0; i < groceryNames.Length; i++)
			{
				Console.WriteLine((i + 1) + ".your have entered : " + groceryNames[i]);
				Console.Write("Please enter the quantity you wish to purchase:  ");
				groceryQuantities[i] = int.Parse(Console.ReadLine());
			}

			for (int i = 0; i < groceryNames.Length; i++)
			{
				Console.WriteLine(i + 1 + "." + groceryNames[i] + " Quantity : " + groceryQuantities[i]);

			}
		}
	}
}
