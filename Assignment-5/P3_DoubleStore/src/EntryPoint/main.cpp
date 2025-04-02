#include <iostream>
#include <set>
#include <sstream>
#include <string>

int main() 
{
    std::set<double> uniqueNumbers; 
    std::string strInput;

    std::cout << "Enter a double (type 'exit' to stop) : " << std::endl;
    while (true) 
    {
        std::cout << "--> ";
        std::getline(std::cin, strInput); 

        if (strInput == "exit") 
        {
            break; 
        }

        std::stringstream inputStream(strInput);
        double number;

        if (inputStream >> number) 
        { 
            uniqueNumbers.insert(number); 
        } 
        else 
        {
            std::cout << "Invalid input. Enter a valid double (type 'exit' to stop)" << std::endl;
        }
    }

    std::cout << "\nSorted unique numbers : " << std::endl;
    for (double dStoredNumbers : uniqueNumbers) 
    {
        std::cout << dStoredNumbers << " ";
    }

    return 0;
}
