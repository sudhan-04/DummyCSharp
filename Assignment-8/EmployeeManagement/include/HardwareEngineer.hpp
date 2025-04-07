#ifndef HARDWARE_ENGINEER_HPP
#define HARDWARE_ENGINEER_HPP

#include "Employee.hpp"

class CHardwareEngineer : public CEmployee
{
    public:
        CHardwareEngineer(const int& nEmployeeID, const std::string& strName, const EMPLOYEE_POSITION& position, const double& dSalary);
        ~CHardwareEngineer() {}

        std::string GetCategory() override;
        void PrintDetails() override;
};

#endif
