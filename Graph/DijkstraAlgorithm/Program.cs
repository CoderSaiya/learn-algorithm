using DijkstraAlgorithm;

Console.WriteLine("Dijkstra Algorithm");

Dijkstra dijkstra = new Dijkstra();

string[] filePaths = ["../../../testcase1.txt", "../../../testcase2.txt"];

foreach (string path in filePaths)
{
    Console.WriteLine("\nReading graph from file: " + path);
    dijkstra.ReadGraphFromFile(path);
    Console.WriteLine("Graph:");
    dijkstra.WriteMatrix(dijkstra.Graph);
    Console.WriteLine("\nRunning Dijkstra Algorithm...");
    dijkstra.DijkstraAlgo(0);
    Console.WriteLine();
}