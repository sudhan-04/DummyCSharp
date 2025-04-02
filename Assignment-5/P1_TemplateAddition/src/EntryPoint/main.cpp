#include <iostream>
#include <string>

/**
 * @brief Template function to perform addition or string concatenation.
 * 
 * @param firstOperand The first input value.
 * @param secondOperand The second input value.
 * 
 * @return T The result of addition (for numbers) or concatenation (for strings).
 */
template <typename T>
T AddInputs(T firstOperand, T secondOperand)
{
    return firstOperand + secondOperand;
}

/**
 * @brief Main function to test the template function with various data types.
 * 
 * @return Returns 0 upon successful execution.
 */
int main()
{
    std::cout << "Adding 1 and 2 (Integer addition) : " << AddInputs<int>(1, 2) << std::endl;
    std::cout << "Adding 7.65 and 2.455 (Double addition) : " << AddInputs<double>(7.65, 2.455) << std::endl;
    std::cout << "Adding 10.23 and 6.75 (Float addition) : " << AddInputs<float>(10.23, 6.75) << std::endl;
    std::cout << "Concatenating 'First' and 'Second' (String concatenation) : " << AddInputs<std::string>("First", "Second") << std::endl;

    return 0;
}
