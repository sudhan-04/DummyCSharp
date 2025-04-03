#ifndef DIVIDE_BY_ZERO_EXCEPTION_HPP
#define DIVIDE_BY_ZERO_EXCEPTION_HPP

#include <exception>
#include <string> 
#include <cstring>

/**
 * @brief 'Cdivide_by_zero_exception' Exception class for handling divide-by-zero errors.
 */
class Cdivide_by_zero_exception : public std::exception
{ 
    public:
        Cdivide_by_zero_exception(const int &nErrorCode, const std::string &strErrorMessage);
        const char* what() const noexcept override;
        int GetErrorCode();

    private:
        // The error code of the exception.
        int m_ErrorCode;

        // The error message of the exception.
        std::string m_ErrorMessage;
};

#endif