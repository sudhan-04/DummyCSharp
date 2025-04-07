#include "../include/ManagementStaff.hpp"
#include <iostream>

CManagementStaff::CManagementStaff(const int &nEmployeeID, const std::string &strName, const EMPLOYEE_POSITION &position, const double &dSalary)
    : CEmployee(nEmployeeID, strName, position, dSalary) {} ;

std::string CManagementStaff::GetCategory()
{
    return "Management Staff";
}

void CManagementStaff::PrintDetails()
{
    std::cout << "Employee ID : " << m_EmployeeID << ", Category : Management Staff" << ", Name: " << m_Name 
    << ", Position: " << static_cast<int>(m_Position) << ", Salary: " << m_Salary << std::endl;
}
