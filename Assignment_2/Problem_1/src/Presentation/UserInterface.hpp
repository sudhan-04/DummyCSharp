#ifndef USER_INTERFACE_HPP
#define USER_INTERFACE_HPP

#include "IUserInterface.hpp"
#include "../Application/NumberSwapper.hpp"

class UserInterface : public IUserInterface
{
    private:
        NumberSwapper& _numberSwapper;
        int GetFirstInteger() override;
        int GetSecondInteger() override;
    public:
        UserInterface(NumberSwapper& numberSwapper) : _numberSwapper(numberSwapper) {};
        void Run() override;
};

#endif
