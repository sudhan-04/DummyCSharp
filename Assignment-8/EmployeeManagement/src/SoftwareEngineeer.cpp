#include "SoftwareEngineer.hpp"
#include <iostream>

CSoftwareEngineer::CSoftwareEngineer(const int &nEmployeeID, const std::string &strName, const EMPLOYEE_POSITION &position, const double &dSalary)
    : CEmployee(nEmployeeID, strName, position, dSalary) {} ;

std::string CSoftwareEngineer::GetCategory() 
{
    return "Software Engineer";
}

void CSoftwareEngineer::PrintDetails()
{
    std::cout << "Employee ID : " << m_EmployeeID << ", Category : Software Engineer" << ", Name: " << m_Name 
    << ", Position: " << static_cast<int>(m_Position) << ", Salary: " << m_Salary << std::endl;
}
