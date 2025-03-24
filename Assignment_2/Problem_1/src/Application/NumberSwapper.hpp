#ifndef NUMBER_SWAPPER_HPP
#define NUMBER_SWAPPER_HPP

#include "INumberSwapper.hpp"

class NumberSwapper : public INumberSwapper 
{
    public:
        void SwapNumbers(int &firstNumber, int &secondNumber) override;
};

#endif