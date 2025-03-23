#ifndef USER_INTERFACE_HPP
#define USER_INTERFACE_HPP

#include "IUserInterface.hpp"
#include "..\Application\GameProcessor.hpp"

class UserInterface : public IUserInterface
{
    private:
        GameProcessor& _gameProcessor;

    public:
        UserInterface(GameProcessor& gameProcessor);
        int GetInputYear () override;
        void Run() override;
        void PrintResults(int numberOfCorrectGuesses);
};

#endif