﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.DoublyLinkedList
{
    internal class DLList<T>
    {
        public GenericNode<T>? Head { get; set; }
        public GenericNode<T>? Tail { get; set; }

        public DLList()
        {
            Head = null;
            Tail = null;
        }

        public void InsertFirst(T t)
        {
            GenericNode<T> tmp = new GenericNode<T>();
            tmp.Value = t;
            tmp.Next = Head;
            tmp.Prev = null;

            tmp.Count++;

            if (IsEmpty())
            {
                Tail = tmp;
            }

            Head = tmp;
        }

        public void InsertLast(T t)
        {
            if (Head == null)
            {
                InsertFirst(t);
                return;
            }

            GenericNode<T> tmp = new();
            tmp.Value = t;
            tmp.Next = null;
            tmp.Prev = Tail;

            tmp.Count++;

            Tail!.Next = tmp;
            Tail = tmp;

        }

        public void Traverse(int count) 
        { 
            if (Head == null)
            {
                Console.WriteLine("Empty List");
                return;
            }

            Console.WriteLine($"Total Chars: {count}");
            for (GenericNode<T> node = Head; node != null; node = node.Next!)
            {
                Console.WriteLine($"Value: {node.Value}, Count: {node.Count}, Frequency: {((double)node.Count / count):P}");
            }
        }

        public GenericNode<T>? GetNodePosition(T t)
        {
            GenericNode<T> tmp = Head!;
            while (tmp != null)
            {
                if (tmp.Value!.Equals(t))
                {
                    return tmp;
                }
                tmp = tmp.Next!;
            }

            return null;
        }

        public void IncreaseCount(GenericNode<T> node)
        {
            node.Count++;
        }

        public void IncreaseCount(T t)
        {
            GetNodePosition(t)!.Count++;
        }

        public void SortByValAsc()
        {
            for (GenericNode<T> node = Head!; node != null; node = node.Next!)
            {
                T minVal = node.Value!;
                GenericNode<T> minPos = node;

                for (GenericNode<T> jNode = node; jNode != null; jNode = jNode.Next!)
                {
                    if (jNode.Value is char)
                    {
                        if (Convert.ToChar(jNode.Value) < Convert.ToChar(minVal))
                        {
                            minVal = jNode.Value;
                            minPos = jNode;
                        }
                    }
                }
                Swap(node, minPos);
            }
        }


        public void Swap(GenericNode<T> iNode, GenericNode<T> jNode) 
        {
            T tempVal = iNode.Value!;
            int tempCount = iNode.Count;

            iNode.Value = jNode.Value!;
            iNode.Count = jNode.Count;

            jNode.Value = tempVal;
            jNode.Count = tempCount;
        }

        public void SortyByFrequencyDesc()
        {
            for (GenericNode<T> iNode = Head!; iNode != null; iNode = iNode.Next!)
            {
                int minVal = iNode.Count;
                GenericNode<T> minPos = iNode;

                for (GenericNode<T> jNode = iNode; jNode != null; jNode = jNode.Next!)
                {
                    if(jNode.Count > minVal)
                    {
                        minVal = jNode.Count;
                        minPos = jNode;
                    }
                }
                Swap(iNode, minPos);
            }
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

    }
}
