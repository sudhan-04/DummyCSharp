#ifndef USER_INTERFACE_HPP
#define USER_INTERFACE_HPP

#include "../Application/Logger.hpp"

/**
 * @brief Handles the user interface interactions.
 */
class CUserInterface
{
    public:
        /**
         * @brief Constructor function.
         * 
         * @param c_logger Reference to a CLogger instance.
         */
        CUserInterface(CLogger &c_logger);

        void HandleUserInterface();

    private:
        CLogger &m_Logger;
};

#endif
