#include <iostream>
#include <string>
#include <fstream>
#include <map>
#include <algorithm> 
#include <vector>

/**
 * @brief Comparator function to sort pairs by key.
 * 
 * @param firstPair First pair.
 * @param secondPair Second pair.
 * 
 * @return true if key of first input is greater than that of second input.
 */
bool compareByKey(const std::pair<std::string, int>& firstPair, const std::pair<std::string, int>& secondPair) 
{ 
    return firstPair.first < secondPair.first; 
} 

/**
 * @brief Comparator function to sort pairs by value.
 * 
 * @param firstPair First pair.
 * @param secondPair Second pair.
 * 
 * @return true if value of first input is greater than that of second input.
 */
bool compareByValue(const std::pair<std::string, int>& firstPair, const std::pair<std::string, int>& secondPair) 
{ 
    return firstPair.second > secondPair.second; 
} 

/**
 * @brief Reads firstPair file and counts the frequency of each word in firstPair case-insensitive manner.
 * 
 * @param strFilePath The path to the input file.
 * 
 * @return A map with words as keys and their frequencies as values.
 */
std::map<std::string, int> CalculateWordFrequency(const std::string &strFilePath)
{
    std::ifstream file(strFilePath);
    if (!file)
    {
        std::cout << "Error: Could not open file " << strFilePath << std::endl;
        return {};
    }

    std::string strFileContent;
    std::map<std::string, int> wordsCount;

    while (file >> strFileContent)
    {
        std::transform(strFileContent.begin(), strFileContent.end(), strFileContent.begin(), [](char fileCharacter) { return std::tolower(fileCharacter); });

        wordsCount[strFileContent]++;
    }

    return wordsCount;
}

int main()
{
    std::map<std::string, int> wordsCount = CalculateWordFrequency("TestFile.txt");
    std::vector<std::pair<std::string, int> > vecWordsFrequency; 
    for (auto& wordFrequency : wordsCount) 
    { 
        vecWordsFrequency.push_back(wordFrequency); 
    } 

    std::sort(vecWordsFrequency.begin(), vecWordsFrequency.end(), compareByValue);
    if(vecWordsFrequency.size() > 10)
    {
        vecWordsFrequency.erase(vecWordsFrequency.begin() + 10, vecWordsFrequency.end());
    }
    std::sort(vecWordsFrequency.begin(), vecWordsFrequency.end(), compareByKey);
    
    for(const auto& wordCount : vecWordsFrequency)
    {
        std::cout << "Word: " << wordCount.first << " --> Frequency: " << wordCount.second << std::endl;
    }

    return 0;
}
