using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntGraph;

namespace _19
{
    /*27.	Задан набор неповторяющихся пар(Ai, Aj), Ai, Aj принадлежат множеству А = { A1, A2, ..., An }. Необходимо составить цепочку максимальной длины по правилу
    (Ai, Aj)+(Aj, Ak)=(Ai, Aj, Ak).
    При образовании этой цепочки любая пара может быть использована не более одного раза.
    */
    public partial class PairForm : Form
    {
        public PairForm()
        {
            InitializeComponent();
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileTools file = new FileTools(openFileDialog.FileName);
                    Input.Text = file.Read() ;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileTools file = new FileTools(saveFileDialog.FileName);
                    file.Write(Input.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void GetWay_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pair> pairs = Pair.PairsFromString(Input.Text);
                PairGraph graph = new PairGraph(pairs);
                List<int> Way = graph.GetMaxWay();
                MessageBox.Show(String.Join(" ", Way));
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
