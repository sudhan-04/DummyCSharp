#ifndef EMPLOYEE_HPP
#define EMPLOYEE_HPP

#include "Position.hpp"
#include <string>

class CEmployee 
{
    protected:
        int m_EmployeeID;
        std::string m_Name;
        EMPLOYEE_POSITION m_Position;
        double m_Salary;
        int m_HardwareUnits;

    public:
        CEmployee(const int &nEmployeeID, const std::string &strName, const EMPLOYEE_POSITION &position, const double &dSalary);
        virtual ~CEmployee() {}

        int GetEmployeeID() ;
        std::string GetName() ;
        EMPLOYEE_POSITION GetPosition() ;
        double GetSalary() ;

        void SetPosition(const EMPLOYEE_POSITION &position);
        void SetSalary(double dSalary);

        virtual std::string GetCategory() = 0;
        virtual void PrintDetails() = 0;

        int GetHardwareUnits() ;
        void SetHardwareUnits(int units); 
};

#endif
