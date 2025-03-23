#ifndef FUNCTION_CONTROLLER_HPP
#define FUNCTION_CONTROLLER_HPP

#include <string>
#include "../Entity/FunctionContainer.hpp"

class FunctionController
{
    public:
        FunctionController(FunctionContainer& container);
        enum FUNCTION_OPERATION{FO_CALL, FO_RESET, FO_INVALID};
        std::string HandleFunctions(std::string userOption);

    private:
        FUNCTION_OPERATION AssignOperation(std::string userOption);
        FunctionContainer& _functionContainer;
};

#endif