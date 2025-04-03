#include "../include/DivideByZeroexception.hpp"

/**
 * @brief Function to construct a DivideByZeroException instance.
 * 
 * @param nErrorCode The error code representing the exception.
 * @param strErrorMessage The error message representing the exception.
 */
Cdivide_by_zero_exception::Cdivide_by_zero_exception(const int &nErrorCode, const std::string &strErrorMessage)
    : m_ErrorCode(nErrorCode), m_ErrorMessage(std::move(strErrorMessage)) {}

/**
 * @brief Retrieves the error message of the exception.
 * 
 * @return A C-style string containing the error message.
 */
const char* Cdivide_by_zero_exception::what() const noexcept
{
    return m_ErrorMessage.c_str();
}

/**
 * @brief Retrieves the error code of the exception.
 * 
 * @return The error code as an integer.
 */
int Cdivide_by_zero_exception::GetErrorCode()
{
    return m_ErrorCode;
}