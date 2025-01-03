using InsertionSort;

InsertionAlgorithm<int> insertion = new InsertionAlgorithm<int>((x, y) => x > y);
insertion.ReadArrayFromFile("../../../testcase1.txt");
insertion.PrintArray();
insertion.InsertionSort();

insertion.ReadArrayFromFile("../../../testcase2.txt");
insertion.PrintArray();
insertion.InsertionSort();

InsertionAlgorithm<string> insertionString = new InsertionAlgorithm<string>((x , y) => string.Compare(x, y) > 0);
insertionString.ReadArrayFromFile("../../../testcase3.txt");
insertionString.PrintArray();
insertionString.InsertionSort();