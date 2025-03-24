#include <iostream>
#include "UserInterface.hpp"

int UserInterface::GetFirstInteger()
{
    int firstInteger;
    std::cout << "Enter the first number : ";
    std::cin >> firstInteger;
    return firstInteger;
}

int UserInterface::GetSecondInteger()
{
    int secondInteger;
    std::cout << "Enter the second number : ";
    std::cin >> secondInteger;
    return secondInteger;
}

void UserInterface::Run() 
{
    int firstInteger = GetFirstInteger();
    int secondInteger = GetSecondInteger();

    std::cout << "Before Swap : First Integer = " << firstInteger << ", Second Integer = " << secondInteger << std::endl;
    _numberSwapper.SwapNumbers(firstInteger, secondInteger);
    std::cout << "After Swap : First Integer = " << firstInteger << ", Second Integer = " << secondInteger << std::endl;
}
