#ifndef LEAP_YEAR_HPP
#define LEAP_YEAR_HPP

// Returns a boolean denoting whether the input year is a leap year.
inline bool IsLeapYear(int year) {return (year%4 == 0 && year%100 != 0) || year%400 == 0 ; }

#endif