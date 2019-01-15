#include "Node.h"

bool Node::HasNoChild()
{
    return Right == nullptr && Left == nullptr;
}

bool Node::HasTwoChild()
{
    return Right != nullptr && Left != nullptr;
}

bool Node::HasOnlyChild()
{
    return !HasNoChild() && !HasTwoChild();
}

Node*const Node::CutOneChild()
{
    if (HasNoChild())
    {
        return nullptr;
    }
    Node *&link = ((Left == nullptr) ? Right : Left);
    Node *const res = link;
    link = nullptr;
    return res;
}

Node::Node(const int n): Number(n) {}

Node::~Node()
{
    delete Right;
    delete Left;
}

std::ostream & operator<<(std::ostream &o, const Node &n)
{
    o << n.Number<<"; ";
    if (n.Left != nullptr)
    {
        o << *n.Left;
    }
    if (n.Right != nullptr)
    {
        o << *n.Right;
    }
    return o;
}
