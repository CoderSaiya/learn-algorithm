using DFS;

namespace BFS
{
    internal class BFSAlgorithm
    {
        private readonly Graph graph;
        private readonly HashSet<int> visited;
        private readonly Queue<int> queue;

        public BFSAlgorithm(Graph graph)
        {
            this.graph = graph;
            this.visited = new HashSet<int>();
            this.queue = new Queue<int>();
        }
        
        public void Traverse(int startVertex)
        {
            if (!graph.GetAdjacencyList().ContainsKey(startVertex))
            {
                Console.WriteLine($"Đỉnh {startVertex} không tồn tại trong đồ thị.");
                return;
            }

            var visited = new HashSet<int>();
            var queue = new Queue<int>();

            visited.Add(startVertex);
            queue.Enqueue(startVertex);

            Console.WriteLine($"Duyệt BFS từ đỉnh {startVertex}:");

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();

                Console.WriteLine($"Đang xử lý đỉnh {currentVertex}");

                foreach (var (neighbor, _) in graph.GetAdjacencyList()[currentVertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}
