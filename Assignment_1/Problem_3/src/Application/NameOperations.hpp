#ifndef NAME_OPERATIONS_HPP
#define NAME_OPERATIONS_HPP

#include <string>
#include "../Entity/NameProcessor.hpp"
 
class NameOperations 
{
    private:
        NameProcessor& _nameProcessor;
    
    public:
        NameOperations(NameProcessor& processor);
        int GetNameSize(char* name);
        void GetSortedName(char* name, std::string userOption);
};
 
#endif