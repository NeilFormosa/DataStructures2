using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1___Searching_and_Sorting_Algorithms;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class allowing the sorting of Order objects based on based on Order ID (ascending order) 
    /// using Quick Sort where the pivot is the left-most element
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// </summary>
    internal class QuickSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            if (unsortedOrderList == null || unsortedOrderList.Count <= 1)
                return unsortedOrderList;

            List<Order> orders = new List<Order>(unsortedOrderList);

            QuickSortHelper(orders, 0, orders.Count - 1);
            return orders;
        }

        private void QuickSortHelper(List<Order> orders, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(orders, left, right);
                QuickSortHelper(orders, left, pivotIndex - 1);
                QuickSortHelper(orders, pivotIndex + 1, right);
            }
        }

        private int Partition(List<Order> orders, int left, int right)
        {
            Order pivot = orders[left];
            int i = left + 1;

            for (int j = i; j <= right; j++)
            {
                if (orders[j].ID.CompareTo(pivot.ID) < 0)
                {
                    Swap(orders, i, j);
                    i++;
                }
            }
            Swap(orders, left, i - 1);
            return i - 1;
        }

        private void Swap(List<Order> orders, int index1, int index2)
        {
            Order temp = orders[index1];
            orders[index1] = orders[index2];
            orders[index2] = temp;
        }
    }
}



