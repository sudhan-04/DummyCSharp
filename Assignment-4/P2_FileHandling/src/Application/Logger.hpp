#ifndef LOGGER_HPP
#define LOGGER_HPP

#include <fstream>
#include <dirent.h> 
#include <string>
#include <thread>
#include <chrono>
#include <iostream>
#include <cstdio>
#include <atomic> 

#define MAX_FILE_SIZE 2048
#define MAX_DIRECTORY_SIZE 20480

class CLogger
{
    public:
        void PrintListOfFiles(const std::string& folder) ;
        void LogDateTime() ;
        std::atomic<bool> m_shouldStopLogging;
        CLogger() : m_shouldStopLogging(false) {};
        long GetDirectorySize(const std::string& folder) ;

    private:
        int GetNumberOfFilesInDirectory(const std::string& folder) ;
};

#endif