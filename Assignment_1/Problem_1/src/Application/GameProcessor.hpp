#ifndef LEAP_YEAR_CHECKER_HPP
#define LEAP_YEARCHECKER_HPP

#include "IGameProcessor.hpp"
#include "..\Entity\LeapYear.hpp"
#include <string>

class GameProcessor : public IGameProcessor
{
    public:
        std::string CheckLeapYear(int &inputYear);
        std::string ValidateScore(int &year, int &numberOfCorrectGuesses, int &numberOfTries);
        std::string GetCurrentScore(int &numberOfCorrectGuesses);
};

#endif