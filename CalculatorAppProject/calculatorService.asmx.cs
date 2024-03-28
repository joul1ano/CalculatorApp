using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculatorApp
{
    /// <summary>
    /// Summary description for calculatorService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    //This code represents the functionability of a simple calculator. A string representing the mathematical expression the user typed is passed as an arguement. First,
    //the string is separated into two ArrayLists, one containing the numbers of the expression and the other the operators, both of them in string format. Then the operators
    //with priority of execution are found and executed, updating the two ArrayLists respectively. Finally, the rest of the operators are executed and the result is returned.
    public class calculatorService : System.Web.Services.WebService
    {

        [WebMethod]
        public string getResult(string thePanel)
        {
            int i;
            ArrayList operators = new ArrayList();               
            ArrayList operatorsWithPriority = new ArrayList();
            string newPanel, theResult;
            bool containsAtLeastOneOperator = false;

            operators.Add("+");
            operators.Add("-");
            operators.Add("*");
            operators.Add("/");

            operatorsWithPriority.Add("*");
            operatorsWithPriority.Add("/");

            //Checking if the string passed is valid

            //Checking if the string is empty
             if (String.IsNullOrEmpty(thePanel))
             {
                 return "Invalid input: Empty Input";
             }

             //Checking if the last character is not a digit
             string r = thePanel[(thePanel.Length - 1)].ToString();
             if (operators.Contains(r))
             {
                 return "Invalid input: The last character was not a digit";
             }

             //Checking if the string starts with - . E.g. -2+3*4 -> 0-2+3*4
             if (thePanel.StartsWith("-"))
             {
                 newPanel = "0";
                 newPanel = newPanel + thePanel;
                 thePanel = newPanel;
             }

             //Checking if the string starts with an invalid symbol
             else if (thePanel.StartsWith("*") || thePanel.StartsWith("+") || thePanel.StartsWith("/"))
             {
                 return "Invalid input: Invalid starting character";
             }

             //Checking if the string contains at least one action
             for (int j = 0; j < thePanel.Length; j++)
             {
                 if (operators.Contains(thePanel[j].ToString()))
                 {
                     containsAtLeastOneOperator = true;
                 }

             }
             if (!containsAtLeastOneOperator)
             {
                 return "Invalid Input: No operators involved";
             }

             //Checking if the string contains two consecutive actions E.g. 2++5 or 7-*2
             i = 0;
             while (true)
             {
                 if (i < thePanel.Length)
                     if (operators.Contains(thePanel[i].ToString()) && operators.Contains(thePanel[i + 1].ToString())) return "Invalid Input: Two operators can not be next to each other";
                 i++;
                 if (i == thePanel.Length) break;
             }

             //Checking if there is a division with 0
             for(int z=0; z< thePanel.Length; z++)
             {
                 if(z== thePanel.Length) break;
                 if (thePanel[z].ToString().Equals("/") && thePanel[z+1].ToString().Equals("0"))
                     return "Invalid Input : Can not divide with zero";
             }

             (ArrayList, ArrayList) seperation = separateNumbersAndOperators(thePanel);

             ArrayList numbers = new ArrayList();
             ArrayList operatorsArray = new ArrayList();

             numbers = seperation.Item1;
             operatorsArray = seperation.Item2;

             (numbers,operatorsArray) = executePriorityOperations(numbers, operatorsArray);
             theResult = executeFinalOperations(numbers, operatorsArray);


            return theResult;

        }


        //This method separates the numbers from the operators of the expression and returns them into two different ArrayLists
        public (ArrayList numbers, ArrayList operators) separateNumbersAndOperators(string thePanel)
        {
            ArrayList numbers = new ArrayList();
            ArrayList operators = new ArrayList();
            string tempNumber = "";
            char c;

            for (int i = 0; i < thePanel.Length; i++)
            {
                c = char.Parse(thePanel[i].ToString());

                if (char.IsDigit(c) || c == '.')
                {
                    tempNumber += thePanel[i];
                }
                else
                {
                    if (!string.IsNullOrEmpty(tempNumber))
                    {
                        numbers.Add(tempNumber);
                        tempNumber = "";
                    }
                    operators.Add(thePanel[i].ToString());
                }
            }

            // Add the last number if there's one left after the loop
            if (!string.IsNullOrEmpty(tempNumber))
            {
                numbers.Add(tempNumber);
            }

            //If theNumbers=["4","1","13"] and theOperators=["+","*"] then the expression is 4+1*13. Meaning that the operator at position k (theOperators[k]) will be executed with
            //the numbers at position k and k+1 (theNumbers[k], theNumbers[k+1]).
            //When the first number of the expression is a positive then theNumbers.count = theOperators.count-1 else theNumbers.count = theOperators.count

            return (numbers, operators);
        }

        //This method executes the priority operators repeatedly until there is no prority operator left
        public (ArrayList theNumbers, ArrayList theOperators) executePriorityOperations(ArrayList numbers, ArrayList operators)
        {
            ArrayList theNumbers = new ArrayList();
            ArrayList theOperators = new ArrayList();
            int priorityOp=0; //Points to the position of the 1st priority operator found in theOperators ArrayList
            double num1, num2, tempResult = 0;

            theNumbers = numbers; //Creating a copy because updating the ArrayLists inside loops could lead to errors 
            theOperators = operators; //Same here

            while(theOperators.Contains("*") || theOperators.Contains("/"))
            {
                priorityOp = -1;
                //Find the first priority operator

                for (int i = 0; i < theOperators.Count; i++)
                {
                    if (theOperators[i].ToString().Equals("*") || theOperators[i].ToString().Equals("/"))
                    {
                        priorityOp = i;
                        break;
                    }
                }
                if (priorityOp == -1) break;
                
                num1 = double.Parse(theNumbers[priorityOp].ToString()); 
                num2 = double.Parse(theNumbers[priorityOp+1].ToString());

                if (theOperators[priorityOp].ToString().Equals("*"))
                    tempResult = num1*num2;
                else if (theOperators[priorityOp].ToString().Equals("/"))
                    tempResult = num1 / num2;
                
                //Creating the new string after the execution of the priority operator E.g "4+2*8" -> "4+16"
                ArrayList tempNumbers = new ArrayList();
                for (int i = 0; i<priorityOp; i++)
                {
                    tempNumbers.Add(theNumbers[i].ToString());
                }

                tempNumbers.Add(tempResult.ToString());

                if(priorityOp+2 < theNumbers.Count)
                {
                    for(int i = priorityOp+2; i<numbers.Count; i++)
                    {
                        tempNumbers.Add(theNumbers[i].ToString());
                    }
                }
                theNumbers = tempNumbers;
                theOperators.RemoveAt(priorityOp);
            }
            return (theNumbers, theOperators);
        }

        public string executeFinalOperations(ArrayList theNumbers, ArrayList theOperators)
        {
            double num1,num2,tempResult;


            while(theOperators.Count != 0)
            {
                num1 = double.Parse(theNumbers[0].ToString());
                num2 = double.Parse(theNumbers[1].ToString());

                if(theNumbers.Count == theOperators.Count && theOperators[0].Equals("-"))  //Then the first number of the expression is a negative. This number was not given directly by 
                {                                                                          //the user but it was calculated by this or the previous method. E.g. user gives "3-4-2*8" -> "3-4-16"
                    num1 = num1 * (-1);                                                    //"-1-16"
                    theOperators.RemoveAt(0);
                }

                if (theOperators[0].ToString().Equals("+"))
                    tempResult=num1 + num2;
                else
                    tempResult = num1 - num2;

                ArrayList tempNumbers = new ArrayList();

                tempNumbers.Add(tempResult.ToString());
                if(theOperators.Count >= 2) //Then there is at least one more operator to execute (Minus one that we just executed but didn't remove yet)
                { 
                    for (int i = 2; i < theNumbers.Count; i++)
                    {
                        tempNumbers.Add(theNumbers[i].ToString());
                    }
                }

                theNumbers = tempNumbers;
                theOperators.RemoveAt(0);
            }
            return theNumbers[0].ToString();
        }
         
    }
}
