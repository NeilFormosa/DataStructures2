﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// A class representing a Binary Search Tree aimed at facilitating the search of orders by order id.
    /// TODO: You are to implement the Build() and Find() methods for this class; additional methods may be added but
    /// any methods added to this class must be declared as private and called within the Build() or Find() method
    /// </summary>
    internal class BinarySearchTree
    {
        public TreeNode Root { get; private set; }

        /// <summary>
        /// Builds a Binary Search tree based on the list of orders passed as parameter i.e.
        /// It inserts each order in the list into the tree
        /// 
        /// TODO: Implement this methods as described above and in Task 1
        /// 
        /// </summary>
        /// <param name="Orders">List<Order> list of orders to be inserted in the tree</param>
        public void Build(List<Order> Orders)
        {
            // TODO: Implement this methods as described above and in Task 1
            Root = null;
            if (Orders == null || Orders.Count == 0)
                return;

            Root = new TreeNode(Orders[0]);

            for (int i = 1; i < Orders.Count; i++)
            {
                Insert(Root, Orders[i]);
            }
        }

        /// <summary>
        /// Searches for an Order with given id in the tree, if no match is found, null is returned
        /// 
        /// TODO: Implement this methods as described above and in Task 1
        /// 
        /// </summary>
        /// <param name="orderID">Guid id of order to search for</param>
        /// <returns>Order matching id or null</returns>
        public Order Get(Guid orderID)
        {
            // TODO: Implement this methods as described above and in Task 1
            return Find(Root, orderID);
        }

        private void Insert(TreeNode node, Order order)
        {
            if (order.ID.CompareTo(node.order.ID) < 0)
            {
                if (node.Left == null)
                    node.Left = new TreeNode(order);
                else
                    Insert(node.Left, order);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new TreeNode(order);
                else
                    Insert(node.Right, order);
            }
        }

        private Order Find(TreeNode node, Guid orderID)
        {
            if (node == null)
                return null;

            int comparison = orderID.CompareTo(node.order.ID);

            if (comparison == 0)
                return node.order;
            else if (comparison < 0)
                return Find(node.Left, orderID);
            else
                return Find(node.Right, orderID);
        }
    }
}
