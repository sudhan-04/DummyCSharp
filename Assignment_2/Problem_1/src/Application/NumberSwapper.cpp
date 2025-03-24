#include "NumberSwapper.hpp"

void NumberSwapper::SwapNumbers(int &firstNumber, int &secondNumber)
{
    firstNumber = firstNumber + secondNumber;
    secondNumber = firstNumber - secondNumber;
    firstNumber = firstNumber - secondNumber;
}
