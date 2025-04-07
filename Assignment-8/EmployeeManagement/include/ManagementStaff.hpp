#ifndef MANAGEMENT_STAFF_HPP
#define MANAGEMENT_STAFF_HPP

#include "Employee.hpp"

class CManagementStaff : public CEmployee
{
    public:
        CManagementStaff(const int& nEmployeeID, const std::string& strName, const EMPLOYEE_POSITION& position, const double& dSalary);
        ~CManagementStaff() {}

        std::string GetCategory() override;
        void PrintDetails() override;
};

#endif
