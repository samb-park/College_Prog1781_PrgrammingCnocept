/*
 * Name : Sangbong Park
 * Student ID : spark2765
 * Student No : 8692765
 * 
 * Program Id: Utility.cs
 *
 * Purpose: To adjust string.
 * 
 * Revision History:
 *        created Dec 2020 by Sangbong Park
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangbongPark
{

	//Create a class with a name of “utility”
	class Utility
	{

		//constructors created.
		public Utility()
		{
			//default constructor.
		}

		//generate a method called StringOperations that accepts and evaluates a string.  
		static public string StringOperations(string inputString)
		{
			//Initialize and declare variables
			string outputString = inputString;
			bool retryOption = true;
			int position = 0;

			//Find and remove the following characters “#” and “!” from the string
			while (retryOption)
			{
				//check if there is "!"
				position = outputString.IndexOf('!');
				if (position != -1)
				{
					//remove "!"
					outputString = outputString.Remove(position, 1);
				}

				//check if there is "#"
				position = outputString.IndexOf('#');
				if (position == -1)
				{
					break;
				}
				else
				{
					//remove "#"
					outputString = outputString.Remove(position, 1);
				}

			}


			//return the string without “#” and “!”.
			return outputString;
		}


	}
}
