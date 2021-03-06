#include <iostream>
#include <vector>
#include <fstream>
#include <algorithm>

struct Node
{
    struct Path
    {
        Node &Link;
        const int Length;
    };

    std::vector<Path> AvailableNodes;
    int DijkstraWeight = -1;
};

std::vector<Node> ReadGraph()
{
    std::ifstream input("input.txt");
    int nodes, paths;
    input >> nodes >> paths;
    std::vector<Node> result(nodes);
    for (int i = 0, a, b, len; i < paths; ++i)
    {
        input >> a >> b >> len;
        --a;
        --b;
        result[a].AvailableNodes.push_back({ result[b], len });
        result[b].AvailableNodes.push_back({ result[a], len });
    }
    return result;
}

void DijkstraAlgorithm(Node &self, const bool isFirstCall = true)
{
    if (isFirstCall)
    {
        self.DijkstraWeight = 0;
    }
    for (auto &i : self.AvailableNodes)
    {
        const int len = self.DijkstraWeight + i.Length;
        if (i.Link.DijkstraWeight == -1 || len < i.Link.DijkstraWeight)
        {
            i.Link.DijkstraWeight = len;
            DijkstraAlgorithm(i.Link, false);
        }
    }
}

int MaxLegthFromNode(std::vector<Node> graph, const int index)
{
    DijkstraAlgorithm(graph[index]);
    return std::max_element(graph.cbegin(), graph.cend(), [](const auto &a, const auto &b)
    {
        return a.DijkstraWeight < b.DijkstraWeight;
    })->DijkstraWeight;
}

int MaxLengthInGraph(const std::vector<Node> &graph)
{
    int res = -1;
    for (int i = 0; i < graph.size(); ++i)
    {
        const int r = MaxLegthFromNode(graph, i);
        if (res == -1 || r > res)
        {
            res = r;
        }
    }
    return res;
}

int main()
{
    std::cout << MaxLengthInGraph(ReadGraph()) << std::endl;
}
