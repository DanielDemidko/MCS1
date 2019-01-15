#pragma once
#include <ostream>
#include "Node.h"

class IntThree
{
private:
    Node * Root = nullptr;

public:
    bool Contains(const int number) const;

    bool Remove(const int number);

    void Append(const int number);

    ~IntThree();

    friend std::ostream &operator<<(std::ostream&, const IntThree&);
};
