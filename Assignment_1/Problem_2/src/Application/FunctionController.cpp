#include "FunctionController.hpp"
#include <string>

//Constructor
FunctionController::FunctionController(FunctionContainer& container) : _functionContainer(container) {};

//Map the user input string to the enums
FunctionController::FUNCTION_OPERATION FunctionController::AssignOperation(std::string userOption)
{
    if(userOption == "C" || userOption == "c")
        return FunctionController::FO_CALL;
    else if(userOption == "R" || userOption == "r")
        return FunctionController::FO_RESET;
    else
        return FunctionController::FO_INVALID;
}

//Perform the corresponding operation according to the user input
std::string FunctionController::HandleFunctions(std::string userOption)
{
    FunctionController::FUNCTION_OPERATION operation = AssignOperation(userOption);
    switch(operation)
    {
        case(FunctionController::FO_CALL):
            return "The function has been called " + std::to_string(FunctionController::_functionContainer.CallFunction(false))+ " times.";
        case(FunctionController::FO_RESET):
            return "The function call count has been reset to " + std::to_string(FunctionController::_functionContainer.CallFunction(true))+ " times.";
        case(FunctionController::FO_INVALID):
            return "Invalid Input !!!";
    }
}