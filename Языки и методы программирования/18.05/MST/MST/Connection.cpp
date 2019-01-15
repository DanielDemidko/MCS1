#include "Connection.h"

bool Connection::IsActive() const
{
    return Active;
}

void Connection::Apply()
{
    Active = true;
    A.AddAvailable(B);
    B.AddAvailable(A);
}

void Connection::Cancel()
{
    Active = false;
    A.RemoveAvailable(B);
    B.RemoveAvailable(A);
}

Connection::Connection(Node & a, Node & b): A(a), B(b)
{
    
}
