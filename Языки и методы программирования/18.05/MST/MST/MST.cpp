#include <iostream>
#include <iterator>
#include <vector>
#include "Connection.h"


std::vector<Node> GetNodes()
{
    return std::vector<Node>(*std::istream_iterator<int>(std::cin));
}

std::vector<Connection> GetConnections()
{

}

int main()
{
    auto readInt = [] { return *std::istream_iterator<int>(std::cin); };
    std::vector<Node> memory(readInt());
    std::vector<Connection> connections;
    const int connectionsSize = readInt();
    for (int i = 0; i < connectionsSize; ++i)
    {
        connections.emplace_back(memory[readInt() - 1], memory[readInt() - 1]);
    }
    
}

