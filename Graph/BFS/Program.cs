var graph = new DFS.Graph();

graph.AddEdge(1, 2, 5);
graph.AddEdge(1, 3, 5);
graph.AddEdge(2, 4, 2);
graph.AddEdge(3, 5, 1);
graph.AddEdge(4, 6, 3);

Console.WriteLine("Đồ thị:");
graph.PrintGraph();

var bfs = new BFS.BFSAlgorithm(graph);

bfs.Traverse(1);