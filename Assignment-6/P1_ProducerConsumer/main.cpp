#include <condition_variable>
#include <iostream>
#include <mutex>
#include <queue>
#include <sstream>
#include <thread>

#include "include/DivideByZeroexception.hpp"

std::mutex threadLocker;
std::queue<std::pair<int, char>> producerQueue;
std::condition_variable notifier;
bool isProducerRunning = true;
int result = 0;

void GetOperator(char &chOperator)
{
    std::cout << "Enter the operation to be performed (+,-,*,/) : ";
    while (!(std::cin >> chOperator) || !(chOperator == '+' || chOperator == '-' || chOperator == '*' || chOperator == '/')) 
    {
        std::cout << "Invalid input. Please enter a valid operator (+,-,*,/) : ";
        std::cin.clear();
        std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    }
}

void PerformOperation(int &nResult, const int &nSecondOperand, const char &chOperator)
{
    switch (chOperator)
    {
        case '+': 
            nResult += nSecondOperand; 
            break;
        case '-': 
            nResult -= nSecondOperand; 
            break;
        case '*': 
            nResult *= nSecondOperand; 
            break;
        case '/': 
            if (nSecondOperand == 0)
            {
                throw Cdivide_by_zero_exception(-1, "Exception Thrown: Divide by zero exception !!");
            }
            nResult /= nSecondOperand;
            break;
    }
}

void ProducerLoop() 
{
    while (true) 
    {
        std::this_thread::sleep_for(std::chrono::milliseconds(100));
        std::string input;
        int number;
        char chOperator;

        std::cout << "Enter an integer (type 'stop' to exit): ";
        std::cin >> input;

        if (input == "stop") 
        {
            {
                std::lock_guard<std::mutex> lock(threadLocker);
                producerQueue.push({0, '~'});  
                isProducerRunning = false;
            }

            notifier.notify_one();
            std::cout << "Stopping producer..." << std::endl;
            std::cout << std::flush;
            return;
        }

        std::stringstream ss(input);

        if (!(ss >> number)) 
        {
            std::cout << "Invalid input. Please enter a valid integer." << std::endl;
        }
        else
        {
            GetOperator(chOperator);
            
            std::lock_guard<std::mutex> lock(threadLocker);
            producerQueue.push({number, chOperator});
            
            notifier.notify_one();
        }
    }
}

void ConsumerLoop() 
{
    while (true) 
    {
        std::unique_lock<std::mutex> lock(threadLocker);
        notifier.wait(lock, [] { return !producerQueue.empty(); });

        auto operandOperatorPair = producerQueue.front();
        producerQueue.pop();
        
        if (operandOperatorPair.second == '~') 
        {  
            std::cout << "Stopping consumer..." << std::endl;
            return;
        }

        int nPreviousResult = result;

        try
        {
            PerformOperation(result, operandOperatorPair.first, operandOperatorPair.second);
        }
        catch(const std::exception& e)
        {
            std::cerr << e.what() << std::endl;
            std::cerr << "Result not changed !!!" << std::endl;
        }
        std::cout << "Result : " << nPreviousResult << operandOperatorPair.second <<  operandOperatorPair.first << " = " <<  result << std::endl;
        lock.unlock();
    }
}

int main()
{
    std::thread producer(ProducerLoop);
    std::thread consumer(ConsumerLoop);

    producer.join();
    consumer.join();
    return 0;
}
