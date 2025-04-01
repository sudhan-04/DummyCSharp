#include "../Presentation/UserInterface.hpp"

/**
 * @brief Main function to start the logging and user interface.
 * 
 * This function creates the logger and user interface, then starts them in separate threads.
 * 
 * @return Returns 0 on successful execution.
 */
int main() 
{
    CLogger cLogger; ///< Logger instance
    CUserInterface cUserInterface(cLogger); ///< User interface instance

    // Start logging and UI handling in separate threads
    std::thread thread1 (&CLogger::LogDateTime, &cLogger);
    std::thread thread2 (&CUserInterface::HandleUserInterface, &cUserInterface);

    // Wait for both threads to complete execution
    thread1.join();
    thread2.join();

    return 0;
}
