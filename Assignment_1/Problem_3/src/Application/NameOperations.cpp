#include "NameOperations.hpp"

//Constructor
NameOperations::NameOperations(NameProcessor& processor) : _nameProcessor(processor) {}

//Calculates the size of the name
int NameOperations::GetNameSize(char* name) 
{
    return _nameProcessor.CalculateNameSize(name);
}

//Sorts the name in ascending or descending order
void NameOperations::GetSortedName(char* name, std::string userOption) 
{
    if(userOption == "A" || userOption == "a")
        _nameProcessor.SortName(name);
    else if(userOption == "d" || userOption == "D")
        _nameProcessor.SortName(name, false);
}