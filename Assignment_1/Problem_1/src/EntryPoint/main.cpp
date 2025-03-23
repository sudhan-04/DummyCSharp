#include "..\Presentation\UserInterface.hpp"
#include <string>

//Main method of the program
int main()
{
    GameProcessor leapYearChecker;
    UserInterface userInterface(leapYearChecker);
    userInterface.Run();
}