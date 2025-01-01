using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandEscape
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[,] island = new int[N,N];
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                {
                    island[i,j] = int.Parse(inputs[j]);
                }
            }
            Console.WriteLine(canReachOcean(island, N) ? "yes" : "no");
        }

        static bool canReachOcean(int[,] island, int N)
        {
            int startX = N / 2;
            int startY = N / 2;

            int[] mX = {-1, 1, 0, 0};
            int[] mY = {0, 0, -1, 1};
            
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            bool[,] visited = new bool[N,N];
            
            queue.Enqueue(new Tuple<int, int>(startX, startY));
            visited[startX, startY] = true;

            while (queue.Count > 0) 
            {
                var current = queue.Dequeue();
                int x = current.Item1;
                int y = current.Item2;

                if (x == 0 || x == N - 1 || y == 0 || y == N - 1)
                {
                    return true;
                }

                for (int i = 0; i < 4; i++)
                {
                    int newX = x + mX[i];
                    int newY = y + mY[i];

                    if (newX >= 0 && newX < N && newY >= 0 && newY < N && !visited[newX, newY])
                    {
                        if (Math.Abs(island[x,y] - island[newX,newY]) <= 1)
                        {
                            visited[newX, newY] = true;
                            queue.Enqueue(new Tuple<int, int>(newX, newY));
                        }
                    }
                }
            }
            return false;
        }
    }
}
