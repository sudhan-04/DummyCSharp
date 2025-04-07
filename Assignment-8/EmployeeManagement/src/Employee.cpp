#include "../include/Employee.hpp"

CEmployee::CEmployee(const int &nEmployeeID, const std::string &strName, const EMPLOYEE_POSITION &position, const double &dSalary)
    : m_EmployeeID(nEmployeeID), m_Name(strName), m_Position(position), m_Salary(dSalary), m_HardwareUnits(5) {} ;

int CEmployee::GetEmployeeID() 
{
    return m_EmployeeID;
}

std::string CEmployee::GetName() 
{
    return m_Name;
}

EMPLOYEE_POSITION CEmployee::GetPosition() 
{
    return m_Position;
}

double CEmployee::GetSalary() 
{
    return m_Salary;
}

void CEmployee::SetPosition(const EMPLOYEE_POSITION &position) 
{
    m_Position = position;
}

void CEmployee::SetSalary(double dSalary) 
{
    m_Salary = dSalary;
}

int CEmployee::GetHardwareUnits() 
{
    return m_HardwareUnits;
}

void CEmployee::SetHardwareUnits(int nUnits) 
{
    m_HardwareUnits = nUnits;
}
