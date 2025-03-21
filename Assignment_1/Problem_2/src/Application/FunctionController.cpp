#include "FunctionController.hpp"
#include "..\Entity\FunctionContainer.hpp"
#include <string>

FunctionContainer functionContainer;

std::string FunctionController::HandleFunctions(std::string inputOperation)
{
    if(inputOperation == "C")
        return "The function has been called " + std::to_string(functionContainer.CallFunction(false))+ " times.";
    else if(inputOperation == "R")
        return "The function call count has been reset to  " + std::to_string(functionContainer.CallFunction(true))+ " times.";
    else
        return "Invalid Input !!!";
};