using BubbleSort;

BubbleAlgorithm<int> bubble = new BubbleAlgorithm<int>((x, y) => x > y); //bieu thuc lamda, (x<y) la giam dan, (x>y) la tang dan doi voi int
bubble.ReadArrayFromFile("../../../testcase1.txt");
bubble.PrintArray();
bubble.BubbleSort();

bubble.ReadArrayFromFile("../../../testcase2.txt");
bubble.PrintArray();
bubble.BubbleSort();

BubbleAlgorithm<string> bubbleString = new BubbleAlgorithm<string>((x, y) => string.Compare(x, y) > 0);
bubbleString.ReadArrayFromFile("../../../testcase3.txt");
bubbleString.PrintArray();
bubbleString.BubbleSort();