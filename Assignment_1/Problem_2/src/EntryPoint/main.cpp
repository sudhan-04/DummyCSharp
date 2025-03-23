#include "../Presentation/UserInterface.hpp"

//Main method of the program
int main()
{
    FunctionContainer functionContainer;
    FunctionController functionController(functionContainer);
    UserInterface userInterface(functionController);

    userInterface.PrintWelcome();
    userInterface.PerformFunctionOperation();
}