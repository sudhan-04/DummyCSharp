#ifndef I_USER_INTERFACE_HPP
#define I_USER_INTERFACE_HPP
 
#include <string>
 
class IUserInterface 
{
    public:
        virtual void PrintWelcome() = 0;
        virtual void PerformFunctionOperation() = 0;
        virtual void GetUserOption(std::string &inputOperation) = 0;
};
 
#endif