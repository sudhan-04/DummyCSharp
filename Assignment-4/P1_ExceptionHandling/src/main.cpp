#include <iostream>
#include <limits>
#include "DivideByZeroException.hpp"

/**
 * @brief Gets a valid integer input from the user.
 * 
 * This function prompts the user to enter an integer and validates the input.
 * If invalid input is provided, the user is asked to re-enter a valid integer.
 * 
 * @param nInputInteger Reference to store the input integer.
 * 
 * @param strInputString The prompt message displayed to the user.
 */
void GetInputInteger(int &nInputInteger, const std::string &strInputString)
{
    std::cout << strInputString;
    while (!(std::cin >> nInputInteger)) 
    {
        std::cout << "Invalid input. Please enter a valid integer: ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
}

/**
 * @brief Gets a valid operator from the user.
 * 
 * This function prompts the user to enter a valid arithmetic operator (+, -, *, /) or '~' to exit.
 * If an invalid operator is entered, the user is asked to re-enter a valid operator.
 * 
 * @param chOperator Reference to store the input operator.
 */
void GetOperator(char &chOperator)
{
    std::cout << "Enter the operation to be performed (+,-,*,/) [Press '~' to exit] : ";
    while (!(std::cin >> chOperator) || !(chOperator == '+' || chOperator == '-' || chOperator == '*' || chOperator == '/' || chOperator == '~')) 
    {
        std::cout << "Invalid input. Please enter a valid operator (+,-,*,/) [Press '~' to exit] : ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
}

/**
 * @brief Performs the specified arithmetic operation.
 * 
 * This function takes two operands and an operator, then performs the corresponding arithmetic operation.
 * 
 * @param nResult Reference to store the result of the operation.
 * @param nFirstOperand First operand of the arithmetic operation.
 * @param nSecondOperand Second operand of the arithmetic operation.
 * @param chOperator The arithmetic operator.
 */
void PerformOperation(int &nResult, const int &nFirstOperand, const int &nSecondOperand, const char &chOperator)
{
    switch(chOperator)
    {
        case '+':
            nResult = nFirstOperand + nSecondOperand;
            break;
        case '-':
            nResult = nFirstOperand - nSecondOperand;
            break;
        case '*':
            nResult = nFirstOperand * nSecondOperand;
            break;
        case '/':
            if (nSecondOperand == 0)
            {
                throw Cdivide_by_zero_exception(7, "Divide by zero exception !!!!");
            }
            nResult = nFirstOperand / nSecondOperand;
            break;
        case '~':
            break;
    }
}

/**
 * @brief Main function to run the calculator program.
 * 
 * @return Returns 0 upon successful execution.
 */
int main()
{
    int nFirstInteger = 0, nSecondInteger = 0, nResult = 0; 
    GetInputInteger(nFirstInteger, "Enter the first integer : ");
    GetInputInteger(nSecondInteger, "Enter the second integer : ");
    char chOperator;
    GetOperator(chOperator);
    
    try
    {
        PerformOperation(nResult, nFirstInteger, nSecondInteger, chOperator);
        if (chOperator != '~')
            std::cout << "The result is : " << nResult << std::endl;
        else
            std::cout << "Exited Successfully...." << std::endl;
    }
    catch (Cdivide_by_zero_exception &CaughtException)
    {
        std::cout << CaughtException.what() << std::endl;
        std::cout << "Error Code : " << CaughtException.GetErrorCode() << std::endl;
    }
    
    return 0;
}