#include <iostream>
#include <limits>

/**
 * @brief Validates and gets a valid integer from the user.
 *
 *  @param nInputOperand The variable reference where the input operand will be stored.
 */
void GetValidInteger(int &nInputOperand)
{
    std::cout << "Choose the data type : ";

    while (!(std::cin >> nInputOperand )|| nInputOperand <= 0 || nInputOperand > 3)
    {
        std::cout << "Invalid input. Please choose a valid data type : ";
        std::cin.clear(); 
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }

    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
}

/**
 * @brief Validates and gets a valid inputOperand from the user.
 */
template <typename T>
void GetValidInput(T& inputOperand, const std::string &strDataType) 
{
    std::cout << "Enter the " << strDataType << " value: ";
    while (!(std::cin >> inputOperand)) 
    {
        std::cout << "Invalid input. Please enter a " << strDataType << " value: ";
        std::cin.clear();
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }

    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
}

void PerformAddition(void* pFirstOperand, void* pSecondOperand, int nDataType)
{
    enum Data_Type { DT_Integer = 1, DT_Double, DT_Float };
    Data_Type eDataType = static_cast<Data_Type>(nDataType);

    switch (eDataType) 
    {
        case DT_Integer :
            std::cout << "Result of adding integers " << *(int*)pFirstOperand << " and " << *(int*)pSecondOperand << " is "
            << *(int*)pFirstOperand + *(int*)pSecondOperand << "." << std::endl;
            break;
        case DT_Double :
            std::cout << "Result of adding doubles " << *(double*)pFirstOperand << " and " << *(double*)pSecondOperand << " is "
            << *(double*)pFirstOperand + *(double*)pSecondOperand << "." << std::endl;
            break;
        case DT_Float :
            std::cout << "Result of adding floats " << *(float*)pFirstOperand << " and " << *(float*)pSecondOperand << " is "
            << *(float*)pFirstOperand + *(float*)pSecondOperand << "." << std::endl;
            break;
        default:
            std::cout << "Unsupported data type !!!" << std::endl;
    }
}

/**
 * @brief Main function to start the program.
 *  
 * @return Returns 0 on successful execution.
 */
int main()
{
    std::cout << "\n[1] Integer\n[2] Double\n[3] Float\nEnter the datatype : ";
    int nInputOperator;
    GetValidInteger(nInputOperator);

    switch(nInputOperator)
    {
        case 1 :
            int nFirstOperand;
            int nSecondOperand;

            GetValidInput(nFirstOperand, "Integer");
            GetValidInput(nSecondOperand, "Integer");

            PerformAddition(&nFirstOperand, &nSecondOperand, nInputOperator);
            break;
        
        case 2 :
            double dFirstOperand;
            double dSecondOperand;

            GetValidInput(dFirstOperand, "double");
            GetValidInput(dSecondOperand, "double");
            PerformAddition(&nFirstOperand, &nSecondOperand, nInputOperator);
            break;

        case 3 :
            float fFirstOperand;
            float fSecondOperand;

            GetValidInput(fFirstOperand, "float");
            GetValidInput(fSecondOperand, "float");
            PerformAddition(&nFirstOperand, &nSecondOperand, nInputOperator);
            break;
    }

    return 0;
}