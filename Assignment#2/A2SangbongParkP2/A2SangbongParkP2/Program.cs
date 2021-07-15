/*
 * Program ID : Assignment#2
 * 
 * Purpose: To calcuate square, triangle, cube and sphere by using methods and overload.
 * 
 * Revision History:
 *		created in Oct. Sangbong Park
 *		
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SangbongParkP2
{
	class Program
	{
		const float PI = 3.14159f;
		//Calculate a square
		static void CalculateFigures(double lengthDouble)
		{
			Console.WriteLine("Area of a square : " + lengthDouble * lengthDouble);
		}
		//Calculate a triangle
		static void CalculateFigures(double baseDouble, double heightDouble)
		{
			Console.WriteLine("Area of a triangle : " + baseDouble * heightDouble / 2);
		}
		//Calculate a cube
		static void CalculateFigures(double lengthDouble, double heightDouble, double widthDouble)
		{
			Console.WriteLine("Volume of a cube : " + lengthDouble * heightDouble * widthDouble);
		}
		//Calculate a sphere 
		static void CalculateFigures(double number,  float PI, double radiusDouble)
		{
			Console.WriteLine("Volume of a sphere  : " + number * PI *radiusDouble*radiusDouble* radiusDouble);
		}
		static void Main(string[] args)
		{
			//Declearing variables
			double lengthDouble;
			double baseDouble;
			double heightDouble;
			double widthDouble;
			double radiusDouble;

			// Initializing variables.
			lengthDouble = 0;
			baseDouble = 0;
			heightDouble = 0;
			widthDouble = 0;
			radiusDouble = 0;

			Console.Write("Select an option to calculate a figure(1. Square, 2. Triangle, 3.Cube 4. Sphere) : ");

			//Select an option
			switch (int.Parse(Console.ReadLine()))
			{
				// Square
				case 
				case 1:
					Console.Write("Enter a length : ");
					lengthDouble = double.Parse(Console.ReadLine());
					CalculateFigures(lengthDouble);
					break;
				// Triangle
				case 2:
					Console.Write("Enter a base : ");
					baseDouble = double.Parse(Console.ReadLine());
					
					Console.Write("Enter a height : ");
					heightDouble = double.Parse(Console.ReadLine());
					
					CalculateFigures(baseDouble, heightDouble);
					break;
				// Cube
				case 3:
					Console.Write("Enter a length : ");
					lengthDouble = double.Parse(Console.ReadLine());

					Console.Write("Enter a width : ");
					widthDouble = double.Parse(Console.ReadLine());

					Console.Write("Enter a height : ");
					heightDouble = double.Parse(Console.ReadLine());

					CalculateFigures(lengthDouble, heightDouble, widthDouble);
					break;
				// Sphere
				case 4:
					Console.Write("Enter a radius : ");
					radiusDouble = double.Parse(Console.ReadLine());
					CalculateFigures((double)4/3,PI,radiusDouble);
					break;
				default:
					Console.Write("No option...");
					break;
			}

			Console.WriteLine("\nFinish. Thank you. Have a great day.");
			Console.Read();
		}
	}
}
