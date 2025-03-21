#include "FunctionContainer.hpp"

int FunctionContainer::CallFunction(bool isReset)
{
    static int functionCalls;
    if(isReset == false)
        functionCalls++;
    else
        functionCalls = 0;

    return functionCalls;
}