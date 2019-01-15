#pragma once
#include "Node.h"

class Connection
{
private:
    Node & A;
    Node & B;
    bool Active = false;
    
public:
    bool IsActive() const;

    void Apply();

    void Cancel();

    Connection(Node &a, Node &b);
};

