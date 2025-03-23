#ifndef USER_INTERFACE_HPP
#define USER_INTERFACE_HPP

#include "../Application/FunctionController.hpp"
#include "IUserInterface.hpp"

class UserInterface : public IUserInterface 
{
    private:
        FunctionController& _functionController; 

    public:
        UserInterface(FunctionController& controller);
        void PrintWelcome() override;
        void PerformFunctionOperation() override;
        void GetUserOption(std::string &inputOperation);
};
 
#endif