using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPathFinder
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в программу поиска пути в графе! Для начала нужно задать граф.");
            Console.WriteLine();
            GraphSolver graphsolver = new GraphSolver();
            Console.WriteLine();
            graphsolver.PrintIncidencyMatrix();
            Console.WriteLine();
            while (true) {
                Console.WriteLine("Список команд:");
                Console.WriteLine("1 - задать новый граф");
                Console.WriteLine("2 - задать новые начальную и целевую вершины");
                Console.WriteLine("3 - показать матрицу инцидентности");
                Console.WriteLine("4 - поиск в ширину");
                Console.WriteLine("5 - поиск в глубину");
                Console.WriteLine("6 - рекурсивный поиск в глубину");
                Console.WriteLine("7 - выход");
                Console.WriteLine();
                int value = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (value)
                {
                    case 1:
                        graphsolver.FillGraph();
                        Console.WriteLine();
                        break;
                    case 2:
                        graphsolver.SetStartEnd();
                        Console.WriteLine();
                        break;
                    case 3:
                        graphsolver.PrintIncidencyMatrix();
                        Console.WriteLine();
                        break;
                    case 4:
                        graphsolver.IterationSearch(false);
                        graphsolver.ClearSearch();
                        Console.WriteLine();
                        break;
                    case 5:
                        graphsolver.IterationSearch(true);
                        graphsolver.ClearSearch();
                        Console.WriteLine();
                        break;
                    case 6:
                        graphsolver.RecursiveSearch();
                        graphsolver.ClearSearch();
                        Console.WriteLine();
                        break;
                    case 7:
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
            }
        }


    }
}
