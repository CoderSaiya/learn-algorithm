namespace DFS
{
    internal class DFSAlgorithm
    {
        private readonly HashSet<int> _visited;

        public DFSAlgorithm()
        {
            _visited = new HashSet<int>();
        }

        public void DFS(Graph graph, int startVertex)
        {
            _visited.Clear();
            Console.WriteLine("DFS traversal:");
            DFSRecursive(graph, startVertex);
        }

        private void DFSRecursive(Graph graph, int vertex)
        {
            if (_visited.Contains(vertex)) return;

            _visited.Add(vertex);
            Console.WriteLine(vertex);

            foreach (var (neighbor, weight) in graph.GetAdjacencyList()[vertex])
            {
                if (!_visited.Contains(neighbor))
                {
                    DFSRecursive(graph, neighbor);
                }
            }
        }
    }
}
