#include <iostream>
#include <random>
#include <vector>
#include <string>
#include <iterator>

void Split(int num, std::vector<int> &buf, int curr, std::vector<std::vector<int>> &res) 
{   
    if (num <= 0) 
    { 
        res.push_back({});
        std::copy(buf.cbegin(), buf.cbegin() + curr, std::back_inserter(res.back()));
        return; 
    }    
    for (int i = ((curr > 0) ? buf[curr - 1]: 1); i <= num; ++i)
    {    
        buf[curr] = i;
        Split(num - i, buf, curr + 1, res);      
    }
}

int main(const int argc, const char *const *const argv)
{
    int n;
    std::cin >> n;
    std::vector<int> a(n);
    std::vector<std::vector<int>> res;
    Split(n, a, 0, res);
    for (auto i = res.crbegin(); i < res.crend(); ++i)
    {
        for (const auto &j : *i)
        {
            std::cout << j << ' ';
        }
        std::cout << std::endl;
    }
}
