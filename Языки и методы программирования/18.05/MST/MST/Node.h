#pragma once
#include <set>
#include <sstream>

class Node
{
private:
    int Id;
    std::set<std::reference_wrapper<const Node>> Availables;

    void AddAvailable(const Node &link);

    void RemoveAvailable(const Node &link);

    friend class Connection;

public:
    int GetId() const;

    std::set<std::reference_wrapper<const Node>> GetAvailables() const;

    Node();
};

// for std::find
bool operator==(const Node &a, const Node &b);

// for std::set
bool operator<(const Node &a, const Node &b);

// for debug
std::ostream &operator<<(std::ostream &out, const Node &n);

