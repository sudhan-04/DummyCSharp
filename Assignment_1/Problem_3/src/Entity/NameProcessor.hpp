#ifndef NAME_PROCESSOR_HPP
#define NAME_PROCESSOR_HPP
 
#include "INameProcessor.hpp"
 
class NameProcessor : public INameProcessor 
{
    public:
        int CalculateNameSize(char* name) override;
        void SortName(char* name, bool isAscending = true) override;
};
 
#endif