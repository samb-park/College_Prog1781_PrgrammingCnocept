/*
 * Program Id : Assignment2 Part1
 *
 * Purpose : Calculate taxes depending on age and month
 * 
 * Revision History:
 * created Oct 2020 by S. Park
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SangbongParkP1
{
	class Program
	{
		//Step1 : Calculate reg fee: Input : Age Output : Reg Fee
		static double CalculateRegFee(int ageInteger)
		{
			double rValueDouble = 0;
			if (ageInteger <= 19 && ageInteger >= 0) rValueDouble = 37;
			else if (ageInteger <= 29 && ageInteger >= 20) rValueDouble = 50;
			else if (ageInteger <= 64 && ageInteger >= 30) rValueDouble = 53.50;
			else if (ageInteger >= 65) rValueDouble = 0;
			else { Console.WriteLine("Error : Wrong speeling"); }
				return rValueDouble;
		}

		// Get currency and check speeling - input : various currency string, output : CAPITAL currency string
		static string InputCurrency(string inputString)
		{
			string rValueString = "";
			if (inputString == "USD" || inputString == "usd") rValueString = " USD";
			else if (inputString == "CAD" || inputString == "cad") rValueString = " CAD";
			else if (inputString == "BITCOIN" || inputString == "bitcoin") rValueString = " BITCOIN";
			else { Console.WriteLine("Error : Wrong speeling"); }

			return rValueString;
		}

		// Get currency and check speeling : input Y or N String, Output deduction value
		static double InputExistingClient(string inputString)
		{
			double rValueDouble = 0;
			if (inputString == "y" || inputString == "Y" || inputString == "yes" || inputString == "YES") rValueDouble = 50;
			else if (inputString == "n" || inputString == "N" || inputString == "no" || inputString == "NO") rValueDouble = 0;
			else Console.WriteLine("Error : Wrong speeling");

			return rValueDouble;
		}

		//Get monthstring : input month string. output Step case value
		static string InputMonth(string inputString)
		{
			string rValueString = "";

			switch (inputString)
			{
				case "Jan":		case "January":		case "jan":	case "1": 
				case "Feb":		case "February":	case "feb":	case "2": 
				case "Mar":		case "March":		case "mar":case "3":
				case "Apr":		case "April":		case "4":
					rValueString = "4";
					break;
				case "May":		case "5":
					rValueString = "5";
					break;
				case "Jun":		case "June":		case "6":
				case "Jul":		case "July":		case "7":
				case "Aug":		case "August":		case "8":
				case "Sep":		case "September":	case "9":
				case "Oct":		case "October":		case "10":
				case "Nov":		case "November":	case "11":
				case "Dec":		case "December":	case "12":
					break;
				default:
					Console.WriteLine("Error : Wrong speeling");
					break;
			}
			return rValueString;
		}

		static void Main(string[] args)
		{
			//Declearing variables
			//For Step1
			int		ageInteger;
			double requiredTaxDouble;
			double regFeeDouble;
			double deductedPrice;
			String currencyString;
			//For Step2
			string registrationMonthString;
			string inputMonthString;
			string applicableString;
			double adjustFeeInMayDouble;
			double adjustFeeInToAprilDouble;
			//For Step3
			double finalFeeDouble;
			double addTaxDouble;
			double hstTaxDouble;
			double totalResultDouble;

			// Initializaing variables
			ageInteger = 0;
			requiredTaxDouble = 0;
			regFeeDouble = 0;
			deductedPrice = 0;
			currencyString = "";
			
			registrationMonthString = "";
			inputMonthString = "";
			applicableString = "";
			adjustFeeInMayDouble = 0;
			adjustFeeInToAprilDouble = 0;
			
			finalFeeDouble = 0;
			addTaxDouble = 0;
			hstTaxDouble = 0;
			totalResultDouble = 0;

			//Input applicant age
			Console.Write("Enter applicant's age ( 0 ~ ): ");
			ageInteger = int.Parse(Console.ReadLine());

			//Input currency
			Console.Write("Enter preferred currency ( Only available USD, CAD or BITCOIN ) : ");
			currencyString = InputCurrency(Console.ReadLine());
			Console.WriteLine();
			currencyString = " " + currencyString;
				

			//Input existing client
			Console.Write("Are you reffered by an existing client (y/n) : ");
			deductedPrice = InputExistingClient(Console.ReadLine());

			//Input registration month.
			Console.Write("Enther registeration month ( ex - Jan, January or 1 ): ");
			inputMonthString = Console.ReadLine();
			registrationMonthString = InputMonth(inputMonthString);

			//Step1 : Caculate Reg Fee
			regFeeDouble = CalculateRegFee(ageInteger );
			requiredTaxDouble = Convert.ToDouble(regFeeDouble != 37);


			//Step2 : Find AdjustableFee
			applicableString = "It is not requried.";// from Jun to Dec
			switch (registrationMonthString)
			{
				case "4":   //From Jan to Apr. $ 2 subscription
					adjustFeeInToAprilDouble = -2;
					applicableString = "2 " +currencyString + " will subtract from the final fee including tax.";
					break;
				case "5":	//May. $25 will be added
					adjustFeeInMayDouble = 25;
					applicableString = "25" + currencyString + " will add to final fee.";
					break;
			}

			//Step3 : Cacluate Additional Tax, HST and total result
			finalFeeDouble = (regFeeDouble + adjustFeeInMayDouble - deductedPrice);                      // adjustFeeInMayDouble will be added in case of may
			if (finalFeeDouble <= 0) finalFeeDouble = 0;														// iF it is lower than final fee makes to 0
			addTaxDouble = (finalFeeDouble * 0.09) * requiredTaxDouble;                                  // requiredTaxDouble makes result to zero if age is unde than 19
			hstTaxDouble = ((finalFeeDouble + finalFeeDouble * 0.09) * 0.13) * requiredTaxDouble;        // requiredTaxDouble makes result to zero if age is unde than 19
			totalResultDouble = finalFeeDouble + addTaxDouble + hstTaxDouble + adjustFeeInToAprilDouble;	// total reulst
			if (ageInteger >= 65) finalFeeDouble = addTaxDouble = hstTaxDouble = totalResultDouble = 0;			// lager than 65. all of thing will be zero
			if (totalResultDouble <= 0) totalResultDouble = 0;													

			//Display results
			Console.WriteLine("------------------------------------------------------------------");
			Console.WriteLine("DISPLAY ");
			Console.WriteLine("------------------------------------------------------------------");
			Console.WriteLine("The Applicant's age : " + ageInteger);
			Console.WriteLine("Registration Month : " + inputMonthString);
			Console.WriteLine("Were they referred : " + (deductedPrice == 50));
			Console.WriteLine("------------------------------------------------------------------");
			Console.WriteLine("Reg. fee before adjustment : " + regFeeDouble + currencyString);
			Console.WriteLine("Total adjustment : " + applicableString);
			Console.WriteLine("Total Tax : "+ (hstTaxDouble + addTaxDouble)+ currencyString + "Additional Tax(9%) : " + addTaxDouble + currencyString+", HST : " +hstTaxDouble + currencyString);
			Console.WriteLine("------------------------------------------------------------------");
			Console.WriteLine("Total amount with tax and hst : " + totalResultDouble + currencyString);
			Console.WriteLine("------------------------------------------------------------------\n");

			Console.WriteLine("\nThanks for reviewing. Have a great day.");
			Console.Read();

			
		}
	}
}
