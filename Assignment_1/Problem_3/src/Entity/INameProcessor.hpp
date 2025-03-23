#ifndef I_NAME_PROCESSOR_HPP
#define I_NAME_PROCESSOR_HPP
 
class INameProcessor 
{
    public:
        virtual int CalculateNameSize(char* name) = 0;
        virtual void SortName(char* name, bool isAscending) = 0;
};
 
#endif 