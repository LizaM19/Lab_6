using System;
using System.Collections.Generic;


namespace lb_6
{
    class Program
    {
        static void BFSD(int v, int[,] matrix, int[] DIST, int size)
        {
            Queue<int> queue = new Queue<int>(); //Создаем новую очередь
            queue.Enqueue(v); //Помещаем v в очередь

                DIST[v] = 0;

            Console.WriteLine();
            Console.Write("Результат обхода:  ");
            while (queue.Count != 0)
            {
                v  = queue.Dequeue();//Удаляем первый элемент из очереди
                Console.Write(v);
                for (int i = 0; i < size; i++)
                {
                    if ( matrix [v, i] == 1 && DIST[i] == -1)
                    {
                        queue.Enqueue(i); //Помещаем i в очередь
                        DIST[i] = DIST[v] + 1;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите вершину для начала обхода:");
            int v = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите размерность матрицы:");
            int size = Convert.ToInt32(Console.ReadLine());
            int[,] M = new int[size, size];
            int[] DIST = new int[size];
            for (int i = 0; i < size; i++)
            {
                DIST[i] = -1;
            }

            Random random = new Random();
            Console.WriteLine();
            Console.WriteLine("Сгененрированная матрица:\t");

            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    M[i, j] = random.Next(2);
                    M[j, i] = M[i, j];
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{M[i, j]}, \t");
                }
                Console.WriteLine();
            }
             BFSD(v, M, DIST, size);
            Console.WriteLine("\n");
            Console.Write("Расстояния:  ");
            for (int i = 0; i < size; i++)
            {
                Console.Write(DIST[i]);
            }
        }
    }
}
