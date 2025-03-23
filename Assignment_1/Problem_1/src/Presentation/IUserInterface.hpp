#include <string>

class IUserInterface
{
    public:
        virtual int GetInputYear() = 0;
        virtual void Run() = 0;
        virtual void PrintResults(int finalScore) = 0;
};