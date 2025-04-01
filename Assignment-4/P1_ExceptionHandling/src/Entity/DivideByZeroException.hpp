#ifndef DIVIDE_BY_ZERO_EXCEPTION_HPP
#define DIVIDE_BY_ZERO_EXCEPTION_HPP

#include <exception>
#include <string> 
#include <cstring>

/**
 * @brief Exception class for handling divide-by-zero errors.
 */
class Cdivide_by_zero_exception : public std::exception
{
    private:
        /**
         * @brief The error code of the exception.
         */
        int m_ErrorCode;

        /**
         * @brief The error message of the exception.
         */
        std::string m_ErrorMessage;

    public:
        /**
         * @brief Constructor function.
         * 
         * @param nErrorCode The error code representing the exception.
         * @param strErrorMessage The error message representing the exception.
         */
        Cdivide_by_zero_exception(const int &nErrorCode, const std::string &strErrorMessage)
            : m_ErrorCode(nErrorCode), m_ErrorMessage(std::move(strErrorMessage)) {}

        /**
         * @brief Retrieves the error message of the exception.
         * @return A C-style string containing the error message.
         */
        const char* what() const noexcept override
        {
            return m_ErrorMessage.c_str();
        }

        /**
         * @brief Retrieves the error code of the exception.
         * @return The error code as an integer.
         */
        int GetErrorCode()
        {
            return m_ErrorCode;
        }
};

#endif