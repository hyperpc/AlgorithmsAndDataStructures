using System.Collections.Generic;

namespace ch10_Heap
{
    public class HeapTest
    {
        public void Test()
        {
        }

        private void init()
        {
        }

        public class HeapNode
        {
            public int Data { get; set; }
        }

        public class MinHeap
        {
            List<HeapNode> elements;
            public int Count
            {
                get
                {
                    return elements.Count;
                }
            }

            public MinHeap()
            {
                elements = new List<HeapNode>();
            }

            public void Insert(HeapNode item)
            {
                elements.Add(item);
                OrderHeap();
            }

            public void Delete(HeapNode item)
            {
                int i = elements.IndexOf(item);
                int last = elements.Count - 1;
                elements[i] = elements[last];
                elements.RemoveAt(last);
                OrderHeap();
            }

            public HeapNode ExtractMin()
            {
                if (elements.Count > 0)
                {
                    HeapNode item = elements[0];
                    Delete(item);
                    return item;
                }
                return null;
            }

            public HeapNode FindMin()
            {
                if (elements.Count > 0)
                {
                    return elements[0];
                }
                return null;
            }

            public List<HeapNode> GetChildren(int parentIndex)
            {
                if (parentIndex >= 0)
                {
                    List<HeapNode> children = new List<HeapNode>();
                    int childrenOne = 2 * parentIndex + 1;
                    int childrenTwo = 2 * parentIndex + 2;

                    children.Add(elements[childrenOne]);
                    children.Add(elements[childrenTwo]);
                    return children;
                }
                return null;
            }

            public HeapNode GetParent(int childrenIndex)
            {
                if(childrenIndex>0 && elements.Count > childrenIndex)
                {
                    int parentIndex = (childrenIndex - 1) / 2;
                    return elements[parentIndex];
                }
                return null;
            }

            public void OrderHeap()
            {
                for (int i = elements.Count - 1; i > 0; i--)
                {
                    int parentPosition = (i - 1) / 2;
                    if (elements[parentPosition].Data > elements[i].Data)
                    {
                        SwapElements(parentPosition, i);
                    }
                }
            }

            public void SwapElements(int firstIndex, int secondIndex)
            {
                HeapNode tmp = elements[firstIndex];
                elements[firstIndex] = elements[secondIndex];
                elements[secondIndex] = tmp;
            }
        }

        public class MaxHeap
        {
            List<HeapNode> elements;
            public int Count
            {
                get
                {
                    return elements.Count;
                }
            }

            public MaxHeap()
            {
                elements = new List<HeapNode>();
            }

            public void Insert(HeapNode item)
            {
                elements.Add(item);
                OrderHeap();
            }

            public void Delete(HeapNode item)
            {
                int i = elements.IndexOf(item);
                int last = elements.Count - 1;
                elements[i] = elements[last];
                elements.RemoveAt(last);
                OrderHeap();
            }

            public HeapNode ExtractMax()
            {
                if (elements.Count > 0)
                {
                    HeapNode item = elements[0];
                    Delete(item);
                    return item;
                }
                return null;
            }

            public HeapNode FindMax()
            {
                if (elements.Count > 0)
                {
                    return elements[0];
                }
                return null;
            }

            public List<HeapNode> GetChildren(int parentIndex)
            {
                if (parentIndex >= 0)
                {
                    List<HeapNode> children = new List<HeapNode>();
                    int childrenOne = 2 * parentIndex + 1;
                    int childrenTwo = 2 * parentIndex + 2;

                    children.Add(elements[childrenOne]);
                    children.Add(elements[childrenTwo]);
                    return children;
                }
                return null;
            }

            public HeapNode GetParent(int childrenIndex)
            {
                if (childrenIndex > 0 && elements.Count > childrenIndex)
                {
                    int parentIndex = (childrenIndex - 1) / 2;
                    return elements[parentIndex];
                }
                return null;
            }

            public void OrderHeap()
            {
                for (int i = 0; i < elements.Count - 1; i--)
                {
                    int parentPosition = (i - 1) / 2;
                    if (elements[parentPosition].Data < elements[i].Data)
                    {
                        SwapElements(parentPosition, i);
                    }
                }
            }

            public void SwapElements(int firstIndex, int secondIndex)
            {
                HeapNode tmp = elements[firstIndex];
                elements[firstIndex] = elements[secondIndex];
                elements[secondIndex] = tmp;
            }
        }
    }
}
