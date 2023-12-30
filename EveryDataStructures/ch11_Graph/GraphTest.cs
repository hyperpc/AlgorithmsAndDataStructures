using System;
using System.Collections.Generic;

namespace ch11_Graph
{
    public class GraphTest
    {
        public class GraphNode
        {
            public Int16 Value;
            private List<GraphNode> _neighbors;
            public List<GraphNode> Neighbors
            {
                get { return _neighbors; }
            }

            public GraphNode()
            {
                _neighbors = new List<GraphNode>();
            }

            public GraphNode(Int16 value)
            {
                _neighbors = new List<GraphNode>();
                Value = value;
            }
        }

        public class Graph
        {
            private List<GraphNode> _nodes;
            public List<GraphNode> Nodes
            {
                get { return _nodes; }
            }

            public Graph(List<GraphNode> nodes)
            {
                if (nodes == null)
                {
                    _nodes = new List<GraphNode>();
                }
                else
                {
                    _nodes = nodes;
                }
            }

            /// <summary>
            /// 操作复杂度O(1)
            /// </summary>
            /// <param name="node"></param>
            public void AddNodes(GraphNode node)
            {
                _nodes.Add(node);
            }

            /// <summary>
            /// 操作复杂度O(1)
            /// </summary>
            /// <param name="value"></param>
            public void AddNodeForValue(Int16 value)
            {
                _nodes.Add(new GraphNode(value));
            }

            /// <summary>
            /// 操作复杂度O(n+k)；n为图中节点总数，k为图中边的总数
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public bool RemoveNode(Int16 value)
            {
                // n
                GraphNode nodeToRemove = _nodes.Find(n => n.Value == value);
                if (nodeToRemove == null)
                {
                    return false;
                }
                _nodes.Remove(nodeToRemove);
                // k
                foreach (var n in _nodes)
                {
                    var index = n.Neighbors.IndexOf(nodeToRemove);
                    if (index != 1)
                    {
                        n.Neighbors.RemoveAt(index);
                    }
                }

                return true;
            }

            /// <summary>
            /// 操作复杂度O(1)
            /// </summary>
            /// <param name="from"></param>
            /// <param name="to"></param>
            public void AddEdge(GraphNode from, GraphNode to)
            {
                from.Neighbors.Add(to);
            }

            /// <summary>
            /// 操作复杂度O(2)
            /// </summary>
            /// <param name="from"></param>
            /// <param name="to"></param>
            public void AddBidirectedEdge(GraphNode from, GraphNode to)
            {
                from.Neighbors.Add(to);
                to.Neighbors.Add(from);
            }

            /// <summary>
            /// 操作复杂度O(n)
            /// </summary>
            /// <param name="from"></param>
            /// <param name="to"></param>
            /// <returns></returns>
            public bool Adjacent(GraphNode from, GraphNode to)
            {
                return from.Neighbors.Contains(to);
            }

            /// <summary>
            /// 操作复杂度O(n)
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public List<GraphNode> Neighbors(Int16 value)
            {
                // n
                GraphNode node = _nodes.Find(n => n.Value == value);
                if (node == null)
                {
                    return null;
                }
                else
                {
                    return node.Neighbors;
                }
            }

            /// <summary>
            /// 操作复杂度O(1)
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public List<GraphNode> Neighbors(GraphNode node)
            {
                // 1
                if (node == null)
                {
                    return null;
                }
                else
                {
                    return node.Neighbors;
                }
            }

            /// <summary>
            /// 操作复杂度O(1)
            /// </summary>
            public int Count
            {
                get { return _nodes.Count; }
            }
        }
    }
}
