# pragma once
#include "IUserInterface.hpp"

class UserInterface : public IUserInterface
{
    public:
        void PrintWelcome () override;
        void PerformFunctionOperation() override;
};