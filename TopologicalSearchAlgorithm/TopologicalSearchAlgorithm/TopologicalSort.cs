using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopologicalSearchAlgorithm
{
    public class TopologicalSort
    {
        public int Time = 0;
        public List<Node> FirstNodeList;
        public List<Node> NewNodeList;
        public static TopologicalSort Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TopologicalSort();
                return _instance;
            }
        }
        public void DFS(List<Node> _list)
        {
            Time = 0;
            _SortedList.Clear();
            for (int i = 0; i < _list.Count;i++)
            {
                _list[i].NodeColor = Color.White;
            }
            for (int i = 0; i < _list.Count;i++)
            {
                if (_list[i].NodeColor == Color.White)
                    DFS_VISIT(_list[i]);
            }
        }
        public List<Node> DFS()
        {
            _SortedList.Clear();
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (_nodes[i].NodeColor == Color.White)
                    DFS_VISIT(_nodes[i]);
            }
            return GetNodeList();
        }
        public void DFS_VISIT(Node n)
        {
            n.NodeColor = Color.Gray;
            n.discoverTime = ++Time;
            foreach (Edge e in n.Edges)
            {
                if (e.Node2.NodeColor == Color.White)
                    DFS_VISIT(e.Node2);
            }
            n.finishTime = ++Time;
            n.NodeColor = Color.Black;
            _SortedList.AddFirst(n);
        }
        
        public List<Node> TransposeGraph()
        {
            List<Node> newNodes = new List<Node>();
            for (int i = 0; i < _nodes.Count ; i++)
            {
                newNodes.Add(new Node(_nodes[i].Name));
            }
            foreach (Edge e in _edges)
                e.Transpose();

            foreach (Node n in newNodes)
            {
                foreach (Edge e in _edges)
                {
                    if (e.Node1.Name == n.Name)
                        n.Edges.Add(e);
                }
            }
            _nodes = newNodes;
            foreach (Edge e in _edges)
            {
                for (int i = 0; i < newNodes.Count; i++)
                {
                    if (e.Node1.Name == newNodes[i].Name)
                        e.Node1 = newNodes[i];

                    if (e.Node2.Name == newNodes[i].Name)
                        e.Node2 = newNodes[i];
                }
            }
            return _nodes;
        }
        public List<Node> GetNodeList()
        {
            return _SortedList.ToList<Node>();
        }
        public void AddNode(char n)
        {
            _nodes.Add(new Node(n));
        }
        public void AddNode(Node n)
        {
            _nodes.Add(n);
        }
        public void AlphabeticalSort()
        {
            _nodes.Sort(new AlphabeticalCompare());
        }
        public void AddEdge(char n1, char n2)
        {
            Edge e = new Edge(n1, n2);
            _edges.Add(e);
            foreach (Node n in _nodes)
            {
                if (n.Name == n1)
                    n.Edges.Add(e);
            }
        }

        public Node getNode(char _name)
        {
            foreach(Node n in _nodes)
            {
                if (n.Name == _name)
                    return n;
            }
            Node __new = new Node(_name);
            AddNode(__new);
            return __new;
        }
        private LinkedList<Node> _SortedList = new LinkedList<Node>();
        private List<Node> _nodes = new List<Node>();

        private List<Edge> _edges = new List<Edge>();
        private static TopologicalSort _instance;
    }
   
    public enum Color { White, Gray, Black }

    public class AlphabeticalCompare : IComparer<Node>
    {
        int IComparer<Node>.Compare(Node obj1, Node obj2)
        {

            if (obj1.Name > obj2.Name)
                return 1;
            if (obj1.Name == obj2.Name)
                return 0;
            else
                return -1;
        }
    }
    public class FinishTimeCompare : IComparer<Node>
    {
        int IComparer<Node>.Compare(Node obj1, Node obj2)
        {

            if (obj1.finishTime < obj2.finishTime)
                return 1;
            if (obj1.finishTime == obj2.finishTime)
                return 0;
            else
                return -1;
        }
    }
    public class Node : IComparable
    {
        public Node(char n)
        {
            Name = n;
        }
        public Color NodeColor = Color.White;
        public char Name;
        public List<Edge> Edges = new List<Edge>();
        public int finishTime = 0;
        public int discoverTime = 0;

        public override string ToString()
        {
            return "Vertex: " + Name + ", Discover Time:" + discoverTime + ", Finish Time:" + finishTime;
        }
        public int CompareTo(object obj)
        {
            Node obj2 = obj as Node;
            if (obj2.discoverTime > discoverTime)
                return -1;// sorting lowest to highest, values are reveresed.
            else if (obj2.discoverTime == discoverTime)
                return 0;
            else return 1;
        }

    }
    public class Edge
    {
        public void Transpose()
        {
            Node temp = Node1;
            Node1 = Node2;
            Node2 = temp;
        }
        public Edge(char _1, char _2)
        {
            Node1 = TopologicalSort.Instance.getNode(_1);
            Node2 = TopologicalSort.Instance.getNode(_2);
        }
        public Node Node1;
        public Node Node2;
    }
}
