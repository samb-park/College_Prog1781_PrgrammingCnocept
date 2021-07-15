/*
 * Program Id: A4SPADJR
 *
 * Purpose: To add, edit, display and delete stored data.
 * 
 * Revision History:
 *        created Nov 2020 by Sangbong Park
 *        
 *        Team Member: Amanpreet Kaur Dhanesar, Sangbong Park, Jireh Kwizera Rulinda
 *                
 *        Sangbong Park             : Coding, Reviewing Modification and Test Plan.
 *        Amanpreet Kaur Dhanesar   : Reviewing, Modification code and Test Plan.
 *        Jireh Kwizera Rulinda     : No response.
 *                                    We decided Jireh takes charge of the "Test Plan" part in the last class. 
 *                                    but there was no response about the "Test Plan" from Jireh after Nov 23, 
 *                                    although we have tried to contact Jireh by e-mail and zoom.
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4SPADJR
{
    class Program
    {
        //Enter brand name until it is valid.
        static string InputBrand(string[] brandSPADJR)
		{
            //declare and initilize variables.
            bool isCompletedBoolean = false;
            string inputBrandString = "";

            while (!isCompletedBoolean)
			{
                Console.Write("Please enter brand name ({0}, {1}, {2}): ", brandSPADJR[0], brandSPADJR[1], brandSPADJR[2]);
                inputBrandString = Console.ReadLine().Trim();
                inputBrandString = Char.ToUpper(inputBrandString[0])+inputBrandString.ToLower().Substring(1);

                //Check if the entered brand name is included in the Brand array.
                if (inputBrandString.ToUpper() == brandSPADJR[0].ToUpper() || inputBrandString.ToUpper() == brandSPADJR[1].ToUpper() || inputBrandString.ToUpper() == brandSPADJR[2].ToUpper())
                {
                    //Set the flag to return to the main menu.
                    isCompletedBoolean = true;
                }
                //If there is no brand name in brandArray, try to enter the brand name again.
                else
                {
                    Console.WriteLine("ERROR: Brand record not found. Please enter exist brand name ");
                }

            }
            return inputBrandString;
		}

        //Enter the size until the entered value is valid.
        static int InputSize()
		{
            //declare and initilize variables.
            bool isCompletedBoolean = false;
            string inputSizeString = "";
            int inputSizeInteger = 0;

            while (!isCompletedBoolean)
            {
				try
				{
                    Console.Write("Please enter size - Small (1), Medium (2), Large (3), XLarge (4) : ");
                    inputSizeString = Console.ReadLine().Trim();
                    inputSizeInteger = int.Parse(inputSizeString);

                    //Size is greater than 4 or less than 1, exception handling will occur
                    if (inputSizeInteger < 1 || inputSizeInteger > 4)
                    {
                        //Throw an exception error if the user enters a number less than 1 or greater than 4, then retrying to enter is required until variables are valid.
                        throw new OverflowException();
                    }
                    isCompletedBoolean = true;
                }
                //In order to handle in case of entering letter instead of the number.
                catch (FormatException)
                {
                    Console.WriteLine("ERROR : Invlid input is entered. plase enter only number for size.");
                }
                //In order to handle the valid number
                catch (OverflowException)
                {
                    Console.WriteLine("ERROR: It must be less than 4 and greater than 1");
                }
                //Handling unexpected error.
                catch (Exception)
                {
                    Console.WriteLine("ERROR : unexpected error ");
                }
            }
            return inputSizeInteger;

        }

        //check if there is available space.
        static bool CheckAvailalbeSpace(string[] storedDataArray)
		{
            //declare and initilize variables.
            bool isEmptyDataBoolean = false;
            
            //Check available space.
            for(int i = 0; i < storedDataArray.Length; i++)
			{
                if(storedDataArray[i] == "NONE")
				{
                    isEmptyDataBoolean = true;
                    break;
                }
			}

            //If available space, return true.
            return isEmptyDataBoolean;
		}

        //Check If format is valid
        static bool CheckFormatBrandSize(string storeDataArray)
		{
            //declare and initilize variables.
            bool isValidFormat = true;
            string[] validString;

            validString = storeDataArray.Split('-');

            if(validString.Length != 2)
			{
                isValidFormat = false;
                Console.WriteLine("Invalid type of input format. It must be brand-size");
            }

            return isValidFormat;
		}

        //Add new items
        static void OperateOptionA(string[] brandSPADJR, string[] storedDataArray)
        {
            //declare and initilize variables.
            bool isCompletedBoolean = false;
            string inputBrandString = "";
            string brandAndSizeString = "";
            int inputSizeInteger = 0;

            Console.WriteLine("\n=====================================");
            Console.WriteLine("A. Add new T-Shirt details");
            Console.WriteLine("=====================================\n");

            //Loop until user enter "DONE"
            while (!isCompletedBoolean)
			{
                //Check if there are empty spaced. It is available only to save 12 data.
                if (CheckAvailalbeSpace(storedDataArray) == false)
				{
                    Console.WriteLine("ERROR : No available space to store.");
                    break;
				}

                //Request to enter brand name seperately
                inputBrandString = InputBrand(brandSPADJR);
                //Request to enter brand size seperately
                inputSizeInteger = InputSize();

                //Concattenat brand and size like (eg Fendi-1)
                brandAndSizeString = inputBrandString + "-" + inputSizeInteger;

                //Check the same condition of data.
                for (int i = 0; i<storedDataArray.Length; i++)
				{
                    //Compare stored data and entered data.
                    if(storedDataArray[i].ToUpper() == brandAndSizeString.ToUpper())
					{
                        isCompletedBoolean = false;
                        //Display “Error T-Shirt record already exists" if one was already entered and stored previously
                        Console.WriteLine("ERROR :  T - Shirt record already exists");
                        break;
					}
                    //Check stored data is "NONE".
					else if(storedDataArray[i] == "NONE")
                    {
                        //Only save name-Size in case of "NONE". Save variable in the empty position.
                        storedDataArray[i] = brandAndSizeString;

                        //Notification when the record is succeeded. 
                        Console.WriteLine("SUCCESS to Store : Index." + i + ", Name : " + brandAndSizeString);
                        break;
                    }
				}

                Console.WriteLine("\nIf you want to finish to add items, Please enter \"DONE\"");

                //Check if user enter "DONE" to exit
                if(Console.ReadLine().Trim().ToUpper() == "DONE")
                {
                    isCompletedBoolean = true;
                }
                else
                {
                    isCompletedBoolean = false;
                }

                Console.WriteLine();
            }
        }

        //Edit records
        static void OperateOptionB(string[] brandSPADJR, string[] storedDataArray)
        {
            //declare and initilize variables.
            bool isCompletedBoolean = false;
            bool isFoundStoredDataBoolean = false;
            string inputBrandString = "";
            string brandAndSizeString = "";
            int inputSizeInteger = 0;

            Console.WriteLine("\n=====================================");
            Console.WriteLine("B. Edit existing T-Shirt details ");
            Console.WriteLine("=====================================\n");

            while (!isCompletedBoolean)
			{
                Console.Write("Please Enter Brand and Size to modify ( Eg - Fend-1 ) : ");
                brandAndSizeString = Console.ReadLine().Trim();

                //Ask if user input is valid. It must be brand-size.
                if (CheckFormatBrandSize(brandAndSizeString)){
                    for (int i = 0; i < storedDataArray.Length; i++)
                    {
                        //Compare record and user input then display message
                        if (storedDataArray[i].ToUpper() == brandAndSizeString.ToUpper())
                        {
                            //Display and prompt new value.
                            Console.WriteLine("please enter updated information");
                            //Request to enter size and brand separately.
                            inputBrandString = InputBrand(brandSPADJR);
                            inputSizeInteger = InputSize();

                            //Combine separated size and brand such as brand-size.
                            brandAndSizeString = inputBrandString + "-" + inputSizeInteger;

                            //Replace new value to the same position.
                            storedDataArray[i] = brandAndSizeString;
                            Console.WriteLine("SUCCESS to update : Store date in Index[{0}] is updated to " + brandAndSizeString, i);

                            isCompletedBoolean = true;
                            isFoundStoredDataBoolean = true;
                            break;
                        }
                    }

                    //In case of no record exsit, display message
                    if (isFoundStoredDataBoolean == false)
                    {
                        Console.WriteLine("Brand record not found for that entry");
                    }
				}
            }
        }

        //Display all of the records 
        static void OperateOptionC(string[] storedDataArray)
        {
            //declare and initilize variables.
            int indexInteger = 0;
            string[] splitString;

            Console.WriteLine("\n=====================================");
            Console.WriteLine("C. Display all T-Shirts in store ");
            Console.WriteLine("=====================================\n");
            Console.WriteLine("INDEX\t\tBRAND\t\tSIZE");

			for(int i = 0; i < storedDataArray.Length; i++)
			{
                indexInteger = storedDataArray[i].IndexOf('-');
                if(indexInteger != -1)
				{
                    splitString = storedDataArray[i].Split('-');

					Console.WriteLine("  " + i + "\t\t" + splitString[0] + "\t\t " + splitString[1]);
                }
				else
				{
                    Console.WriteLine("  " + i + "\t\t" + "NONE" + "\t\t" + "NONE");
                }
            }
            //All records are displayed
            Console.WriteLine("=====================================\n");

            Console.Write("Please enter to return to main menu ");
            //Wating for user enter to return to main menu.
            Console.ReadLine();
        }

        //Delete records
        static void OperateOptionD(string[] brandSPADJR, string[] storedDataArray)
        {
            //declare and initilize variables.
            bool isCompletedBoolean = false;
            bool isFoundStoredDataBoolean = false;
            string brandAndSizeString = "";
            string decisionString = "";


            Console.WriteLine("\n=====================================");
            Console.WriteLine("D. Delete T-Shirt Information");
            Console.WriteLine("=====================================\n");

            while (!isCompletedBoolean)
            { 
                Console.Write("Please Enter Brand and Size to modify ( Eg - Fend-1 ) : ");
                brandAndSizeString = Console.ReadLine().Trim();

                // Check if user input is a valid format.
                if (CheckFormatBrandSize(brandAndSizeString))
				{
                    for (int i = 0; i < storedDataArray.Length; i++)
                    {
                        //Compre new values and record if they are the same.
                        if (storedDataArray[i].ToUpper() == brandAndSizeString.ToUpper())
                        {
                            //Display message to decide to delete records.
                            Console.Write("Brand information found are you sure you want to delete Y/N  : ");
                            decisionString = Console.ReadLine().Trim().ToUpper();
                            //In case of Y. record is replaced to "NONE"
                            if (decisionString == "Y")
                            {
                                Console.WriteLine("Data is deleted in index[" + i + "]");
                                storedDataArray[i] = "NONE";
                            }
                            else if (decisionString == "N")
							{
                                Console.WriteLine("Returning to main menu.");
                            }
							else
							{
                                Console.WriteLine("Invalid input entered.");
							}

                            isCompletedBoolean = true;
                            isFoundStoredDataBoolean = true;
                            break;
                        }
                    }

                    if (isFoundStoredDataBoolean == false)
                    {
                        Console.WriteLine("Brand record not found for that entry");
                    }
                }
            }
            Console.ReadLine();
        }

        //Disply and check input string for menu
        public static string SelectOption()
        {
            //Declare and Initilize Variables
            bool retryBoolean = true;
            string optionString = "";

            while (retryBoolean)
            {
                try
                {
                    //Display menu to select a option
                    Console.WriteLine("\n=====================================");
                    Console.WriteLine("A. Add new T-Shirt details");
                    Console.WriteLine("B. Edit existing T-Shirt details ");
                    Console.WriteLine("C. Display all T-Shirts in store ");
                    Console.WriteLine("D. Delete T-Shirt Information");
                    Console.WriteLine("E. Exit the program");
                    Console.WriteLine("=====================================\n");
                    Console.Write("Please select one option ( \"A\" to \"E\" ) : ");

                    optionString = Console.ReadLine().Trim().ToUpper();

                    //If letters are greater than 2, It will be a decided error. Input is only available A to E.
                    if (optionString.Length >= 2)
                    {
                        throw new FormatException("String Length is more than 2. Please enter A to E");
                    }
                    //Cehck if it is valid alpbat
                    else if (char.IsLetter(optionString, 0) != true)
                    {
                        throw new FormatException("Entered string is not alphabat. Please enter A to E");
                    }
                    else
                    {
                        retryBoolean = false;
                    }
                }
				catch(FormatException error){
                    Console.WriteLine("ERROR : " + error.Message);
                }
                catch (Exception error)
                {
                    Console.WriteLine("ERROR : " + error.Message);
                }
            }
            return optionString;
        }

        // Get three brands
        static void SetThreeBrand(string [] brandSPADJR)
		{
            //declare and initialize variables.
            string temporaryString = "";

            for (int index = 0; index < 3;)
            {
                Console.Write("Please enter brand " + (index + 1) + ": ");
                brandSPADJR[index] = Console.ReadLine().Trim();
                temporaryString = brandSPADJR[index];
                brandSPADJR[index] = char.ToUpper(temporaryString[0])+ temporaryString.Substring(1);

                //if '-' is contained in the string, retrying input is required to avoid an error.
                if (brandSPADJR[index].Contains('-'))
				{
                    Console.WriteLine("Please do not use this \'-\' ");
                    continue;
				}

                switch(index)
				{   
                    case 1:
                        if(brandSPADJR[0] == brandSPADJR[1])
						{
                            Console.WriteLine("Please re-enter another name for brand 2 ");
                            continue;
						}
                        break;
                    case 2:
                        if ((brandSPADJR[0] == brandSPADJR[2]) || (brandSPADJR[1] == brandSPADJR[2]))
                        {
                            Console.WriteLine("Please re-enter another name for brand 3 ");
                            continue;
                        }
                        break;
                }

                index++;
            }
        }

        //Main Method
        static void Main(string[] args)
        {
            //Declare and initialize variables
            string[] brandSPADJR = new string[3] { "", "", "" };
            string[] storedDataArray = new string[12] { "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE", "NONE" };
            string optionString = "";
            bool retryBoolean = true;      

            //Set three brand name by using for loop.
            SetThreeBrand(brandSPADJR);
            while (retryBoolean)
            {
                try
                {
                    //Call Menu Method. In this method, it checks the user input and returns the option string.
                    optionString = SelectOption();

                    switch (optionString)
                    {
                        case "A":
                            //Option A : Add new T-Shirt details.
                            OperateOptionA(brandSPADJR, storedDataArray);
                            break;
                        case "B":
                            //Option B : Edit existing T-Shirt details (Brand Name & Size)
                            OperateOptionB(brandSPADJR, storedDataArray);
                            break;
                        case "C":
                            //OPtion C : Display all T-Shirts in store (display the Brand Name & Size)
                            OperateOptionC(storedDataArray);
                            break;
                        case "D":
                            //Option D : Delete T-Shirt Information
                            OperateOptionD(brandSPADJR, storedDataArray);
                            break;
                        case "E":
                            //OPtion E : Exit the program
                            retryBoolean = false;
                            break;
                        default:
                            //If there is no option as user choose, It will handled by exception.
                            throw new FormatException("Please enter A to E\n");
                    }
                }
				catch (FormatException error)
				{
                    Console.WriteLine("ERROR : " + error.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR : Unexpected Error" );
                }
            }
            Console.WriteLine("\nThank you. Have a greate day.");
            Console.ReadLine();
        }
        int a;
    }
}
