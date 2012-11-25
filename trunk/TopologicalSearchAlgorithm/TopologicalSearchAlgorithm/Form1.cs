using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TopologicalSearchAlgorithm;

namespace TopologicalSearchAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            firstList.DataSource = TopologicalSort.Instance.FirstNodeList;
            List<Node> secondList = TopologicalSort.Instance.GetNodeList();
           secondList.Sort();
           finalList.DataSource = secondList;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
