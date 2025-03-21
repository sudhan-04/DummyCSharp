#include <string>
#include <limits>
#include <iostream>
#include "..\Application\LeapYearChecker.hpp"
#include "UserInterface.hpp"

LeapYearChecker leapYearChecker;
int inputYear;

int UserInterface::GetInputYear()
{
    std::cout << "Enter the year : ";
    while (!(std::cin >> inputYear) || inputYear < 1) {
        std::cout << "Invalid input. Please enter an positive integer: ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }

    return inputYear;
}

std::string UserInterface::DeriveResult(int year)
{
    return leapYearChecker.CheckLeapYear(inputYear);
}

void UserInterface::PrintLeapYearResult(std::string result)
{
    std::cout<< result << std::endl;
}

void UserInterface::Run()
{
    std::cout << "Welcome to the leap year game !!! \nYou have 3 tries." << std::endl;
    int numberOfTries = 0;
    int numberOfCorrectGuesses = 0;
    while(numberOfTries <= 2)
    {
        int year = GetInputYear();
        std::string  result = DeriveResult(year);
        PrintLeapYearResult(result);
        if(result.find("not") == std::string::npos)
        {
            numberOfCorrectGuesses++;
        }
        std::cout << "Current Score : "+std::to_string(numberOfCorrectGuesses) << std::endl;
        numberOfTries++;
    }

    std::cout << "\nFinal Score : "+std::to_string(numberOfCorrectGuesses) << std::endl;
    if(numberOfCorrectGuesses==0)
    {
        std::cout << "Leap year occurs every four years, but years that are divisible by 100 must be divisible by 400 too." << std::endl;
        std::cout << "Better luck next time !!!" << std::endl;    
    }
    else if(numberOfCorrectGuesses==1 )
    {
        std::cout << "Good try player !!!" << std::endl;
    }
    else if(numberOfCorrectGuesses==1 )
    {
        std::cout << "You are one of the best !!!" << std::endl;
    }
    else if(numberOfCorrectGuesses==3)
    {
        std::cout << "You are officially crowned as a master of finding leap years !!!" << std::endl;
    }
}