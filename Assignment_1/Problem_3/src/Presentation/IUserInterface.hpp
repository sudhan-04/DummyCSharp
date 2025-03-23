#include <string>
#ifndef I_USER_INTERFACE_HPP
#define I_USER_INTERFACE_HPP
 
class IUserInterface 
{
    public:
        virtual void Run() = 0;
        virtual void GetSortingOrderChoice(std::string &sortChoice) = 0;
        virtual void PrintNameSize(char *name) = 0;
};
 
#endif