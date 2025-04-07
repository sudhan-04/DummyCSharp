#include "../include/HardwareEngineer.hpp"
#include <iostream>

CHardwareEngineer::CHardwareEngineer(const int &nEmployeeID, const std::string &strName, const EMPLOYEE_POSITION &position, const double &dSalary)
    : CEmployee(nEmployeeID, strName, position, dSalary) {} ;

std::string CHardwareEngineer::GetCategory() 
{
    return "Hardware Engineer";
}

void CHardwareEngineer::PrintDetails()
{
    std::cout << "Employee ID : " << m_EmployeeID << ", Category : Hardware Engineer" << ", Name: " << m_Name 
    << ", Position: " << static_cast<int>(m_Position) << ", Salary: " << m_Salary << std::endl;   
}
