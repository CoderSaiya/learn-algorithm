using System.IO;

namespace DFS
{
    internal class Graph
    {
        private readonly Dictionary<int, List<(int neighbor, int weight)>> _adjacencyList;

        public Graph()
        {
            _adjacencyList = new Dictionary<int, List<(int neighbor, int weight)>>();
        }

        public void AddVertex(int vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
            {
                _adjacencyList[vertex] = new List<(int neighbor, int weight)>();
            }
        }

        public void AddEdge(int source, int destination, int weight)
        {
            if (!_adjacencyList.ContainsKey(source))
            {
                AddVertex(source);
            }
            if (!_adjacencyList.ContainsKey(destination))
            {
                AddVertex(destination);
            }
            _adjacencyList[source].Add((destination, weight));
            _adjacencyList[destination].Add((source, weight)); //vi la do thi vo huong, do thi co huong bo dong nay
        }

        public void ReadListFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                int[] parts = line.Split(' ')
                                 .Where(x => !string.IsNullOrWhiteSpace(x))
                                 .Select(x => int.TryParse(x, out int value) ? value : 0)
                                 .ToArray();

                if (parts.Length == 3)
                {
                    AddEdge(parts[0], parts[1], parts[2]);
                }
            }
        }

        public void PrintGraph()
        {
            if (_adjacencyList.Count == 0) return;

            // Create a dictionary to store coordinates for each vertex
            Dictionary<int, (int x, int y)> coordinates = new Dictionary<int, (int x, int y)>();

            // Calculate coordinates for each vertex in a circular layout
            int radius = 10;
            int centerX = 40;
            int centerY = 15;
            double angleStep = 2 * Math.PI / _adjacencyList.Count;

            int i = 0;
            foreach (var vertex in _adjacencyList.Keys)
            {
                int x = centerX + (int)(radius * Math.Cos(i * angleStep));
                int y = centerY + (int)(radius * Math.Sin(i * angleStep));
                coordinates[vertex] = (x, y);
                i++;
            }

            // Create a 2D array to represent the console screen
            char[,] screen = new char[centerY * 2 + 1, centerX * 2 + 1];
            for (int y = 0; y < screen.GetLength(0); y++)
                for (int x = 0; x < screen.GetLength(1); x++)
                    screen[y, x] = ' ';

            // Draw edges
            foreach (var vertex in _adjacencyList.Keys)
            {
                foreach (var (neighbor, weight) in _adjacencyList[vertex])
                {
                    if (vertex < neighbor)
                    {
                        DrawLine(screen,
                            coordinates[vertex].x, coordinates[vertex].y,
                            coordinates[neighbor].x, coordinates[neighbor].y,
                            weight.ToString());
                    }
                }
            }

            // Draw vertices
            foreach (var vertex in _adjacencyList.Keys)
            {
                var (x, y) = coordinates[vertex];
                screen[y, x] = 'O';

                // Draw vertex number
                string number = vertex.ToString();
                for (int j = 0; j < number.Length; j++)
                {
                    if (x + j + 1 < screen.GetLength(1))
                        screen[y, x + j + 1] = number[j];
                }
            }

            // Print the screen
            for (int y = 0; y < screen.GetLength(0); y++)
            {
                for (int x = 0; x < screen.GetLength(1); x++)
                {
                    Console.Write(screen[y, x]);
                }
                Console.WriteLine();
            }
        }

        // Helper method to draw a line between two points
        private void DrawLine(char[,] screen, int x1, int y1, int x2, int y2, string weight)
        {
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;
            int err = dx - dy;

            bool weightDrawn = false;
            while (true)
            {
                if (y1 >= 0 && y1 < screen.GetLength(0) &&
                    x1 >= 0 && x1 < screen.GetLength(1))
                {
                    screen[y1, x1] = '*';

                    if (!weightDrawn && Math.Abs(x1 - x2) + Math.Abs(y1 - y2) < Math.Max(dx, dy) / 2)
                    {
                        int wx = x1 + (x2 - x1) / 2;
                        int wy = y1 + (y2 - y1) / 2;

                        for (int i = 0; i < weight.Length; i++)
                        {
                            if (wy >= 0 && wy < screen.GetLength(0) && wx + i < screen.GetLength(1))
                            {
                                screen[wy, wx + i] = weight[i];
                            }
                        }
                        weightDrawn = true;
                    }
                }

                if (x1 == x2 && y1 == y2) break;
                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }
            }
        }

        public Dictionary<int, List<(int neighbor, int weight)>> GetAdjacencyList()
        {
            return _adjacencyList;
        }
    }
}
