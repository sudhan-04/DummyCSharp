#include "UserInterface.hpp"
#include <iostream>
 
UserInterface::UserInterface(FunctionController& controller) : _functionController(controller) {}

//Print the welcome message
void UserInterface::PrintWelcome() 
{
    std::cout << "Welcome to the function counter !!!" << std::endl;
}

//Perform the required operations on the function
void UserInterface::PerformFunctionOperation() 
{
    std::string inputOperation;
    GetUserOption(inputOperation);

    while (inputOperation != "E" && inputOperation != "e") 
    {
        std::cout << _functionController.HandleFunctions(inputOperation) << std::endl;
        GetUserOption(inputOperation);
    }
 
    std::cout << "Successfully exited...." << std::endl;
}

//To get the input from the user for perfroming operations
void UserInterface::GetUserOption(std::string &inputOperation)
{
    std::cout << "Provide the operation to be performed ([C]all | [R]eset | [E]xit) : ";
    std::cin >> inputOperation;
}
