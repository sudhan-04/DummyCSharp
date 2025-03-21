#include <string>

class IUserInterface
{
    public:
        virtual int GetInputYear() = 0;
        virtual std::string DeriveResult(int year) = 0;
        virtual void PrintLeapYearResult(std::string resuslt) = 0;
        virtual void Run() = 0;
};