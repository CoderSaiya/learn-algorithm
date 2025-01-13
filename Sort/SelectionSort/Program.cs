using SelectionSort;

SelectionAlgorithm<int> selection = new SelectionAlgorithm<int>((x, y) => x < y);
selection.ReadArrayFromFile("../../../testcase1.txt");
selection.PrintArray();
selection.SelectionSort();

selection.ReadArrayFromFile("../../../testcase2.txt");
selection.PrintArray();
selection.SelectionSort();

SelectionAlgorithm<string> selectionString = new SelectionAlgorithm<string>((x, y) => string.Compare(x, y) < 0);
selectionString.ReadArrayFromFile("../../../testcase3.txt");
selectionString.PrintArray();
selectionString.SelectionSort();