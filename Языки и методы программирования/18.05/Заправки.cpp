#include <iostream>
#include <vector>

// Город
struct City
{
    // Номер города
    int Id;
    // Города в которые можно попасть
    std::vector<City*> Next;
    // Цена дороги до них
    int Price;

    // Вес вершины для алгоритма Дейкстры
    int _Weight = -1;

    // Алгоритм Дейкстры
    void Dijkstra()
    {
        //std::cout << "Ищем пути из города " << Id << ':'<< std::endl;
        const auto nextweight = _Weight + Price;
        for (auto i : Next)
        {
            if (nextweight < i->_Weight || i->_Weight == -1)
            {
                //std::cout << "    " << "Можно попасть в город " << i->Id << ", это будет стоить " << nextweight << '$' << std::endl;
                i->_Weight = nextweight;
                i->Dijkstra();
            }
        }
    }
};

int GetPrice(std::vector<City> &cities, const int from, const int to)
{
    cities[from]._Weight = 0;
    cities[from].Dijkstra();
    return cities[to]._Weight;
}

int main(const int argc, const char *const *const argv)
{
    //setlocale(LC_ALL, "");
    int n;
    std::cin >> n;
    std::vector<City> cities(n);
    for (int i = 0; i < cities.size(); ++i)
    {
        cities[i].Id = i + 1;
        std::cin >> cities[i].Price;
    }
    int m;
    std::cin >> m;
    for (int i = 0, a, b; i < m; ++i)
    {
        std::cin >> a >> b;
        --a;
        --b;
        cities[a].Next.push_back(&cities[b]);
        cities[b].Next.push_back(&cities[a]);
    }
    std::cout << GetPrice(cities, 0, cities.size() - 1) << std::endl;

}
