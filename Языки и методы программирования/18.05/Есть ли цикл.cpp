#include <iostream>
#include <vector>
#include <iterator>
#include <algorithm>

std::vector<std::vector<int>> GetMatrix() {
    const int size = *std::istream_iterator<int>(std::cin);
    std::vector<std::vector<int>> res(size, std::vector<int>(size));
    for (auto &list : res)
        for (auto &i : list) std::cin >> i;
    return res;
}

std::ostream &operator<<(std::ostream &s, const std::vector<int> &list) {
    std::copy(list.cbegin(), list.cend(), std::ostream_iterator<int>(s, " "));
    return s;
}

void Print(const std::vector<std::vector<int>> &matrix) {
    for (const auto &list : matrix) {
        for (const auto &i : list) std::cout << i << ' ';
        std::cout << std::endl;
    }
}

bool IsLoop(const std::vector<std::vector<int>> &matrix, const int &i = 0, std::vector<int> &&lst = {}) {
    lst.push_back(i);
    for (int j = 0; j < matrix.size(); ++j) {
        if (matrix[i][j] &&
            (std::find(lst.cbegin(), lst.cend(), j) != lst.cend() || IsLoop(matrix, j, std::move(lst))))
            return true;
    }
    return false;
}

int main() {
    std::cout << IsLoop(GetMatrix());
}
