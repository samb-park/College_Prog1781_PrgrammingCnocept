/*
 Program ID: inClass5

 Purpose: reverse an entered name, and check the last digit from a Credit Card number, validating the information.

 Revision History:
    created Nov 2020 by Arthur Foizer, Daniel Guilmette and Sangbong Park.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inClass5
{
    class Program
    {
        //Method for reversing an entered string.
        public static string UserNameReversing(string userName)
        {
            //Builds a Char Array, and includes each character of the entered String into an Array bucket.
            char[] charArray = userName.ToCharArray();
            //Array.Reverse is a property that reverses the elements inside of an Array.
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void Main(string[] args)
        {
            //Declaring Variables
            string userName;
            string credCardString;
            string credCardResultString;
            int enteredDigtNumber;
            int calculatedDigtNumber;
            int sumDigtNumber;
            bool flag;

            //Initializing Variables
            userName = "";
            credCardString = "";
            credCardResultString = "";
            enteredDigtNumber = 0;
            calculatedDigtNumber = 0;
            sumDigtNumber = 0;
            flag = false;

            //Prompts the user for entering their full name, and calls the UserNameReversing Method to invert it.
            Console.WriteLine("NAME INVERTER\n");
            Console.Write("Please enter your full name (separate the names with a SPACE): ");
            userName = Console.ReadLine();

            Console.WriteLine("\n" + UserNameReversing(userName));

            Console.WriteLine("\n=====================================================================================================================");
            Console.WriteLine("\nCREDIT CARD VALIDATOR\n");

            //Validating a input credit card number.
            do
            {
                flag = false;
                try
                {
                    //Prompts the user for entering their credic card number.
                    Console.Write("Please enter your Credit Card Number (All 16 numerical digits with NO SPACE in between them!): ");
                    credCardString = Console.ReadLine();
                    flag = true;

                    //Chacks if the entered credit card number contains valid information.
                    if (credCardString.Length != 16)
                    {
                        Console.WriteLine("ERROR! Please enter a valid credit card number (Must strictly contain 16 numeric digits, removing ALL SPACES in between the numbers!!\n");
                        flag = false;
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("ERROR! Please enter a valid credit card number (If so, please remember to remove ALL SPACES in between the numbers!!)");
                }

                catch (Exception)
                {
                    Console.WriteLine("ERROR! Something went wrong! :(");
                }

            } while (!flag);

            
            try
            {
                int[] credCardArray;
                credCardArray = new int[credCardString.Length];
                //The 16th digit is not included in the mathematical operation (since it is the Check Digit itself).
                enteredDigtNumber = int.Parse(credCardString[credCardString.Length - 1].ToString());

                for (int i = 0; i < credCardArray.Length - 1; i++)
                {

                    credCardArray[i] = int.Parse(credCardString[i].ToString());

                    //if the number is inside of an even index bucket, its value is multiplied by 2.
                    if (i % 2 == 0)
                    {
                        credCardArray[i] = credCardArray[i] * 2;
                    }

                    //if the number is inside of an odd index bucket, its value doesn't change.
                    else
                    {
                        credCardArray[i] = credCardArray[i];
                    }

                    //Put all of the numbers into credCardResultString.
                    credCardResultString += credCardArray[i].ToString();
                }

                //Parses each number from a String to an Integer variable.
                for (int i = 0; i < credCardResultString.Length; i++)
                {
                    //Sums all of the numbers
                    sumDigtNumber += int.Parse(credCardResultString[i].ToString());
                }

                //The Check Digit is the remainder of the division of the previous sum by 10, subtracted from 10.
                calculatedDigtNumber = (10 - (sumDigtNumber % 10));

                //Returns to the user the calculated Check Digit Number and the entered Last Digit Number.
                Console.Write("\nCalcaulted Digit Number : " + calculatedDigtNumber + ", Entered Digit Number : " + enteredDigtNumber);

                //If the calculated digit and the entered last digit match, the credit card number is valid.
                if (calculatedDigtNumber == enteredDigtNumber)
                {
                    Console.WriteLine("\nYou Credit Card Information is Valid!! :)");
                }

                //If the calculated digit and the entered last digit do not match, the credit card number is invalid.
                else
                {
                    Console.WriteLine("\nYou Credit Card Information is Invalid!! :(");
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("ERROR! Please enter a valid credit card number!!");
            }

            catch (Exception)
            {
                Console.WriteLine("ERROR! Something went wrong! :(");
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}