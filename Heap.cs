using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class used to build the Heap serving as the underlying data structure for the Priority Queue required to
    /// get the most urgent orders i.e. the ones with the soonest deliver date
    /// 
    /// TODO: You are to determine whether this Heap should be a MinHeap or a MaxHeap 
    /// based on the way that urgent orders need to be identified i.e. soonest delivery date first.
    /// Implement the Insert() and Remove() method for this class; additional methods may be added but these 
    /// must be declared as private and called within the Insert() or Remove() method
    /// </summary>
    internal class Heap
    {
        private Order[] orderHeap;

        private int size = 0;

        public Heap(int maxSize)
        {
            orderHeap = new Order[maxSize];
        }

        /// <summary>
        /// Inserts an order into the heap based on its delivery date.  
        /// Orders having the most recent delivery date should be place at the top of the heap
        /// </summary>
        /// <param name="order">Order to be inserted in the heap</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Insert(Order order)
        {
            orderHeap[size] = order;
            int current = size;
            size++;

            while (current > 0)
            {
                int parent = (current - 1) / 2;
                if (orderHeap[current].deliverOn < orderHeap[parent].deliverOn)
                {
                    Order temp = orderHeap[current];
                    orderHeap[current] = orderHeap[parent];
                    orderHeap[parent] = temp;
                    current = parent;
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Returns the most recent order i.e. the one with the soonest delivery date
        /// </summary>
        /// <returns>Order with the soonest delivery date</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Order Remove()
        {
            if (size == 0)
            {
                return null;
            }

            Order root = orderHeap[0];
            size--;
            orderHeap[0] = orderHeap[size];
            orderHeap[size] = null;

            int current = 0;

            while (true)
            {
                int leftChild = 2 * current + 1;
                int rightChild = 2 * current + 2;
                int smallest = current;

                if (leftChild < size && orderHeap[leftChild].deliverOn < orderHeap[smallest].deliverOn)
                {
                    smallest = leftChild;
                }

                if (rightChild < size && orderHeap[rightChild].deliverOn < orderHeap[smallest].deliverOn)
                {
                    smallest = rightChild;
                }

                if (smallest != current)
                {
                    Order temp = orderHeap[current];
                    orderHeap[current] = orderHeap[smallest];
                    orderHeap[smallest] = temp;
                    current = smallest;
                }
                else
                {
                    break;
                }
            }

            return root;
        }
    }
}
