namespace InsertionSort
{
    internal class InsertionAlgorithm<T>
    {
        private T[] array;
        private Func<T, T, bool> compare;

        public InsertionAlgorithm(T[] array, Func<T, T, bool> compare)
        {
            this.array = array;
            this.compare = compare;
        }

        public InsertionAlgorithm(Func<T, T, bool> compare)
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

        public void InsertionSort()
        {
            for(int i = 1; i < this.array.Length; i++)
            {
                T key = this.array[i];
                int j = i - 1;

                while (j >= 0 && compare(array[j], key))
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
            PrintSolution();
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
