#ifndef USER_INTERFACE_HPP
#define USER_INTERFACE_HPP
 
#include "IUserInterface.hpp"
#include "../Application/NameOperations.hpp"
#include <iostream>
 
class UserInterface : public IUserInterface 
{
    private:
        NameOperations& _nameController;
    
    public:
        UserInterface(NameOperations& operations);
        void Run() override;
        void GetSortingOrderChoice(std::string &sortChoice) override;
        void PrintNameSize(char *name) override;

};

#endif
