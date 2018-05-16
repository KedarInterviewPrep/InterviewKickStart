/// Quick Sort is based on -
/// 1. Pivot Selection
/// 2. Partitioning the array
/// 
/// Basic idea is, select a Pivot and place it at its right position in array and
/// in the process, ensure that -
/// less than pivot are to the left of the pivot
/// greater than pivor are to the right of the pivot
/// 
/// Partitioning by array can be done using- 
/// 2 pointers - known as Hoare's Partition
/// 1 Pointer - known as Lamuto's Partition
/// 
/// Here we implement partitioning based on 2 pointers.
/// TODO: Implement partitioning by Lamuto's partitioning./// 
/// Complexity Analysis:
/// At each step we are breaking the array into 2 after each partition and apply partition on those two arrays.
/// Complexity of Partition algorithm is N.
/// Now in the best case, each partition will divide into two equal parts, in that case the number of times we will need to
/// perform this would be log(N). But worst case, the partitions could be skewed (1, and N-1) and in that csae
/// we will end-up doing this N times, making complexity N^2.
/// So it is very important to wisely choose the partition/pivot element. Depending on that, complexities will be 
/// between O(N*log(N)) and O(N^2).
/// Best Case: O(N*log(N))
/// Worst Case: O(N^2)
/// So as we can see choosing a pivot impacts the complexity of quick sort. there are many strategies to pick pivot
/// like - first element, last element, random, middle, median etc.
/// Median will divide the array into two equal halves, but calculating median is of O(N) and this adds a big constant
/// to O(Nlog(N)) complexity almost equal to 1.39 in practice (that is 1.39*N*log(N)), making it not so useful in practice.
/// In practice to improve this, typically we choose 3 random elements and take median of that. That runs for most real-life
/// cases in - (N*log(N)) time without large constant.


using System;

namespace Class.Sorting.SortingAlgorithms
{
    public static class QuickSortAlgo
    {
        public static void QuickSort(int[] arr = null)
        {
            Console.WriteLine("Quick Sort");
            int[] input = { 5, 7, 32, 10, 2, 56, 40, -9, -10, 1000, 89, 18, 4, 1, 200, 35, 76, 19, 41};
            //int[] input = { 5, 7, 32, 10, 2};
            QuickSort(input, 0, input.Length - 1);
            Console.WriteLine(string.Join(", ", input));
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            Console.WriteLine(start + " -> " + end);
            if (start >= end)
                return;

            int pivotIndex = partition(arr, start, end);
            QuickSort(arr, start, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, end);
        }

        private static int partition(int[] arr, int start, int end)
        {
            int left = start + 1;
            int right = end;
            int pivot = arr[start]; // picking start element as pivot.

            while (left <= right)
            {
                while (left <= end && arr[left] < pivot)
                {
                    left++;
                }

                while (right >= start && arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
            }

            int temp2 = arr[right];
            arr[right] = arr[start];
            arr[start] = temp2;

            return right;
        }
    }
}
