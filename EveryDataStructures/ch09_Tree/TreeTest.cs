using System;
using System.Collections.Generic;

namespace ch09_Tree
{
    public class TreeTest
    {
        public void Test()
        {
        }

        private void init()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int FibonacciSequence(int n) 
        {
            if (n < 1) return 0;
            if(n == 1) return 1;
            return FibonacciSequence(n - 1) + FibonacciSequence(n - 2);
        }

        public class Node
        {
            public Int16 Data;
            public Node Left;
            public Node Right;

            public Node(Int16 data) 
            {
                Data= data;
            }

            public List<Node> Children
            {
                get
                {
                    List<Node> children = new List<Node>();
                    if (this.Left != null)
                    {
                        children.Add(this.Left);
                    }
                    if (this.Right != null)
                    {
                        children.Add(this.Right);
                    }
                    return children;
                }
            }

            public bool InsertData(Int16 data) 
            {
                Node node = new Node(data);
                return this.InsertNode(node);
            }

            /// <summary>
            /// 最坏情况下的复杂度O(log(n))
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            public bool InsertNode(Node node) 
            {
                if(node == null || node.Data == this.Data)
                {
                    return false;
                }
                else if(node.Data < this.Data) 
                {
                    if (this.Left == null)
                    {
                        this.Left= node;
                        return true;
                    }
                    else
                    {
                        return this.Left.InsertNode(node);
                    }
                }
                else
                {
                    if (this.Right == null)
                    {
                        this.Right = node;
                        return true;
                    }
                    else
                    {
                        return this.Right.InsertNode(node);
                    }
                }
            }

            public bool Graft(Node node)
            {
                if(node == null)
                {
                    return false;
                }
                List<Node> nodes = node.ListTree();
                foreach (var n in nodes)
                {
                    InsertNode(n);
                }
                return true;
            }

            public Node RemoveData(Int16 data)
            {
                Node node = new Node(data);
                return this.RemoveNode(node);
            }

            /// <summary>
            /// 效率很差的算法复杂度O(n*n)
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            public Node RemoveNode(Node node)
            {
                if (node == null)
                {
                    return null;
                }

                Node retNode;
                Node modNode;
                List<Node> treeList = new List<Node>();

                if (this.Data == node.Data)
                {
                    //找到匹配的根节点
                    retNode = new Node(this.Data);
                    modNode = this;
                    if (this.Children.Count == 0)
                    {
                        return this;//根节点没有子节点
                    }
                }
                else if (this.Left.Data == node.Data)
                {
                    retNode= new Node(this.Left.Data);
                    modNode = this.Left;
                }
                else if (this.Right.Data == node.Data)
                {
                    retNode = new Node(this.Right.Data);
                    modNode = this.Right;
                }
                else
                {
                    foreach (var child in this.Children)
                    {
                        if (child.RemoveNode(node) != null)
                        {
                            return child;
                        }
                    }
                    //树中没有匹配的节点
                    return null;
                }

                // 对树重排序
                if (modNode.Left != null)
                {
                    modNode.Data = modNode.Left.Data;
                    treeList.AddRange(modNode.Left.ListTree());
                    modNode.Left = null;
                }
                else if (modNode.Right != null)
                {
                    modNode.Data = modNode.Right.Data;
                    treeList.AddRange(modNode.Right.ListTree());
                    modNode.Right= null;
                }
                else
                {
                    modNode = null;
                }
                foreach (var n in treeList)
                {
                    modNode.InsertNode(n);
                }

                // 操作完成
                return retNode;
            }

            /// <summary>
            /// 算法复杂度O(n)
            /// </summary>
            /// <param name="root"></param>
            /// <returns></returns>
            public Node Prune(Node root)
            {
                Node matchNode;
                if(this.Data==root.Data) 
                {
                    Node b = this.CopyTree();
                    this.Left = null;
                    this.Right = null;
                    return b;
                }
                else if(this.Left.Data==root.Data) 
                {
                    matchNode = this.Left;
                }
                else if (this.Right.Data == root.Data)
                {
                    matchNode = this.Right;
                }
                else
                {
                    foreach (var child in this.Children)
                    {
                        if (child.Prune(root) != null)
                        {
                            return child;
                        }
                    }
                    // 树中没有匹配的节点
                    return null;
                }

                Node branch = matchNode.CopyTree();
                matchNode= null;
                return branch;
            }

            public Node FindData(Int16 data)
            {
                Node node = new Node(data);
                return this.FindNode(node);
            }

            /// <summary>
            /// 算法复杂度O(log(n))
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            public Node FindNode(Node node)
            {
                if (node.Data == this.Data)
                {
                    return this;
                }

                foreach (var child in this.Children)
                {
                    Node n = child.FindNode(node);
                    if (n != null)
                    {
                        return n;
                    }
                }

                return null;
            }

            public Node CopyTree()
            {
                Node node = new Node(this.Data);
                if(this.Left!=null) 
                {
                    node.Left = this.Left.CopyTree();
                }
                if (this.Right != null)
                {
                    node.Right = this.Right.CopyTree();
                }
                return node;
            }

            public List<Node> ListTree()
            {
                List<Node> list = new List<Node>();
                list.Add(new Node(this.Data));
                foreach (var child in this.Children)
                {
                    list.AddRange(child.ListTree());
                }
                return list;
            }
        }
    }
}
