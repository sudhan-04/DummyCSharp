#include "UserInterface.hpp"
#include "..\Application\FunctionController.hpp"
#include <iostream>

FunctionController functionController;

void UserInterface::PrintWelcome()
{
    std::cout << "Welcome to the function counter !!!" << std::endl;
}

void UserInterface::PerformFunctionOperation()
{
    std::string inputOperation;
    std::cout << "Provide the operation to be performed on the function ([C]all | [R]eset | [E]xit) : ";
    std::cin >> inputOperation;

    while(std::tolower(inputOperation) != "E")
    {
        std::cout << functionController.HandleFunctions(inputOperation) << std::endl;
        std::cout << "Provide the operation to be performed ([C]all | [R]eset | [E]xit) : ";
        std::cin >> inputOperation;
    }

    std::cout << "Successfully exited....";
}

