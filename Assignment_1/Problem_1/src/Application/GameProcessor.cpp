#include "GameProcessor.hpp"
#include <string>

// Returns a string denoting whether the input year is a leap year
std::string GameProcessor::CheckLeapYear(int &inputYear)
{
    return (IsLeapYear(inputYear) ? ("Year : " + std::to_string(inputYear) + " is a leap year.") : "Year : " + std::to_string(inputYear) + " is not a leap year.");
}

//Validate the current score of the user
std::string GameProcessor::ValidateScore(int &year, int &numberOfCorrectGuesses, int &numberOfTries)
{
    std::string result = CheckLeapYear(year);
    if (result.find("not") == std::string::npos)
    {
        numberOfCorrectGuesses++;
    }
    numberOfTries++;
    GetCurrentScore(numberOfCorrectGuesses);
    return result;
}

//Returns the current score of the user 
std::string GameProcessor::GetCurrentScore(int &numberOfCorrectGuesses)
{
    return "Current Score : " + std::to_string(numberOfCorrectGuesses);
}