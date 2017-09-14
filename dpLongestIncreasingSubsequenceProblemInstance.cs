using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class dpLongestIncreasingSubsequenceProblemInstance
    {
        static int maxSum = 0;
        static int currentSum = 0;
        public static void Main1()
        {
            int[] nums = new int[] { 1, 101, 2, 3, 100, 4, 5 };
            List<int> longestSubsequence = new List<int>();

            
            longestSubsequence.Add(nums[0]);
            currentSum = nums[0];
            maxSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                BinarySearchThenAddIncreasing(longestSubsequence, nums[i], 0, longestSubsequence.Count);
            }
            Console.WriteLine(maxSum);
            Console.ReadLine();
        }

        public static void BinarySearchThenAddIncreasing(List<Int32> list, int number,int l , int r)
        {
            if(number < list[0])
            {
                list[0] = number;
            }
            else if (number > list[list.Count -1])
            {
                list.Add(number);
                currentSum += number;
                maxSum = Math.Max(maxSum, currentSum);
            }
            else
            {
                int middle = (l + r) / 2;
                if (number > list[middle] && number <= list[middle + 1])
                {
                    currentSum = currentSum - list[middle + 1];
                    list[middle + 1] = number;
                    currentSum = currentSum + number;
                    maxSum = Math.Max(maxSum, currentSum);                   
                }
                else if(number <= list[middle])
                {
                    BinarySearchThenAddIncreasing(list, number, l, middle);
                }
                else
                {
                    BinarySearchThenAddIncreasing(list, number, middle + 1, r);
                }
            }
        }
    }
}
