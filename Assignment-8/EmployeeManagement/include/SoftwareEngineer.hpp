#ifndef SOFTWARE_ENGINEER_HPP
#define SOFTWARE_ENGINEER_HPP

#include "Employee.hpp"

class CSoftwareEngineer : public CEmployee
{
    public:
        CSoftwareEngineer(const int& nEmployeeID, const std::string& strName, const EMPLOYEE_POSITION& position, const double& dSalary);
        ~CSoftwareEngineer() {}

        std::string GetCategory() override;
        void PrintDetails() override;
};

#endif
