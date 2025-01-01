namespace DijkstraAlgorithm
{
    internal class Dijkstra
    {
        private int[,]? graph;
        private int numNodes;

        public int[,] Graph
        {
            get => graph;
            set => graph = value;
        }

        public void ReadGraphFromFile(string filepath)
        {
            string[] lines = File.ReadAllLines(filepath);

            numNodes = int.Parse(lines[0]);

            graph = new int[numNodes, numNodes];
            for (int i = 0; i < numNodes; i++)
            {
                string[] weights = lines[i + 1].Split(' ');
                for (int j = 0; j < numNodes; j++)
                {
                    graph[i, j] = int.Parse(weights[j]);
                }
            }
        }

        public void WriteMatrix(int[,] graph)
        {
            for (int i = 0; i < numNodes; i++)
            {
                for (int j = 0; j < numNodes; j++)
                {
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void DijkstraAlgo(int source)
        {
            int[] distance = new int[numNodes];
            Boolean[] visited = new Boolean[numNodes];

            // Initialize values
            for (int i = 0; i < numNodes; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }
            distance[source] = 0;

            for (int i = 0; i < numNodes - 1; i++)
            {
                int u = MinDistance(distance, visited);
                visited[u] = true;
                for (int v = 0; v < numNodes; v++)
                {
                    if (!visited[v] && graph[u, v] != 0 && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                    }
                }
            }

            PrintSolution(distance);
        }

        public int MinDistance(int[] distance, Boolean[] visited)
        {
            int min = int.MaxValue;
            int minIndex = -1;
            for (int i = 0; i < distance.Length; i++)
            {
                if (!visited[i] && distance[i] <= min)
                {
                    min = distance[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public void PrintSolution(int[] distance)
        {
            Console.WriteLine("Vertex \t Distance from Source");
            for (int i = 0; i < distance.Length; i++)
            {
                Console.WriteLine(i + " \t " + distance[i]);
            }
        }
    }
}
