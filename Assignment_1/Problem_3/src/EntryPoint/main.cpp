#include "../Presentation/UserInterface.hpp"

//Main function of the program
int main()
{
    NameProcessor nameProcessor;
    NameOperations nameOperations(nameProcessor);
    UserInterface userInterface(nameOperations);
    userInterface.Run();
}