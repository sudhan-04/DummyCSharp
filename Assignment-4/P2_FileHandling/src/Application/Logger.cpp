#include "Logger.hpp"

/**
 * @brief Gets the number of files in the given directory.
 * 
 * @param folder The directory path.
 * 
 * @return The count of files in the directory.
 */
int CLogger::GetNumberOfFilesInDirectory(const std::string& folder) 
{
    DIR* directory = opendir(folder.c_str());

    if (!directory) 
    {
        std::cout << "No such directory exists" << std::endl;
        std::terminate();
        return -1;
    }

    struct dirent* entry;
    int numberOfFiles = 0;

    while (entry = readdir(directory)) 
    {
        std::string fileName = entry->d_name;
        if (!(fileName == "." || fileName == ".."))
        {
            numberOfFiles++;
        }
    }

    closedir(directory);
    return numberOfFiles;
}

/**
 * @brief Calculates the total size of all files in a given directory.
 * 
 * @param folder The directory path.
 * 
 * @return The total size of the directory in bytes.
 */
long CLogger::GetDirectorySize(const std::string& folder) 
{
    DIR* directory = opendir(folder.c_str());

    if (!directory) 
    {
        std::cout << "No such directory exists" << std::endl;
        return -1;
    }

    struct dirent* entry;
    long totalSize = 0;

    while (entry = readdir(directory)) 
    {
        std::string fileName = entry->d_name;
        if (!(fileName == "." || fileName == ".."))
        {
            std::string filePath = folder + "/" + fileName;
            std::ifstream file(filePath, std::ios::ate);
            totalSize += file.tellg(); 
            file.close();
        }
    }

    closedir(directory);
    return totalSize;
}

/**
 * @brief Prints a list of all files in a directory along with their sizes.
 * 
 * @param folder The directory path.
 */
void CLogger::PrintListOfFiles(const std::string& folder) 
{
    DIR* directory = opendir(folder.c_str());

    if (!directory) 
    {
        std::cout << "No such directory exists" << std::endl;
        return;
    }

    struct dirent* entry;

    while (entry = readdir(directory)) 
    {
        std::string fileName = entry->d_name;
        if (!(fileName == "." || fileName == ".."))
        {
            std::string filePath = folder + "/" + fileName;
            std::ifstream file(filePath, std::ios::ate);
            std::cout << folder + "/" + fileName + " --> File Size : " + std::to_string(file.tellg()) + " bytes" << std::endl;
        }
    }

    closedir(directory);
}

/**
 * @brief Logs the current date and time into a file.
 * 
 * This function writes a timestamp every second to a log file. If the file size 
 * exceeds a certain limit, a new log file is created. If the total 
 * directory size exceeds a certain limit, older files are deleted.
 */
void CLogger::LogDateTime()
{
    std::string filePrefix = "Logs/LoggedData_";
    std::string fileExtension = ".txt";
    std::string directoryName = "Logs";
    int fileNumber = GetNumberOfFilesInDirectory(directoryName);
    std::fstream file((filePrefix + std::to_string(fileNumber) + fileExtension), std::ios::app | std::ios::ate);
    int fileSize = 0;

    while (!m_shouldStopLogging.load())
    { 
        if (GetDirectorySize(directoryName) < MAX_DIRECTORY_SIZE)
        {
            if (fileSize < MAX_FILE_SIZE)
            {
                time_t timestamp;
                time(&timestamp);
                file << ctime(&timestamp);
                std::this_thread::sleep_for(std::chrono::seconds(1));
                fileSize = file.tellg();
            }
            else
            {
                file.close();
                fileNumber = GetNumberOfFilesInDirectory(directoryName);
                file.open((filePrefix + std::to_string(fileNumber) + fileExtension), std::ios::app | std::ios::ate);
                fileSize = 0;
            }
        }
        else
        {
            file.close();
            int numberOfFiles = GetNumberOfFilesInDirectory(directoryName);
            std::remove((filePrefix + std::to_string(numberOfFiles) + fileExtension).c_str());

            for (int fileCount = 0; fileCount <= 4; fileCount++)
            {     
                std::remove((filePrefix + std::to_string(fileCount) + fileExtension).c_str());
            }

            for (int fileCount = 5; fileCount < numberOfFiles; fileCount++)
            {
                std::rename((filePrefix + std::to_string(fileCount) + fileExtension).c_str(),
                            (filePrefix + std::to_string(fileCount - 5) + fileExtension).c_str());
            }

            numberOfFiles = GetNumberOfFilesInDirectory(directoryName);
            file.open((filePrefix + std::to_string(numberOfFiles - 1) + fileExtension), std::ios::app | std::ios::ate);
        }
    }
}
