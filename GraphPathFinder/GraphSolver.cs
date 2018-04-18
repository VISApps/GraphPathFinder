using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPathFinder
{
    class GraphSolver
    {
        private int n = 0, start = 0, end = 0;
        private int[,] incmatrix;
        List<int> open = new List<int>();
        List<int> closed = new List<int>();
        List<Node> nodes = new List<Node>();
        int result = 0;

        public GraphSolver() {
            FillGraph();
        }

        public void FillGraph() {
            n = 0; start = 0; end = 0;
            Console.WriteLine("Введите кол-во вершин");
            n = Convert.ToInt32(Console.ReadLine());
            incmatrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    incmatrix[i, j] = 0;
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Веедите дочерние вершины {0} вершины. Если вершин нет, введите 0", i + 1);
                String[] values = Console.ReadLine().Split(' ');
                int[] numbers = Array.ConvertAll(values, int.Parse);
                if (numbers[0] != 0)
                {
                    foreach (int number in numbers)
                    {
                        incmatrix[i, number - 1] = 1;
                    }
                }
            }
            Console.WriteLine("Введите начальную вершину:");
            start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите целевую вершину:");
            end = Convert.ToInt32(Console.ReadLine());
        }

        public void SetStartEnd() {
            Console.WriteLine("Введите начальную вершину:");
            start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите целевую вершину:");
            end = Convert.ToInt32(Console.ReadLine());
        }

        public void ClearSearch() {
            open.Clear();
            closed.Clear();
            nodes.Clear();
            result = 0;
        }

        public void PrintIncidencyMatrix() {
            Console.WriteLine("Задана матрица инцидентности:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(incmatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void IterationSearch(bool dodepth)
        {
            if (dodepth)
            {
                Console.WriteLine("Начинаем поиск в глубину");
            }
            else {
                Console.WriteLine("Начинаем поиск в ширину");
            }
            open.Add(start);
            while (true)
            {
                if (open.Count == 0)
                {
                    Console.WriteLine("Путь не найден");
                    break;
                }
                else
                {
                    result++;
                    int x = open[0];
                    Console.WriteLine("Раскрываем вершину " + x);
                    open.RemoveAt(0);
                    closed.Add(x);
                    if (x == end)
                    {
                        Console.WriteLine("Найдена целевая вершина");
                        findpath();
                        Console.WriteLine("Число шагов: " + result);
                        break;
                    }
                    else
                    {
                        List<int> childs = findchilds(x);
                        if (dodepth)
                        {
                            open.InsertRange(0, childs);
                        }
                        else
                        {
                            open.AddRange(childs);
                        }
                    }
                }
            }
        }

        public void RecursiveSearch() {
            Console.WriteLine("Начинаем рекурсивный поиск в глубину");
            List<int> path = new List<int>();
            path.Add(start);
            bool ispathexists = DepthSearch(start, path);
            if (ispathexists) {
                Console.WriteLine("Число шагов: " + result);
            }
        }

        private bool DepthSearch(int x, List<int> path) {
            Console.WriteLine("Раскрываем вершину " + x);
            if (x == end)
            {
                Console.WriteLine("Найдена целевая вершина");
                Console.Write("Путь: ");
                foreach (int p in path)
                {
                    Console.Write(p + " ");
                }
                Console.WriteLine();
                return true;
            }
            else {
                result++;
                closed.Add(x);
                List<int> childs = findchilds(x);
                foreach (int child in childs) {
                    path.Add(child);
                    if (DepthSearch(child, path)) {
                        return true;
                    }
                }
                
            }
            Console.WriteLine("Путь не найден");
            return false;

        }

        private List<int> findchilds(int x)
        {
            List<int> childs = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (incmatrix[x - 1, i] == 1)
                {
                    int child = i + 1;
                    if (!open.Contains(child) && !closed.Contains(child))
                    {
                        childs.Add(child);
                        nodes.Add(new Node(child, x));
                        Console.WriteLine("Потомок " + child);
                    }
                }
            }
            return childs;
        }

        private void findpath()
        {
            List<int> path = new List<int>();
            int x = end;
            path.Add(x);
            while (true)
            {
                if (x == start)
                {
                    break;
                }
                foreach (Node nd in nodes)
                {
                    if (nd.child == x)
                    {
                        x = nd.parent;
                        path.Add(x);
                    }
                }
            }
            path.Reverse();
            Console.Write("Путь: ");
            foreach (int p in path)
            {
                Console.Write(p + " ");
            }
            Console.WriteLine();
        }
    }
}
