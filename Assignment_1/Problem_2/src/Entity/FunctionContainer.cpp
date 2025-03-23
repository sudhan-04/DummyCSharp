#include "FunctionContainer.hpp"

//Target function whose count is calculated for each call
int FunctionContainer::CallFunction(bool isReset)
{
    static int functionCalls;
    functionCalls = (isReset) ? 0 : functionCalls + 1 ;
    return functionCalls;
}