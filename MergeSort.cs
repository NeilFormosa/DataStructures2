using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class allowing the sorting of Order objects based on Date Placed (most recent first) using Merge Sort
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// </summary>
    internal class MergeSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            if (unsortedOrderList == null || unsortedOrderList.Count <= 1)
                return unsortedOrderList;

            return MergeSortRecursive(unsortedOrderList);
        }

        private List<Order> MergeSortRecursive(List<Order> list)
        {
            if (list.Count <= 1)
                return list;

            int mid = list.Count / 2;
            List<Order> left = list.GetRange(0, mid);
            List<Order> right = list.GetRange(mid, list.Count - mid);

            left = MergeSortRecursive(left);
            right = MergeSortRecursive(right);

            return Merge(left, right);
        }

        private List<Order> Merge(List<Order> left, List<Order> right)
        {
            List<Order> result = new List<Order>();

            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                if (left[i].placedOn >= right[j].placedOn)
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }

            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }
    }
}
