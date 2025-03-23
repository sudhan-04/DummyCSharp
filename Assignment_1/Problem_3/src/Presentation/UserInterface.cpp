#include "UserInterface.hpp"

//Constructor
UserInterface::UserInterface(NameOperations& controller) : _nameController(controller) {}

//Performs the operations of the name
void UserInterface::Run() 
{
    int maximumNameSize = 100;
    char name[maximumNameSize];
    std::cout << "Enter your name : ";
    std::cin.getline(name, maximumNameSize);

    PrintNameSize(name);

    std::string sortChoice;
    GetSortingOrderChoice(sortChoice);

    while(!(sortChoice == "D" || sortChoice == "d" || sortChoice == "A" || sortChoice == "a"))
    {
        std::cout << "Invalid input." << std::endl;
        GetSortingOrderChoice(sortChoice);
    }

    _nameController.GetSortedName(name, sortChoice);
    std::cout << "Sorted name : " << name << std::endl;
}

//Print the size of the input name
void UserInterface::PrintNameSize(char *name)
{
    std::cout << "Bytes required to store your name : ";
    std::cout << _nameController.GetNameSize(name) << std::endl;
}

//Get the sorting choice from the user
void UserInterface::GetSortingOrderChoice(std::string &sortChoice)
{
    std::cout << "Sort in [A]scending / [D]escending order : ";
    std::cin >> sortChoice;
}
