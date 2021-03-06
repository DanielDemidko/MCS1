#include <iostream>
#include <iterator>
#include <vector>

std::ostream &operator<<(std::ostream &o, const std::vector<int> &seq)
{
    std::copy(seq.cbegin(), seq.cend(), std::ostream_iterator<int>(o));
    return o;
}

std::vector<int> Seq(const int to)
{
    std::vector<int> result(to);
    for (int i = 0; i < to; ++i)
    {
        result[i] = i + 1;
    }
    return result;
}

std::vector<std::vector<int>> GetPermutations(const std::vector<int> &start)
{
    if (start.size() == 1)
    {
        return { start };
    }
    if (start.size() == 2)
    {
        return { start, {start.back(), start.front()} };
    }
    std::vector<std::vector<int>> res;
    for (int i = 0; i < start.size(); ++i)
    {
        auto copy = start;
        copy.erase(copy.begin() + i);
        auto tmpRes = GetPermutations(copy);
        for (std::vector<int> &j : tmpRes)
        {
            j.insert(j.begin(), start[i]);
            res.push_back(std::move(j));
        }
    }
    return res;
}

int main()
{
    for (const auto &i : GetPermutations(Seq(*std::istream_iterator<int>(std::cin))))
    {
        std::cout << i << std::endl;
    }
}

