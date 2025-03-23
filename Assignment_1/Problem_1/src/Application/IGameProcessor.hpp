#ifndef I_GAME_PROCESSOR_HPP
#define I_GAME_PROCESSOR_HPP

#include <string>

class IGameProcessor
{
    public:
        virtual std::string ValidateScore(int &year, int &numberOfCorrectGuesses, int &numberOfTries) = 0;
        virtual std::string GetCurrentScore(int &numberOfCorrectGuesses) = 0;
};

#endif