using DFS;

var graph = new Graph();

graph.AddEdge(1, 2, 5);
graph.AddEdge(1, 3, 5);
graph.AddEdge(2, 4, 2);
graph.AddEdge(3, 5, 1);
graph.AddEdge(4, 6, 3);

graph.PrintGraph();

var dfs = new DFSAlgorithm();

dfs.DFS(graph, 1);

var graph2 = new Graph();
graph2.ReadListFromFile("../../../testcase1.txt");
graph.PrintGraph();
dfs.DFS(graph2, 1);