#pragma once
#include <ostream>

struct Node
{
    const int Number = 0;
    Node *Right = nullptr, *Left = nullptr;

    bool HasNoChild();

    bool HasTwoChild();

    bool HasOnlyChild();

    Node *const CutOneChild();

    Node(const int);
    ~Node();
};

std::ostream &operator<<(std::ostream &o, const Node &n);
