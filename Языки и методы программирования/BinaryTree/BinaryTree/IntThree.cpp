#include "IntThree.h"
#include "Tools.h"
#include <optional>

bool IntThree::Contains(const int number) const
{
    return Tools::Find(Root, number) != nullptr;
}

bool IntThree::Remove(const int number)
{
    for (Node *i = Root; i != nullptr; i = ((number > i->Number) ? i->Right : i->Left))
    {
        if (Tools::IsNumber(i, number))
        {
            Tools::Remove(i);
            return true;
        }
    }
    return false;
}

void IntThree::Append(const int number)
{
    if (Root == nullptr)
    {
        Root = new Node(number);
        return;
    }
    for (Node *curr = Root; (curr->Number != number);)
    {
        Node *&next = ((number > curr->Number) ? curr->Right : curr->Left);
        if (next == nullptr)
        {
            next = new Node(number);
            return;
        }
        curr = next;
    }
}

IntThree::~IntThree()
{
    delete Root;
}

std::ostream & operator<<(std::ostream &printer, const IntThree &three)
{
    if (three.Root != nullptr)
    {
        printer << *three.Root;
    }
    return printer;
}
