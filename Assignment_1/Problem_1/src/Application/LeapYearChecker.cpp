#include "..\Entity\LeapYear.hpp"
#include "LeapYearChecker.hpp"
#include <string>


std::string LeapYearChecker::CheckLeapYear(int year)
{
    return (IsLeapYear(year) ? ("Year : " + std::to_string(year) + " is a leap year.") : "Year : " + std::to_string(year) + " is not a leap year.");
}