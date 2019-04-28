using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    public Node root;

    public BinarySearchTree()
    {
        this.root = null;
    }

    private BinarySearchTree(Node node)
    {
        this.root = node;
    }

    public void Insert(T value)
    {
        if (this.root == null)
        {
            this.root = new Node(value);
            return;
        }

        Node parent = null;
        Node current = this.root;

        while (current != null)
        {
            int compared = current.Value.CompareTo(value);
            if (compared > 0)
            {
                parent = current;
                current = current.Left;
            }
            else if (compared < 0)
            {
                parent = current;
                current = current.Right;
            }
            else
            {
                return;
            }
        }

        Node newNode = new Node(value);
        if (parent.Value.CompareTo(value) > 0)
        {
            parent.Left = newNode;
        }
        else
        {
            parent.Right = newNode;
        }
    }

    public bool Contains(T value)
    {
        Node current = this.root;

        while (current != null)
        {
            int compared = current.Value.CompareTo(value);

            if (compared > 0)
            {
                current = current.Left;
            }
            else if (compared < 0)
            {
                current = current.Right;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        if (this.root.Left == null && this.root.Right == null)
        {
            this.root = null;
            return;
        }

        Node parent = null;
        Node current = this.root;


        while (current.Left != null)
        {
            parent = current;
            current = current.Left;
        }
        if (current.Right != null)
        {
            parent.Left = current.Right;
        }
        else
        {
            parent.Left = null;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node current = this.root;

        while (current != null)
        {
            int compared = current.Value.CompareTo(item);
            if (compared > 0)
            {
                current = current.Left;
            }
            else if (compared < 0)
            {
                current = current.Right;
            }
            else
            {
                return new BinarySearchTree<T>(current);
            }
        }
        return null;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        List<T> result = new List<T>();
        this.Range(this.root, result, startRange, endRange);
        return result;
    }

    private void Range(Node node, List<T> result, T start, T end)
    {
        if (node == null)
        {
            return;
        }

        int comparedLower = node.Value.CompareTo(start);
        int comparedHigher = node.Value.CompareTo(end);

        if (comparedLower > 0)
        {
            this.Range(node.Left, result, start, end);
        }
        if (comparedLower >= 0 && comparedHigher <= 0)
        {
            result.Add(node.Value);
        }
        if (comparedHigher < 0)
        {
            this.Range(node.Right, result, start, end);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }
        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    public class Node
    {
        public T Value
        {
            get;
            set;
        }

        public Node Left
        {
            get;
            set;
        }

        public Node Right
        {
            get;
            set;
        }

        public Node(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
}

public class Launcher
{
    public static void Main()
    {
        BinarySearchTree<int> BST = new BinarySearchTree<int>();

        BST.Insert(20);
        BST.Insert(16);
        BST.Insert(17);
        BST.Insert(28);
        BST.Insert(14);
        BST.Insert(29);
        BST.Insert(29);

        List<int> list = new List<int>();
        BST.EachInOrder(list.Add);
        Console.WriteLine(string.Join(" ", list));

    }
}
