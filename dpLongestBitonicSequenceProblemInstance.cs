using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class dpLongestBitonicSequenceProblemInstance
    {
        public static void Main1()
        {
            int[] nums = new int[] { 12, 18, 7, 34, 30, 28, 90, 88 };
            int[] longestSubsequenceIncreasingAtIndex = new int[nums.Length];
            int[] longestSubsequenceDecreasingAtIndex = new int[nums.Length];
            List<int> longestSubsequenceIncreasingList = new List<int>();
            List<int> longestSubsequenceDecreasingList = new List<int>();

            longestSubsequenceDecreasingList.Add(nums[0]);
            longestSubsequenceIncreasingList.Add(nums[0]);

            longestSubsequenceIncreasingAtIndex[0] = 1;
            longestSubsequenceDecreasingAtIndex[0] = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                BinarySearchThenAddIncreasing(longestSubsequenceIncreasingList, nums[i], 0, longestSubsequenceIncreasingList.Count - 1, i, longestSubsequenceIncreasingAtIndex);
            }
            for (int i = 1; i < nums.Length; i++)
            {
                BinarySearchThenAddDecreasing(longestSubsequenceDecreasingList, nums[i], 0, longestSubsequenceDecreasingList.Count - 1, i, longestSubsequenceDecreasingAtIndex);
            }
            //Console.WriteLine(longestSubsequenceIncreasingList.Count);
            //Console.WriteLine(longestSubsequenceDecreasingList.Count);
            int maxOfMixNumbers = 0;
            for (int i = 0; i < nums.Length -1; i++)
            {
                maxOfMixNumbers = Math.Max(maxOfMixNumbers, longestSubsequenceIncreasingAtIndex[i] + (longestSubsequenceDecreasingAtIndex[nums.Length - 1] - longestSubsequenceDecreasingAtIndex[i + 1]) + 1);
            }
            Console.WriteLine(Math.Max(maxOfMixNumbers, Math.Max(longestSubsequenceDecreasingList.Count, longestSubsequenceIncreasingList.Count)));
            Console.ReadLine();
        }

        public static void BinarySearchThenAddIncreasing(List<Int32> list, int number, int l, int r, int index, int[] listIndexes)
        {
            if (number < list[0])
            {
                list[0] = number;
                listIndexes[index] = list.Count;
            }
            else if (number == list[list.Count - 1] || number == list[0])
            {
                listIndexes[index] = list.Count;
                return;
            }
            else if (number > list[list.Count - 1])
            {
                list.Add(number);
                listIndexes[index] = list.Count;
            }
            else
            {
                int middle = (l + r) / 2;
                if (number > list[middle] && number <= list[middle + 1])
                {
                    if (number == list[middle + 1])
                    {
                        return;
                    }
                    list[middle + 1] = number;
                    listIndexes[index] = list.Count;
                }
                else if (number <= list[middle])
                {
                    BinarySearchThenAddIncreasing(list, number, l, middle, index, listIndexes);
                }
                else
                {
                    BinarySearchThenAddIncreasing(list, number, middle + 1, r, index, listIndexes);
                }
            }
        }

        public static void BinarySearchThenAddDecreasing(List<Int32> list, int number, int l, int r, int index, int[] listIndexes)
        {
            if (number > list[0])
            {
                list[0] = number;
                listIndexes[index] = list.Count;
            }
            else if (number == list[list.Count - 1] || number == list[0])
            {
                listIndexes[index] = list.Count;
                return;
            }
            else if (number < list[list.Count - 1])
            {
                list.Add(number);
                listIndexes[index] = list.Count;
            }
            else
            {
                int middle = (l + r) / 2;
                if (number < list[middle] && number >= list[middle + 1])
                {
                    list[middle + 1] = number;
                    listIndexes[index] = list.Count;
                }
                else if (number >= list[middle])
                {
                    BinarySearchThenAddDecreasing(list, number, l, middle, index, listIndexes);
                }
                else
                {
                    BinarySearchThenAddDecreasing(list, number, middle + 1, r, index, listIndexes);
                }
            }
        }
    }
}
