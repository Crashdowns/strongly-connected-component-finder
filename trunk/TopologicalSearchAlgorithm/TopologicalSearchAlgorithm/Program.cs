using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TopologicalSearchAlgorithm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TopologicalSort.Instance.AddNode(_q);
            TopologicalSort.Instance.AddNode(_r);
            TopologicalSort.Instance.AddNode(_s);
            TopologicalSort.Instance.AddNode(_t);
            TopologicalSort.Instance.AddNode(_u);
            TopologicalSort.Instance.AddNode(_v);
            TopologicalSort.Instance.AddNode(_w);
            TopologicalSort.Instance.AddNode(_x);
            TopologicalSort.Instance.AddNode(_y);
            TopologicalSort.Instance.AddNode(_z);
            TopologicalSort.Instance.AddEdge(_q, _s);
            TopologicalSort.Instance.AddEdge(_q, _w);
            TopologicalSort.Instance.AddEdge(_q, _t);
            TopologicalSort.Instance.AddEdge(_r, _y);
            TopologicalSort.Instance.AddEdge(_r, _u);
            TopologicalSort.Instance.AddEdge(_s, _v);
            TopologicalSort.Instance.AddEdge(_t, _y);
            TopologicalSort.Instance.AddEdge(_u, _y);
            TopologicalSort.Instance.AddEdge(_v, _w);
            TopologicalSort.Instance.AddEdge(_w, _s);
            TopologicalSort.Instance.AddEdge(_y, _q);
            TopologicalSort.Instance.AddEdge(_z, _x);
            TopologicalSort.Instance.AddEdge(_x, _z);
            TopologicalSort.Instance.AlphabeticalSort();
            TopologicalSort.Instance.FirstNodeList = TopologicalSort.Instance.DFS();
            TopologicalSort.Instance.FirstNodeList.Sort(new FinishTimeCompare());
            TopologicalSort.Instance.NewNodeList = TopologicalSort.Instance.TransposeGraph();
            TopologicalSort.Instance.DFS(TopologicalSort.Instance.NewNodeList);
            TopologicalSort.Instance.FirstNodeList.Sort(new FinishTimeCompare());
            Application.Run(new Form1());
            
            
          //  private const char _m = "m";
            //TopologicalSort.Instance.AddNode('
            
        }

        private const char _q = 'q';
        private const char _r = 'r';
        private const char _s = 's';
        private const char _t = 't';
        private const char _u = 'u';
        private const char _v = 'v';
        private const char _x = 'x';
        private const char _w = 'w';
        private const char _y = 'y';
        private const char _z = 'z';
    }
}
