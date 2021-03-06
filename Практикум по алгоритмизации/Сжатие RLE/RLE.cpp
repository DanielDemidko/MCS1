#include <iostream>
#include <string>
#include <string_view>

// Сжать строку
std::string EncodeRLE(const std::string_view line)
{
    std::string result;
    for (auto i = line.cbegin(); i < line.cend(); ++i)
    {
        int repeats = 1;
        const auto symbol = *i;
        for (auto j = i + 1; (j < line.cend()) && (*j == symbol); ++j)
        {
            ++repeats;
            i = j;
        }
        (result += repeats) += symbol;
    }
    return result;
}

// Распаковать строку
std::string DecodeRLE(const std::string_view line)
{
    std::string result;
    for (auto i = line.cbegin(); i < line.cend(); i += 2)
    {
        result.append(*i, *(i + 1));
    }
    return result;
}

// Вернуть RLE в читаемом представлении
std::string GetRLE(const std::string_view line)
{
    std::string result;
    for (auto i = line.cbegin(); i < line.cend(); i += 2)
    {
        result += '(';
        result += *(i + 1);
        result += " - ";
        result += std::to_string(*i);
        result += ") ";
    }
    return result;
}

int main()
{
    std::string buffer;
    while (std::cout << ">>> ", std::getline(std::cin, buffer))
    {
        const auto rle = EncodeRLE(buffer);
        std::cout
            << "Encoded text as bytes: " << rle << std::endl
            << "Encoded text as string: " << GetRLE(rle) << std::endl
            << "Decoded text: " << DecodeRLE(rle) << std::endl;
    }
}

