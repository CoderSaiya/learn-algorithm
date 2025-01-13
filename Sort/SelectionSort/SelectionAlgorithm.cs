namespace SelectionSort
{
    internal class SelectionAlgorithm<T>
    {
        private T[] array;
        private Func<T, T, bool> compare;

        public SelectionAlgorithm(T[] array, Func<T, T, bool> compare)
        {
            this.array = array;
            this.compare = compare;
        }

        public SelectionAlgorithm(Func<T, T, bool> compare)
        {
            this.array = new T[0];
            this.compare = compare;
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

        public void SelectionSort()
        {
            int aim;
            for(int i = 0; i < array.Length - 1; i++)
            {
                aim = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (compare(array[j], array[aim])) aim = j;
                }

                if (!object.Equals(array[i], array[aim])) Swap(ref array[i], ref array[aim]);
            }
            PrintSolution();
        }

        private void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public void PrintSolution()
        {
            Console.WriteLine("Sorted array:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
