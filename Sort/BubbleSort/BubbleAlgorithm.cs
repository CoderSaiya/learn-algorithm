namespace BubbleSort
{
    internal class BubbleAlgorithm<T>
    {
        private T[] array;
        private Func<T, T, bool> compare;
        public BubbleAlgorithm(T[] array, Func<T, T, bool> compare)
        {
            this.array = array;
            this.compare = compare;
        }

        public BubbleAlgorithm(Func<T, T, bool> compare)
        {
            this.array = new T[0];
            this.compare = compare;
        }

        private void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public void ReadArrayFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            array = new T[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                if (typeof(T) == typeof(string))
                {
                    array[i] = (T)(object)lines[i];
                }
                else
                {
                    array[i] = (T)Convert.ChangeType(lines[i], typeof(T));
                }
            }
        }

        public void PrintArray()
        {
            Console.WriteLine("Array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
        }

        public void BubbleSort()
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (compare(array[j], array[j + 1]))
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
            PrintSolution();
        }

        public void PrintSolution()
        {
            Console.WriteLine("Sorted array:");
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
