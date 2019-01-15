#include "Tools.h"

Node *const Tools::Find(Node *const root, const int number)
{
    for (Node *i = root; i != nullptr; i = ((number > i->Number) ? i->Right : i->Left))
    {
        if (number == i->Number)
        {
            return i;
        }
    }
    return nullptr;
}

bool Tools::IsNumber(Node * const p, const int number)
{
    return p != nullptr && p->Number == number;
}

#include <iostream>
void Tools::Remove(Node *& pointer)
{
    std::cout << "Pointer: " << pointer->Number << std::endl;
    // Нет потомков
    if (pointer->HasNoChild())
    {
        std::cout << "No child\n";
        delete pointer;
        pointer = nullptr;
        return;
    }
    // Один потомок
    if (pointer->HasOnlyChild())
    {
        std::cout << "Only child\n";
        Node *const tmp = pointer->CutOneChild();
        std::cout <<"Only child: "<< tmp->Number << std::endl;
        delete pointer;
        pointer = tmp;
        return;
    }
    std::cout << "Two child\n";
    // Два потомка
    Node *const right = pointer->Right;
    Node *const left = pointer->Left;
    pointer->Right = nullptr;
    pointer->Left = nullptr;
    if (right->HasNoChild())
    {
        delete pointer;
        pointer = right;
        pointer->Left = left;
        return;
    }
    Node *leftest = nullptr;
    for (Node *preLeftest = right;; preLeftest = preLeftest->Left)
    {
        if (preLeftest->HasOnlyChild())
        {
            leftest = preLeftest->CutOneChild();
            break;
        }
        if (preLeftest->HasTwoChild() && preLeftest->Left->HasNoChild())
        {
            leftest = preLeftest->Left;
            preLeftest->Left = nullptr;
            break;
        }
    }
    pointer = leftest;
    pointer->Left = left;
    pointer->Right = right;
}
