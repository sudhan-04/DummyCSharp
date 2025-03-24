#include "../Presentation/UserInterface.hpp"

int main() 
    {
    NumberSwapper numberSwapper;        
    UserInterface userInterface(numberSwapper);
    userInterface.Run();
    return 0;
}
