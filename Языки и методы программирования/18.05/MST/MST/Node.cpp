#include "Node.h"

int Node::GetId() const
{
    return Id;
}

std::set<std::reference_wrapper<const Node>> Node::GetAvailables() const
{
    return Availables;
}

void Node::AddAvailable(const Node & link)
{
    if (std::find(Availables.cbegin(), Availables.cend(), link) == Availables.cend())
    {
        Availables.emplace(link);
    }
}

void Node::RemoveAvailable(const Node & link)
{
    if (auto it = std::find(Availables.cbegin(), Availables.cend(), link); it != Availables.cend())
    {
        Availables.erase(it);
    }
}

Node::Node()
{
    static int currentId = -1;
    Id = ++currentId;
}

bool operator==(const Node & a, const Node & b)
{
    return a.GetId() == b.GetId();
}

bool operator<(const Node & a, const Node & b)
{
    return a.GetId() < b.GetId();
}

std::ostream & operator<<(std::ostream & out, const Node & n)
{
    return out << "(Node " << n.GetId() << ")";
}
