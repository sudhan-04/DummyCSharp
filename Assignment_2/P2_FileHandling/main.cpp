 /* #include <iostream>
#include <fstream>
#include <ctime>

int main() {
    std::fstream file("TestFile1.txt", std::ios::app );
    if (file.is_open()) 
    {
        time_t timestamp;
        time(&timestamp);
        file << ctime(&timestamp);
        std::streamsize size = file.tellg();
        file.close();
        std::cout << "File size: " << size << " bytes\n";
    } 
    else 
    {
        std::cout << "File not found!\n";
    }
    return 0;
}

 #include <iostream>
 #include <fstream>
 #include <dirent.h>  // For directory handling
 #include <string>
 
 long getDirectorySize(const std::string& folder) 
 {
     DIR* directory = opendir(folder.c_str());
 
     struct dirent* entry;
     long totalSize = 0;
 
     while ((entry = readdir(directory)) != nullptr) 
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
 
 int main() {
     std::string folder = "Logs";  // Directory name
     long size = getDirectorySize(folder);
 
     if (size != -1) {
         std::cout << "Total size of directory '" << folder << "': " << size << " bytes\n";
     } else {
         std::cout << "Error calculating directory size!\n";
     }
 
     return 0;
 }
  */

#include <iostream>
#include <fstream>
#include <ctime>

int main() 
{
    int nInputOperation;
    std::cout << "\n[0] Log to File\n[1] View Logged Files\n[2] View currrent file content\n[3] Exit" << std::endl;
    std::cout << "Enter the input operation : ";
    std::cin >> nInputOperation;
    while (nInputOperation !=  3)
    {
        switch(nInputOperation)
        {
            case 0:
                std::fstream file("lo.txt", std::ios::app);
                time_t timestamp;
                time(&timestamp);
                file << ctime(&timestamp);
                file.close();
                break;
        }

        std::cout << "\n[0] Log to File\n[1] View Logged Files\n[2] View currrent file content\n[3] Exit" << std::endl;
        std::cout << "Enter the input operation : ";
        std::cin >> nInputOperation;
    }
    return 0;
}
