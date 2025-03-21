#include <string>

class IUserInterface
{
    public:
        virtual void PrintWelcome() = 0;
        virtual void PerformFunctionOperation() = 0;
};