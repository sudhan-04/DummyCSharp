#include <iostream>
#include <functional>
#include <limits>

/**
 * @brief Validates and gets a valid integer from the user.
 *
 *  @param nInputOperand The variable reference where the input operand will be stored.
 */
void GetValidInteger(int &nInputOperand)
{
    std::cout << "Enter the integer value : ";

    while (!(std::cin >> nInputOperand)) 
    {
        std::cout << "Invalid input. Please enter an integer value : ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }

    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
}

/**
 * @brief Prints the result of an addition operation using a function.
 * 
 * @param AdditionOperation A std::function that takes two integers and returns their sum.
 * @param nFirstOperand The first integer operand.
 * @param nSecondOperand The second integer operand.
 */
void PrintAdditionResult(std::function<int(int, int)> AdditionOperation, int nFirstOperand, int nSecondOperand) 
{
    int result = AdditionOperation(nFirstOperand, nSecondOperand);
    std::cout << "Sum of " << nFirstOperand << " and " << nSecondOperand << " is " << result << "." << std::endl;
}

/**
 * @brief Main function to start the program.
 *  
 * @return Returns 0 on successful execution.
 */
int main() 
{
    std::cout << "Addition of two numbers : " << std::endl;
    int nFirstOperand, nSecondOperand;
    GetValidInteger(nFirstOperand);
    GetValidInteger(nSecondOperand);

    auto additionOperation = [](int nFirstOperand, int nSecondOperand) { return nFirstOperand + nSecondOperand; };
    PrintAdditionResult(additionOperation, nFirstOperand, nSecondOperand);
    return 0;
}
