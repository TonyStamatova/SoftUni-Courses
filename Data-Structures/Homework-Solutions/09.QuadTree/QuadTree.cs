﻿using System;
using System.Collections.Generic;
using System.Linq;

public class QuadTree<T> where T : IBoundable
{
    public const int DefaultMaxDepth = 5;

    public readonly int MaxDepth;

    private Node<T> root;

    public QuadTree(int width, int height, int maxDepth = DefaultMaxDepth)
    {
        this.root = new Node<T>(0, 0, width, height);
        this.Bounds = this.root.Bounds;
        this.MaxDepth = maxDepth;
    }

    public int Count { get; private set; }

    public Rectangle Bounds { get; private set; }

    public void ForEachDfs(Action<List<T>, int, int> action)
    {
        this.ForEachDfs(this.root, action);
    }

    public bool Insert(T item)
    {
        Rectangle itemBounds = item.Bounds;
        Node<T> current = this.root;

        if (!item.Bounds.IsInside(current.Bounds))
        {
            return false;
        }

        int depth = 1;

        while (true)
        {
            int quadrant = this.GetQuadrant(current, itemBounds);

            if (quadrant == -1)
            {
                break;
            }

            current = current.Children[quadrant];
            depth++;
        }

        current.Items.Add(item);
        TrySplitNode(current, depth);
        this.Count++;
        return true;
    }

    private void TrySplitNode(Node<T> node, int depth)
    {
        if (!node.ShouldSplit || depth >= MaxDepth)
        {
            return;
        }

        if (node.Children == null)
        {
            int x1 = node.Bounds.X1;
            int y1 = node.Bounds.Y1;
            int leftWidth = node.Bounds.MidX - x1;
            int rightWidth = node.Bounds.Width - leftWidth;
            int upperHeight = node.Bounds.MidY - y1;
            int lowerHeight = node.Bounds.Height - upperHeight;

            node.Children = new Node<T>[4];
            node.Children[0] = new Node<T>(node.Bounds.MidX, y1, rightWidth, upperHeight);
            node.Children[1] = new Node<T>(x1, y1, leftWidth, upperHeight);
            node.Children[2] = new Node<T>(x1, node.Bounds.MidY, leftWidth, lowerHeight);
            node.Children[3] = new Node<T>(node.Bounds.MidX, node.Bounds.MidY, rightWidth,
                lowerHeight);
        }

        List<T> itemsToRemove = new List<T>();
        for (int i = node.Items.Count - 1; i >= 0; i--)
        {
            T item = node.Items[i];
            int quadrant = this.GetQuadrant(node, item.Bounds);

            if (quadrant != -1)
            {
                node.Children[quadrant].Items.Add(item);
                itemsToRemove.Add(node.Items[i]);
            }
        }

        node.Items.RemoveAll(x => itemsToRemove.Contains(x));

        for(int i = 0; i < node.Children.Length; i++)
        {
            TrySplitNode(node.Children[i], depth + 1);
        }
    }

    private int GetQuadrant(Node<T> node, Rectangle itemBounds)
    {
        if (node.Children == null)
        {
            return -1;
        }

        for (int i = 0; i < 4; i++)
        {
            Rectangle nodeBounds = node.Children[i].Bounds;
            if (itemBounds.IsInside(nodeBounds))
            {
                return i;
            }
        }
        return -1;
    }

    public List<T> Report(Rectangle bounds)
    {
        List<T> result = new List<T>();
        this.ReportCollisions(this.root, result, bounds);
        return result;
    }

    private void ReportCollisions(Node<T> node, List<T> result, Rectangle bounds)
    {
        int quadrant = this.GetQuadrant(node, bounds);


        if (quadrant != -1)
        {
            result.AddRange(node.Items);
            ReportCollisions(node.Children[quadrant], result, bounds);
        }
        else
        {
            GetNodeItems(node, result);
        }
    }

    private void GetNodeItems(Node<T> node, List<T> results)
    {
        if (node == null)
        {
            return;
        }

        results.AddRange(node.Items);

        if (node.Children != null)
        {
            for(int i = 0; i < node.Children.Length; i++)
            {
                GetNodeItems(node.Children[i], results);
            }
        }
    }

    private void ForEachDfs(Node<T> node, Action<List<T>, int, int> action, int depth = 1, int quadrant = 0)
    {
        if (node == null)
        {
            return;
        }

        if (node.Items.Any())
        {
            action(node.Items, depth, quadrant);
        }

        if (node.Children != null)
        {
            for (int i = 0; i < node.Children.Length; i++)
            {
                ForEachDfs(node.Children[i], action, depth + 1, i);
            }
        }
    }
}
