#include "NameProcessor.hpp"
#include <cstring>
#include <algorithm>

//Calculate the length of the character array
int NameProcessor::CalculateNameSize(char* name) 
{
    return std::strlen(name);
}

//Compares two characters
bool isGreater(char firstCharacter, char secondCharacter)
{
    return firstCharacter > secondCharacter;
}

//Sorts the name based on the alphabetical order in ascending or descending order
void NameProcessor::SortName(char* name, bool isAscending) 
{
    if(isAscending)
        std::sort(name, name + std::strlen(name));
    else
        std::sort(name, name + std::strlen(name), isGreater);
}
