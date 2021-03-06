#include <iostream>
#include <iterator>
#include <vector>
#include <algorithm>

std::ostream &operator<<(std::ostream &o, const std::vector<int> &seq)
{
    std::copy(seq.cbegin(), seq.cend(), std::ostream_iterator<int>(o, " "));
    return o;
}

std::istream &operator>>(std::istream &in, std::vector<int> &seq)
{
    for (int &i : seq)
    {
        in >> i;
    }
    return in;
}

bool IsDecrease(std::vector<int>::iterator i, const std::vector<int>::iterator &end)
{
    for (auto j = (++i) + 1; i < end - 1; i = j, ++j)
    {
        if (*j >= *i)
        {
            return false;
        }
    }
    return true;
}

// find_i(begin, end)
auto FindFirst(std::vector<int>::iterator i, const std::vector<int>::iterator &end)
{
    for (auto j = i + 1; i < end - 1; i = j, ++j)
    {
        if (*i < *j && IsDecrease(i, end))
        {
            return i;
        }
    }
    return end;
}

// find_j(i, end)
auto FindSecond(const std::vector<int>::iterator &first, const std::vector<int>::iterator &end)
{
    auto result = end;
    for (auto i = first + 1; i < end; ++i)
    {
        if ((*i > *first) && ((result == end) || (*i < *result)))
        {
            result = i;
        }
    }
    return result;
}

std::vector<int> Next(std::vector<int> seq)
{
    auto i = FindFirst(seq.begin(), seq.end());
    std::swap(*i, *FindSecond(i, seq.end()));
    std::sort(i + 1, seq.end());
    return seq;
}

int main()
{
    std::vector<int> seq(*std::istream_iterator<int>(std::cin));
    std::cin >> seq;
    std::cout << Next(seq);
}

