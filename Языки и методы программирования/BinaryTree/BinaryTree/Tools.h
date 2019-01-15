#pragma once
#include "Node.h"
#include <tuple>

namespace Tools
{
    Node *const Find(Node *const root, const int number);

    bool IsNumber(Node *const p, const int number);

    void Remove(Node *&pointer);
}