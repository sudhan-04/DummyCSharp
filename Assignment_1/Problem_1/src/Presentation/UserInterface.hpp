# pragma once
#include "IUserInterface.hpp"

class UserInterface : public IUserInterface
{
    public:
        int GetInputYear () override;
        std::string DeriveResult(int year) override;
        void PrintLeapYearResult(std::string result) override;
        void Run() override;
};